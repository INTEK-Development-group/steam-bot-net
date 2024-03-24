using System;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SteamBot
{
    public class Function1
    {

        private readonly SecretClient _secretClient;

        public Function1(SecretClient secretClient)
        {
            _secretClient = secretClient;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var secret = _secretClient.GetSecret("STEAM-API-TOKEN");
        }
    }
}
