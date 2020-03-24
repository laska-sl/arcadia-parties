using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    class GetAssistantEmployeeHandler : IRequestHandler<GetAssistantEmployeeQuery, AssistantEmployeeDTO>
    {
        private readonly IAssistantTokenRepository _tokenRepository;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMediator _mediator;

        public GetAssistantEmployeeHandler(IAssistantTokenRepository tokenRepository, IMediator mediator, IHttpClientFactory clientFactory)
        {
            _tokenRepository = tokenRepository;
            _mediator = mediator;
            _clientFactory = clientFactory;
        }

        const string requestEmployee = "https://assistant.arcadia.spb.ru/api/employees/";

        public async Task<AssistantEmployeeDTO> Handle(GetAssistantEmployeeQuery request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, requestEmployee + request.EmployeeId);

            var token = await _tokenRepository.GetToken();
            httpRequest.Headers.Add("Authorization", "Bearer " + token);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(httpRequest, cancellationToken);
            var responseBody = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var assistantEmployee = await JsonSerializer.DeserializeAsync<AssistantEmployeeDTO>(responseBody, options);

            return assistantEmployee;
        }
    }
}
