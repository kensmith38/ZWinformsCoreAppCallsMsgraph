using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;

namespace ZWinformsCoreAppCallsMsgraph
{
	public static class Program
	{
		public static IServiceProvider ServiceProvider { get; private set; }

		//private static IPublicClientApplication _clientApp;
		//public static IPublicClientApplication PublicClientApp { get { return _clientApp; } }
		public static IPublicClientApplication PublicClientApp;


		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			ApplicationConfiguration.Initialize();
			var host = CreateHostBuilder().Build();
			ServiceProvider = host.Services;
			// Ask the service provider for the configuration abstraction.
			IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

			// Below are the clientId (Application Id) of your app registration and the tenant information.
			// You have to replace:
			// - the content of ClientID with the Application Id for your app registration
			// - the content of Tenant by the information about the accounts allowed to sign-in in your application:
			//   - For Work or School account in your org, use your tenant ID, or domain
			//   - for any Work or School accounts, use `organizations`
			//   - for any Work or School accounts, or Microsoft personal account, use `common`
			//   - for Microsoft Personal account, use consumers
			//string ClientId = "ffe3d758-ae1b-432a-bed0-ee6b620fafbb"; // @ken: ZWin-App-calling-MsGraph
			//string Tenant = "102c0b7c-d569-4c68-b249-eb6cfc15a1cd";

			string ClientId = config.GetValue<string>("ClientId"); // @ken: ZWin-App-calling-MsGraph
			string TenantId = config.GetValue<string>("TenantId");

			PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
					.WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
				.WithDefaultRedirectUri()
				.Build();

			Application.Run(ServiceProvider.GetRequiredService<FormSignIn>());
		}

		/// <summary>
		/// Create a host builder to build the service provider
		/// </summary>
		static IHostBuilder CreateHostBuilder()
		{
			return Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					//services.AddSingleton<IGetNextNumber, MyGetNextNumber>();
					services.AddSingleton<IUserAuthStatus, UserAuthStatus>();
					services.AddTransient<FormSignIn>();
				});
		}
	}
}