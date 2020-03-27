﻿using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Token;
using MediatR;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetAssistantEmployeeHandler : IRequestHandler<GetAssistantEmployeeQuery, AssistantEmployeeDTO>
    {
        private const string employeesUrl = "https://assistant.arcadia.spb.ru/api/employees/";
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenService _tokenService;

        public GetAssistantEmployeeHandler(IHttpClientFactory clientFactory, ITokenServiceFactory tokenServiceFactory)
        {
            _clientFactory = clientFactory;
            _tokenService = tokenServiceFactory.CreateTokenService(AzureApplication.ArcadiaAssistant);
        }

        public async Task<AssistantEmployeeDTO> Handle(GetAssistantEmployeeQuery request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, employeesUrl + request.EmployeeId);

            var token = await _tokenService.GetTokenAsync();
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
