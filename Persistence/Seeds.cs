using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seeds
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager){
            if(!userManager.Users.Any()){
                var users = new List<AppUser>
                {
                    new AppUser{
                        DisplayName = "Wesley",
                        UserName = "wesley",
                        Email = "wesley@test.com"
                    },
                    new AppUser{
                        DisplayName = "Ruben",
                        UserName = "ruben",
                        Email = "ruben@test.com"
                    },
                    new AppUser{
                        DisplayName = "Sten",
                        UserName = "sten",
                        Email = "sten@test.com"
                    },
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
                context.SaveChanges();
            }   
        }
    }
}