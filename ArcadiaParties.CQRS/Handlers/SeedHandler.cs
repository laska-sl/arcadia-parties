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
        public SeedHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(SeedCommand request, CancellationToken cancellationToken)
        {
            await _context.Database.MigrateAsync();
            await Seed.SeedData(_context);
            return Unit.Value;
        }
    }
}