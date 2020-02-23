using System.Collections.Generic;
using System.Linq;
using ArcadiaParties.Data.Models;
using Newtonsoft.Json;


namespace ArcadiaParties.Data.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("../ArcadiaParties.Data/Data/UserSeed.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    context.Users.Add(user);
                }

                context.SaveChanges(); 
            }
        }

    }
}