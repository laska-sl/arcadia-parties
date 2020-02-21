using Microsoft.EntityFrameworkCore;

namespace ArcadiaParties.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}