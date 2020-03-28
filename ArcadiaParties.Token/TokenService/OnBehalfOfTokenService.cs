using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ArcadiaParties.Token
{
    public class OnBehalfOfTokenService : ITokenService
    {
        private const string assertionType = "urn:ietf:params:oauth:grant-type:jwt-bearer";

        public OnBehalfOfTokenService(string mainAppClientId, AzureAdConfiguration targetAppConfiguration, IHttpContextAccessor httpContextAccessor)
        {
            MainAppClientId = mainAppClientId;
            TargetAppConfiguration = targetAppConfiguration;
            HttpContextAccessor = httpContextAccessor;
        }

        private string MainAppClientId { get; }

        private AzureAdConfiguration TargetAppConfiguration { get; }

        private IHttpContextAccessor HttpContextAccessor { get; }

        public async Task<string> GetTokenAsync()
        {
            var accessToken = await HttpContextAccessor.HttpContext.GetTokenAsync("access_token");

            var userAssertion = new UserAssertion(accessToken, assertionType);

            var clientCredential = new ClientCredential(MainAppClientId, TargetAppConfiguration.ClientSecret);

            var authContext = new AuthenticationContext(TargetAppConfiguration.AuthorityUrl, new TokenCache());

            var result = await authContext.AcquireTokenAsync(TargetAppConfiguration.ClientId, clientCredential, userAssertion);

            return result.AccessToken;
        }
    }
}
