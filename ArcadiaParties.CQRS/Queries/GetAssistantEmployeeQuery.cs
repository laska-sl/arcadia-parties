using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetAssistantEmployeeQuery : IRequest<AssistantEmployeeDTO>
    {
    }
}
