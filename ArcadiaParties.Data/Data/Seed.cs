using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcadiaParties.Data.Models;
using Newtonsoft.Json;

namespace ArcadiaParties.Data.Data
{
    public class Seed : ISeed
    {
        private readonly DataContext _context;

        public Seed(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task SeedData()
        {
            if (!_context.Department.Any())
            {
                var departmentData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/Depart.json");
                var departments = JsonConvert.DeserializeObject<List<Department>>(departmentData);
                await _context.Department.AddRangeAsync(departments);
                await _context.SaveChangesAsync();
            }

            if (!_context.Roles.Any())
            {
                var roleData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/RoleSeed.json");
                var roles = JsonConvert.DeserializeObject<List<Role>>(roleData);
                await _context.Roles.AddRangeAsync(roles);
                await _context.SaveChangesAsync();
            }

            if (!_context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserSeed.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                await _context.Users.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }

            if (!_context.UserRole.Any())
            {
                var userRoleData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserRole.json");
                var usersRoles = JsonConvert.DeserializeObject<List<UserRole>>(userRoleData);
                await _context.UserRole.AddRangeAsync(usersRoles);
                await _context.SaveChangesAsync();
            }
        }
    }
 }
