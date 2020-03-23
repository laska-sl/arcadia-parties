using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    class GetDetailedUserFromAssistantHandler : IRequestHandler<GetDetailedUserFromAssistantQuery, DetailedUserFromAssistantDTO>
    {
        private readonly ITokenForAssistantRepository _repo;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMediator _mediator;

        public GetDetailedUserFromAssistantHandler(ITokenForAssistantRepository repo, IMediator mediator, IHttpClientFactory clientFactory)
        {
            _repo = repo;
            _mediator = mediator;
            _clientFactory = clientFactory;
        }

        public DetailedUserFromAssistantDTO DetailedUserFromAssistantDTO { get; set; }

        public async Task<DetailedUserFromAssistantDTO> Handle(GetDetailedUserFromAssistantQuery request, CancellationToken cancellationToken)
        {
            var query = new GetUserFromAssistantQuery();
            var user = await _mediator.Send(query, cancellationToken);
            var employeeId  = user.employeeId;

            var httpRequest = new HttpRequestMessage(
            HttpMethod.Get,
            "https://assistant.arcadia.spb.ru/api/employees/" + employeeId );

            var token = await _repo.GetToken();
            httpRequest.Headers.Add("Authorization", "Bearer " + token);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(httpRequest);

            Stream responseBody = await response.Content.ReadAsStreamAsync();
            DetailedUserFromAssistantDTO = await JsonSerializer.DeserializeAsync<DetailedUserFromAssistantDTO>(responseBody);

            return DetailedUserFromAssistantDTO;

        }
    }
}
