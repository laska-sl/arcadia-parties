namespace ArcadiaParties.API.Token
{
    public interface ITokenGetterFactory
    {
        ITokenService CreateTokenGetter(AzureApplication azureApplication);
    }
}