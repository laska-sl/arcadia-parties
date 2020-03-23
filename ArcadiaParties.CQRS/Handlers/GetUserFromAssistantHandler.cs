using System.Net.Http;
using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using AutoMapper;
using ArcadiaParties.Data.Abstractions.DTOs;
using System.Text.Json;

namespace ArcadiaParties.CQRS.Handlers
{
    public class GetUserFromAssistantHandler : IRequestHandler<GetUserFromAssistantQuery, object>
    {
        private readonly ITokenForAssistantRepository _repo;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        public GetUserFromAssistantHandler(ITokenForAssistantRepository repo, IHttpClientFactory clientFactory, IMapper mapper)
        {
            _repo = repo;
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        public object UserFromAssistantDTO { get; set; }

        public async Task<object> Handle(GetUserFromAssistantQuery request, CancellationToken cancellationToken)
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
            
            return UserFromAssistantDTO;
           
        }
    }
}
