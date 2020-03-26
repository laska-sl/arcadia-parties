using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using AutoMapper;
using MediatR;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDTO>>
    {
        private const string departmentsUrl = "https://assistant.arcadia.spb.ru/api/departments";
        private readonly IAssistantTokenRepository _tokenRepository;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public GetAllDepartmentsHandler(IAssistantTokenRepository tokenRepository, IHttpClientFactory clientFactory, IMapper mapper)
        {
            _tokenRepository = tokenRepository;
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDTO>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, departmentsUrl);

            var token = await _tokenRepository.GetToken();
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(httpRequest, cancellationToken);
            var responseBody = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var assistantDepartments = await JsonSerializer.DeserializeAsync<IEnumerable<AssistantDepartmentDTO>>(responseBody, options);
            var departmentToReturn = _mapper.Map<IEnumerable<DepartmentDTO>>(assistantDepartments);
            return departmentToReturn;
        }
    }
}
