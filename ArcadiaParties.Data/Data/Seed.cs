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
        private const bool V = true;

        public async static Task<Boolean> SeedData(DataContext context)
        {
            if (!context.Department.Any())
            {
                var depData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/Depart.json");
                var deps = JsonConvert.DeserializeObject<List<Department>>(depData);
                foreach (var dep in deps)
                {
                    await context.Department.AddAsync(dep);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Roles.Any())
            {
                var roleData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/RoleSeed.json");
                var roles = JsonConvert.DeserializeObject<List<Role>>(roleData);
                foreach (var role in roles)
                {
                    await context.Roles.AddAsync(role);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserSeed.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.UserRole.Any())
            {
                var userroleData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserRole.json");
                var usersroles = JsonConvert.DeserializeObject<List<UserRole>>(userroleData);
                foreach (var ur in usersroles)
                {
                    await context.UserRole.AddAsync(ur);
                    await context.SaveChangesAsync();
                }
            }
            return true;
        }
    }
}