using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ArcadiaParties.API.Token
{
    public class TokenGetterFactory : ITokenGetterFactory
    {
        public TokenGetterFactory(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            HttpContextAccessor = httpContextAccessor;
        }

        public IConfiguration Configuration { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public ITokenService CreateTokenGetter(AzureApplication azureApplication)
        {
            var mainAppClientId = Configuration.GetSection("OAuth").Get<OAuthSettings>().ClientId;

            var targetAppSectionName = azureApplication switch
            {
                AzureApplication.ArcadiaAssistant => "ArcadiaAssistant",
                AzureApplication.ServiceDesk => "ServiceDesk",
                _ => throw new Exception("Invalid azure application"),
            };

            var targetAppConfiguration = Configuration.GetSection(targetAppSectionName).Get<AzureAdConfiguration>();

            return new TokenService(mainAppClientId, targetAppConfiguration, HttpContextAccessor);
        }
    }
}