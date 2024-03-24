using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(SteamBot.Startup))]

namespace SteamBot
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton(sp =>
            {
                var keyVaultUrl = Environment.GetEnvironmentVariable("KeyVaultUrl");
                var credential = new DefaultAzureCredential();
                return new SecretClient(new Uri(keyVaultUrl), credential);
            });
        }
    }
}




