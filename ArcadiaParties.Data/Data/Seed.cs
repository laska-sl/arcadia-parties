using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcadiaParties.Data.Models;
using Newtonsoft.Json;

namespace ArcadiaParties.Data.Data
{
    public class Seed
    {
        public async static Task<Boolean> SeedData(DataContext context)
        {
            if (!context.Department.Any())
            {
                var depData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/Depart.json");
                var deps = JsonConvert.DeserializeObject<List<Department>>(depData);
                await context.Department.AddRangeAsync(deps);
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
                var userroleData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserRole.json");
                var usersroles = JsonConvert.DeserializeObject<List<UserRole>>(userroleData);
                await context.UserRole.AddRangeAsync(usersroles);
                await context.SaveChangesAsync();
            }
            
            return true;
        }
    }
}