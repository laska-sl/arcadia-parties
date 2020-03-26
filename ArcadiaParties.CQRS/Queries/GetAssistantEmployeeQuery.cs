using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetAssistantEmployeeQuery : IRequest<AssistantEmployeeDTO>
    {
        public string EmployeeId { get; }

        public GetAssistantEmployeeQuery(string employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
