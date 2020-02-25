using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcadiaParties.Data.Models;
using Newtonsoft.Json;

namespace ArcadiaParties.Data.Data
{
    public class Seed : ISeed
    {
        public async Task SeedData(DataContext context)
        {
            if (!context.Department.Any())
            {
                var departmentData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/Depart.json");
                var departments = JsonConvert.DeserializeObject<List<Department>>(departmentData);
                await context.Department.AddRangeAsync(departments);
                await context.SaveChangesAsync();
            }

            if (!context.Roles.Any())
            {
                var roleData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/RoleSeed.json");
                var roles = JsonConvert.DeserializeObject<List<Role>>(roleData);
                await context.Roles.AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserSeed.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

            if (!context.UserRole.Any())
            {
                var userRoleData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserRole.json");
                var usersRoles = JsonConvert.DeserializeObject<List<UserRole>>(userRoleData);
                await context.UserRole.AddRangeAsync(usersRoles);
                await context.SaveChangesAsync();
            }
        }
    }
 }
