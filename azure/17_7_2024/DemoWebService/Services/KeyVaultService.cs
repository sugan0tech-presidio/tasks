using Azure.Security.KeyVault.Secrets;

namespace DemoWebService.Services;

public class KeyVaultService(SecretClient secretClient)
{
    public async Task<string> GetSecretAsync(string secretName)
    {
        KeyVaultSecret secret = await secretClient.GetSecretAsync(secretName);
        return secret.Value;
    }
}
