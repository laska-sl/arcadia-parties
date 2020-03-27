using System.Net.Http;
using ArcadiaParties.CQRS.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaParties.Data.Abstractions.DTOs;
using System.Text.Json;
using System.Net.Http.Headers;
using ArcadiaParties.Token;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetAssistantUserHandler : IRequestHandler<GetAssistantUserQuery, AssistantUserDTO>
    {
        private const string userUrl = "https://assistant.arcadia.spb.ru/api/user";
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenService _tokenService;

        public GetAssistantUserHandler(IHttpClientFactory clientFactory, ITokenServiceFactory tokenServiceFactory)
        {
            _clientFactory = clientFactory;
            _tokenService = tokenServiceFactory.CreateTokenService(AzureApplication.ArcadiaAssistant);
        }

        public async Task<AssistantUserDTO> Handle(GetAssistantUserQuery request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, userUrl);

            var token = await _tokenService.GetTokenAsync();
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(httpRequest, cancellationToken);
            var responseBody = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var assistantUser = await JsonSerializer.DeserializeAsync<AssistantUserDTO>(responseBody, options);
            return assistantUser;
        }
    }
}
