using System.Net.Http;
using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using ArcadiaParties.Data.Abstractions.DTOs;
using System.Text.Json;

namespace ArcadiaParties.CQRS.Handlers
{
    public class GetAssistantUserHandler : IRequestHandler<GetAssistantUserQuery, AssistantUserDTO>
    {
        private readonly IAssistantTokenRepository _repo;
        private readonly IHttpClientFactory _clientFactory;

        public GetAssistantUserHandler(IAssistantTokenRepository repo, IHttpClientFactory clientFactory)
        {
            _repo = repo;
            _clientFactory = clientFactory;
        }

        public async Task<AssistantUserDTO> Handle(GetAssistantUserQuery request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                "https://assistant.arcadia.spb.ru/api/user");

            var token = await _repo.GetToken();
            httpRequest.Headers.Add("Authorization", "Bearer " + token);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(httpRequest);
            var responseBody = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var userFromAssistantDTO = await JsonSerializer.DeserializeAsync<AssistantUserDTO>(responseBody, options);

            return userFromAssistantDTO;
        }
    }
}
