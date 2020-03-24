using System.Net.Http;
using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaParties.Data.Abstractions.DTOs;
using System.Text.Json;
using System.Net.Http.Headers;

namespace ArcadiaParties.CQRS.Handlers
{
    public class GetAssistantUserHandler : IRequestHandler<GetAssistantUserQuery, AssistantUserDTO>
    {
        private const string requestUser = "https://assistant.arcadia.spb.ru/api/user";
        private readonly IAssistantTokenRepository _tokenRepository;
        private readonly IHttpClientFactory _clientFactory;

        public GetAssistantUserHandler(IAssistantTokenRepository tokenRepository, IHttpClientFactory clientFactory)
        {
            _tokenRepository = tokenRepository;
            _clientFactory = clientFactory;
        }

        public async Task<AssistantUserDTO> Handle(GetAssistantUserQuery request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, requestUser);

            var token = await _tokenRepository.GetToken();
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
