using ArcadiaParties.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ArcadiaParties.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<CelebrationDate> CelebrationDates { get; set; }
    }
}