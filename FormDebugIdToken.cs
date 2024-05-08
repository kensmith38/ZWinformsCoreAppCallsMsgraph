using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace ZWinformsCoreAppCallsMsgraph
{
	public partial class FormDebugIdToken : Form
	{
		private IConfiguration? _configuration;

		private IUserAuthStatus? _userAuthStatus;

		public FormDebugIdToken()
		{
			InitializeComponent();
			_configuration = Program.ServiceProvider.GetRequiredService<IConfiguration>();
			_userAuthStatus = Program.ServiceProvider.GetRequiredService<IUserAuthStatus>();
		}

		private void FormDebugIdToken_Load(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				AuthenticationResult authResult = _userAuthStatus.AuthResult;
				textBoxIdTokenValidYorN.Clear();
				var tokenExpiresTime = $"Token Expires: {authResult.ExpiresOn.ToLocalTime().ToString()}";
				textBoxTokenExpirationTime.Text = tokenExpiresTime;
				textBoxIdTokenValidYorN.Text = validateIdToken(authResult) ? "Y" : "N";

				displayClaimsOfSignedInUser(authResult);
				displayAccessToken(authResult);
				displayIdToken(authResult);
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
		private void displayClaimsOfSignedInUser(AuthenticationResult authResult)
		{
			textBoxClaimsForSignedInUser.Clear();
			var listClaims = authResult.ClaimsPrincipal.Claims;
			foreach (var claim in listClaims)
			{
				textBoxClaimsForSignedInUser.AppendText(claim.ToString() + System.Environment.NewLine);
			}
		}
		/// <summary>
		/// Display the raw data and decoded Access token
		/// </summary>
		private void displayAccessToken(AuthenticationResult authResult)
		{
			textBoxRawDataAccessToken.Text = authResult.AccessToken;
			textBoxDecodedIdTokenClaims.Clear();
			// Reference: https://stackoverflow.com/questions/38340078/how-to-decode-jwt-token (see answered Cooxkie)
			// Reference: https://www.c-sharpcorner.com/interview-question/how-to-decode-jwtjson-web-token-token-by-using-c-sharp 
			// Reference: https://jwt.ms/ (decode JWT Security token but Visual Studio debug will do it too)
			// The claims (app roles) are in the authResult.IdToken (which is encoded as Base64 JWT - JSON Web Token).
			// So we must decode it to get a JwtSecurityToken (which has Header, Payload (contains the claims), and Signature).
			var token = authResult.AccessToken;
			var handler = new JwtSecurityTokenHandler();
			JwtSecurityToken decodedValue = handler.ReadJwtToken(token);
			var claims = decodedValue.Claims;
			foreach (var claim in claims)
			{
				textBoxDecodedAccessTokenClaims.AppendText(claim.ToString() + System.Environment.NewLine);
			}
		}
		/// <summary>
		/// Display the raw data and decoded ID token
		/// </summary>
		private void displayIdToken(AuthenticationResult authResult)
		{
			textBoxRawDataIdToken.Text = authResult.IdToken;
			textBoxDecodedIdTokenClaims.Clear();
			// The claims (app roles) are in the authResult.IdToken (which is encoded as Base64 JWT - JSON Web Token).
			// So we must decode it to get a JwtSecurityToken (which has Header, Payload (contains the claims), and Signature).
			var idtoken = authResult.IdToken;
			var handler = new JwtSecurityTokenHandler();
			JwtSecurityToken decodedValue = handler.ReadJwtToken(idtoken);
			var claims = decodedValue.Claims;
			foreach (var claim in claims)
			{
				textBoxDecodedIdTokenClaims.AppendText(claim.ToString() + System.Environment.NewLine);
			}
			/*
			// Get roles claims (may be zero, one, or many!)
			var rolesClaims = decodedValue.Claims.Where(c => c.Type == "roles");
			if (rolesClaims.Count() == 0)
			{
				Constants.DisplayInfoMessage("No roles assigned to this user. TBD - Do not allow user to proceed.");
			}
			else
			{
				var ctrRoles = rolesClaims.Count();
				var listRoles = new List<string>();
				textBoxDecodedIdTokenClaims.Clear();
				foreach (var role in rolesClaims)
				{
					listRoles.Add(role.Value);
					textBoxDecodedIdTokenClaims.AppendText(role.Value + System.Environment.NewLine);
				}
			}
			*/
		}
		/// <summary>
		/// Returns true if Id Token is valid.
		/// Only a web api should try to validate an AccessToken.  Perhaps this logic could be modified to verify AccessToken im a web api.
		/// </summary>
		private bool validateIdToken(AuthenticationResult authResult)
		{
			bool tokenIsValid = true;

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				// Reference: Validate https://github.com/Azure-Samples/active-directory-dotnet-webapi-manual-jwt-validation/blob/master/README.md
				//						https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens#validating-tokens
				//						https://learn.microsoft.com/en-us/answers/questions/1063891/do-the-msal-libraries-verify-tokens
				//						https://learn.microsoft.com/en-us/dotnet/api/system.identitymodel.tokens.jwt.jwtsecuritytokenhandler?view=msal-web-dotnet-latest
				//						https://medium.com/@mmoshikoo/jwt-authentication-using-c-54e0c71f21b0
				//						https://auth0.com/blog/how-to-validate-jwt-dotnet/
				//						https://d28m3l9ryqsunl.cloudfront.net/docs/guides/validate-access-tokens/dotnet/main/
				string tenantId = _configuration.GetValue<string>("TenantId");

				string discoveryEndpoint = $"https://login.microsoftonline.com/{tenantId}/v2.0/.well-known/openid-configuration";

				ConfigurationManager<OpenIdConnectConfiguration> configManager =
					new ConfigurationManager<OpenIdConnectConfiguration>(discoveryEndpoint, new OpenIdConnectConfigurationRetriever());

				var discoveryDocument = configManager.GetConfigurationAsync().Result;
				var securityKeys = discoveryDocument.SigningKeys.ToList();
				var validIssuer = discoveryDocument.Issuer;
				TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters(validIssuer, securityKeys);
				JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
				ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(authResult.IdToken, tokenValidationParameters, out SecurityToken validatedToken);
				Constants.DisplayInfoMessage("Id Token is valid!");
			}
			catch (Exception exc)
			{
				Constants.DisplayExceptionMessage(exc);
				tokenIsValid = false;
			}
			finally
			{
				Cursor.Current = Cursors.Arrow;
			}
			return tokenIsValid;
		}
		private TokenValidationParameters GetTokenValidationParameters(string issuer, List<SecurityKey> signingKeys)
		{
			var validationParameters = new TokenValidationParameters
			{
				RequireExpirationTime = true,
				RequireSignedTokens = true,
				ValidateIssuer = true,
				ValidIssuer = issuer,
				ValidateIssuerSigningKey = true,
				IssuerSigningKeys = signingKeys,
				ValidateLifetime = true,
				// Allow for some drift in server time
				// (a lower value is better; we recommend two minutes or less)
				ClockSkew = TimeSpan.FromMinutes(2),
				// See additional validation for aud below
				ValidateAudience = true,
				ValidAudience = _configuration.GetValue<string>("ClientId")
			};
			return validationParameters;
		}
	}
}
