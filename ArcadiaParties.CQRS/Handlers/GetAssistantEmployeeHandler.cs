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
    class GetAssistantEmployeeHandler : IRequestHandler<GetAssistantEmployeeQuery, AssistantEmployeeDTO>
    {
        private readonly IAssistantTokenRepository _token;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMediator _mediator;

        public GetAssistantEmployeeHandler(IAssistantTokenRepository token, IMediator mediator, IHttpClientFactory clientFactory)
        {
            _token = token;
            _mediator = mediator;
            _clientFactory = clientFactory;
        }

        public async Task<AssistantEmployeeDTO> Handle(GetAssistantEmployeeQuery request, CancellationToken cancellationToken)
        {
            var query = new GetAssistantUserQuery();
            var user = await _mediator.Send(query, cancellationToken);
            var employeeId = user.EmployeeId;

            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                "https://assistant.arcadia.spb.ru/api/employees/" + employeeId);

            var token = await _token.GetToken();
            httpRequest.Headers.Add("Authorization", "Bearer " + token);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(httpRequest);
            var responseBody = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var detailedUserFromAssistantDTO = await JsonSerializer.DeserializeAsync<AssistantEmployeeDTO>(responseBody, options);

            return detailedUserFromAssistantDTO;

        }
    }
}
