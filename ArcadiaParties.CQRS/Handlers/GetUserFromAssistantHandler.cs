using System.Net.Http;
using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using ArcadiaParties.Data.Abstractions.DTOs;
using System.Text.Json;
using System;

namespace ArcadiaParties.CQRS.Handlers
{
    public class GetUserFromAssistantHandler : IRequestHandler<GetUserFromAssistantQuery, UserFromAssistantDTO>
    {
        private readonly ITokenForAssistantRepository _repo;
        private readonly IHttpClientFactory _clientFactory;

        public GetUserFromAssistantHandler(ITokenForAssistantRepository repo, IHttpClientFactory clientFactory)
        {
            _repo = repo;
            _clientFactory = clientFactory;
        }

        public UserFromAssistantDTO UserFromAssistantDTO { get; set; }

        public async Task<UserFromAssistantDTO> Handle(GetUserFromAssistantQuery request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(
            HttpMethod.Get,
            "https://assistant.arcadia.spb.ru/api/user");

            var token = await _repo.GetToken();
            httpRequest.Headers.Add("Authorization", "Bearer " + token);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(httpRequest);

            Stream responseBody = await response.Content.ReadAsStreamAsync();
            UserFromAssistantDTO = await JsonSerializer.DeserializeAsync<UserFromAssistantDTO>(responseBody);

            Console.WriteLine(UserFromAssistantDTO.employeeId);

            return UserFromAssistantDTO;
           
        }
    }
}
