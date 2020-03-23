using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetAssistantUserQuery : IRequest<UserAssistantDTO>
    {
    }
}
