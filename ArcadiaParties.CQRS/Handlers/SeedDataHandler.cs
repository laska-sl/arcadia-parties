using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.CQRS.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    public class SeedDataHandler : IRequestHandler<SeedDataQuery, SeedDataResponse>
    {
        public async Task<SeedDataResponse> Handle(SeedDataQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
