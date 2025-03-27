using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Medical.Model.Options.Security;
using System.Diagnostics;
using System.Security;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The key vault registration class
    /// </summary>
    public static class KeyVaultRegistration
    {
        
        /// <summary>
        /// Registers the key vault using the specified config manager
        /// </summary>
        /// <param name="configManager">The config manager</param>
        /// <returns>The config manager</returns>
        public static ConfigurationManager RegisterKeyVault(this ConfigurationManager configManager)
        {
            var keyVaultName = configManager.GetValue<string>("AzureKeyVault:Name");
            if (string.IsNullOrEmpty(keyVaultName))
                return configManager;

            var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");

            var client = new SecretClient(new Uri(keyVaultUri.AbsoluteUri), new DefaultAzureCredential());
            Trace.TraceInformation($"Fetching a secret in {keyVaultName} called '{client.GetSecret("AzureAdN--TenantId").Value.Value}' with the value '{client.GetSecret("AzureAdN--ClientId").Value.Value}' .... '{client.GetSecret("AzureAdN--ClientSecret").Value.Value}' ...");
            ClientSecretCredential credentials = new(client.GetSecret("AzureAdN--TenantId").Value.Value, client.GetSecret("AzureAdN--ClientId").Value.Value, client.GetSecret("AzureAdN--ClientSecret").Value.Value);
            configManager.AddAzureKeyVault(keyVaultUri, credentials);

            return configManager;
        }
    }
}
