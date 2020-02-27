using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<string>>
    {
        private readonly DataContext _context;

        public GetUserRolesHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<string>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Identity == request.UserIdentity);

            var userRoles = user.UserRoles.Select(userRole => userRole.Role.Name);

            return userRoles;
        }

    }
}
