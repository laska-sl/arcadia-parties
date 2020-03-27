namespace ArcadiaParties.Token
{
    public interface ITokenServiceFactory
    {
        ITokenService CreateTokenService(AzureApplication azureApplication);
    }
}