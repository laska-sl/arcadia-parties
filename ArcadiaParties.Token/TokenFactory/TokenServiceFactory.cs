using System;
using Microsoft.AspNetCore.Http;
using ArcadiaParties.Configuration;
using Microsoft.Extensions.Configuration;

namespace ArcadiaParties.Token
{
    public class TokenServiceFactory : ITokenServiceFactory
    {
        public TokenServiceFactory(IConfiguration configuration, OAuthSettings oAuthSettings, IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            OAuthSettings = oAuthSettings;
            HttpContextAccessor = httpContextAccessor;
        }

        public IConfiguration Configuration { get; }

        public OAuthSettings OAuthSettings { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public ITokenService CreateTokenService(AzureApplication azureApplication)
        {
            var mainAppClientId = OAuthSettings.ClientId;

            string targetAppSectionName;

            switch (azureApplication)
            {
                case AzureApplication.ArcadiaAssistant:
                    targetAppSectionName = "ArcadiaAssistant";
                    break;
                case AzureApplication.ServiceDesk:
                    targetAppSectionName = "ServiceDesk";
                    break;
                default:
                    throw new Exception("Invalid azure application");
            }

            var targetAppConfiguration = Configuration.GetSection(targetAppSectionName).Get<AzureAdConfiguration>();

            return new TokenService(mainAppClientId, targetAppConfiguration, HttpContextAccessor);
        }
    }
}