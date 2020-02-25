using System.Threading;
using System.Threading.Tasks;
using ArcadiaParties.CQRS.Commands;
using ArcadiaParties.Data;
using ArcadiaParties.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArcadiaParties.CQRS.Handlers
{
    public class SeedHandler : IRequestHandler<SeedCommand>
    {
        private readonly DataContext _context;
        private readonly ISeed _seed;

        public SeedHandler(ISeed seed, DataContext context)
        {
            _context = context;
            _seed = seed;
        }
        
        public async Task<Unit> Handle(SeedCommand request, CancellationToken cancellationToken)
        {
            await _context.Database.MigrateAsync();
            await _seed.SeedData();
            return Unit.Value;
        }
    }
}