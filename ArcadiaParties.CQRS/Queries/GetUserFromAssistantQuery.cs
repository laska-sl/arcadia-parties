using MediatR;
using System.Net.Http;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetUserFromAssistantQuery :IRequest<HttpResponseMessage>
    {
    }
}
