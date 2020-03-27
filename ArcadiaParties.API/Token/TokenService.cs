using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ArcadiaParties.API.Token
{
    public class TokenService : ITokenService
    {
        public TokenService(string mainAppClientId, AzureAdConfiguration targetAppConfiguration, IHttpContextAccessor httpContextAccessor)
        {
            MainAppClientId = mainAppClientId;
            TargetAppConfiguration = targetAppConfiguration;
            HttpContextAccessor = httpContextAccessor;
        }

        public string MainAppClientId { get; }

        public AzureAdConfiguration TargetAppConfiguration { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public async Task<string> GetTokenAsync()
        {
            var accessToken = await HttpContextAccessor.HttpContext.GetTokenAsync("access_token");

            string assertionType = "urn:ietf:params:oauth:grant-type:jwt-bearer";

            var userAssertion = new UserAssertion(accessToken, assertionType);

            var clientCredential = new ClientCredential(MainAppClientId, TargetAppConfiguration.ClientSecret);

            var authContext = new AuthenticationContext(TargetAppConfiguration.AuthorityUrl, new TokenCache());

            var result = await authContext.AcquireTokenAsync(TargetAppConfiguration.ClientId, clientCredential, userAssertion);

            return result.AccessToken;
        }
    }
}
