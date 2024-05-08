using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Microsoft.Graph.Core;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace ZWinformsCoreAppCallsMsgraph
{
	public partial class FormSignIn : Form
	{
		// Use dependency injection
		private IConfiguration? _configuration;
		private IUserAuthStatus? _userAuthStatus;

		bool ForceLogin = false;
		private string[] scopes; // = new string[] { "user.read.all", "GroupMember.Read.All" };
		string[] scopesReadOnly;
		string[] scopesReadWrite;
		IPublicClientApplication app = null;


		public FormSignIn(IConfiguration configuration, IUserAuthStatus? userAuthStatus)
		{
			InitializeComponent();
			//_configuration = Program.ServiceProvider.GetRequiredService<IConfiguration>();
			_configuration = configuration;
			_userAuthStatus = userAuthStatus;
			app = Program.PublicClientApp;
		}
		private void FormSignIn_Load(object sender, EventArgs e)
		{
			_userAuthStatus.SignOut();

			// WOW! Read Configuration JSON array into string array!
			scopesReadOnly = _configuration.GetSection("Scopes:ReadOnly").GetChildren().ToArray().Select(s => s.Value).ToArray();
			scopesReadWrite = _configuration.GetSection("Scopes:ReadWrite").GetChildren().ToArray().Select(s => s.Value).ToArray();

			radioButtonScopes1.Text = string.Join(", ", scopesReadOnly);
			radioButtonScopes2.Text = string.Join(", ", scopesReadWrite);
		}

		private async void buttonSignIn_Click(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				//
				scopes = radioButtonScopes1.Checked ? scopesReadOnly : scopesReadWrite;
				if (radioButtonMethod1.Checked)
				{
					await SignInWithMethod1();
				}
				else
				{
					SignInWithMethod2();
				}
				GraphServiceClient graphServiceClient = _userAuthStatus.GraphServiceClient;
				if (graphServiceClient != null)
				{
					_userAuthStatus.IsAuthenticated = true;
					_userAuthStatus.SignedInUser = await graphServiceClient.Me.GetAsync();
					_userAuthStatus.GroupsThatSignedInUserDirectMemberOf = await GraphApiWrapper.getGroupsMeDirectMemberOf(graphServiceClient);
					_userAuthStatus.GroupsThatSignedInUserTransitiveMemberOf = await GraphApiWrapper.getGroupsMeTransitiveMemberOf(graphServiceClient);
					this.Hide();
					new FormMain().ShowDialog();
					this.Show();
				}

			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
			}
			finally
			{
				Cursor.Current = Cursors.Arrow;
			}
		}
		/// <summary>
		/// Sign in with method 1 provides an AuthenticationResult and GraphServiceClient.
		/// </summary>
		private async Task SignInWithMethod1()
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				_userAuthStatus.AuthResult = await GetAuthenticationResult();
				// TRICKY! Create a GraphServiceClient using an AccessToken that was previously acquired via AcquireTokenInteractive. 
				_userAuthStatus.GraphServiceClient = new GraphServiceClient(new CustomTokenCredential(_userAuthStatus.AuthResult.AccessToken), scopes);

			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
			}
			finally
			{
				Cursor.Current = Cursors.Arrow;
			}
		}
		/// <summary>
		/// Sign in with method 2 provides only a GraphServiceClient.
		/// </summary>
		private void SignInWithMethod2()
		{
			_userAuthStatus.AuthResult = null;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				// @ken 4/11/2024
				//..GraphServiceClient graphClient = null;
				// Create a GraphServiceClient using InteractiveBrowserCredential
				// using Azure.Identity;
				var options = new InteractiveBrowserCredentialOptions
				{
					TenantId = _configuration.GetValue<string>("TenantId"),
					ClientId = _configuration.GetValue<string>("ClientId"),
					AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
					// MUST be http://localhost or http://localhost:PORT
					// See https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/System-Browser-on-.Net-Core
					RedirectUri = new Uri("http://localhost"),
				};

				// https://learn.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential
				var interactiveCredential = new InteractiveBrowserCredential(options);
				_userAuthStatus.GraphServiceClient = new GraphServiceClient(interactiveCredential, scopes);
			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
			}
			finally
			{
				Cursor.Current = Cursors.Arrow;
			}
		}
		/// <summary>
		/// Use PublicClientApp.AcquireTokenSilent and AcquireTokenInteractive to get an AuthenticationResult.
		/// The AuthenticationResult will contain both an IdToken and AccessToken.
		/// With help from a special class, CustomTokenCredential, a GraphServiceClient using the AccessToken and scopes. 
		/// </summary>
		private async Task<AuthenticationResult> GetAuthenticationResult()
		{
			string errmssg = null;
			AuthenticationResult authResult = null;
			var accounts = await app.GetAccountsAsync();
			var firstAccount = accounts.FirstOrDefault();

			try
			{
				authResult = await app.AcquireTokenSilent(scopes, firstAccount)
					.ExecuteAsync();
			}
			catch (MsalUiRequiredException ex)
			{
				// A MsalUiRequiredException happened on AcquireTokenSilent.
				// This indicates you need to call AcquireTokenInteractive to acquire a token
				System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

				try
				{
					Microsoft.Identity.Client.Prompt prompt = ForceLogin ?
						Microsoft.Identity.Client.Prompt.ForceLogin :
						Microsoft.Identity.Client.Prompt.SelectAccount;
					authResult = await app.AcquireTokenInteractive(scopes)
						.WithAccount(accounts.FirstOrDefault())
						//.WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
						.WithPrompt(prompt)
						.ExecuteAsync();
				}
				catch (MsalException msalex)
				{
					errmssg = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
					throw new Exception(errmssg);
				}
			}
			catch (Exception ex)
			{
				errmssg = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
				throw new Exception(errmssg);
			}
			return authResult;
		}
		// Reference: https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/logout.md
		// The logout process for MSAL takes two steps.
		// 		Clear the MSAL cache. (app.RemoveAsync)
		// 		Clear the session on the identity server.
		private async void buttonSignOut_Click(object sender, EventArgs e)
		{
			string infomssg = null;
			_userAuthStatus.SignOut();
			var accounts = await app.GetAccountsAsync();

			if (accounts.Any())
			{
				try
				{
					await app.RemoveAsync(accounts.FirstOrDefault());
				}
				catch (MsalException ex)
				{
					Constants.DisplayExceptionMessage(ex);
				}
			}
			Constants.DisplayInfoMessage(Constants.SignOutInstructions);
		}

	}
}
