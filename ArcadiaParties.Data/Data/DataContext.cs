using ArcadiaParties.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ArcadiaParties.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRole { get; set; }
    }
}