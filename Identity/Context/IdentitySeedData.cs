using Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Identity.Context
{
    public class IdentitySeedData
    {
        public static async Task Seed(IdentityContext context, UserManager<AppUser> userManager)
        {
            if (context.Users.Any()) return;

            var users = new List<AppUser>
            {
                new AppUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = $"admin",
                    Email = "su@app.com",
                    Role = "admin",
                    AccountExpire = DateTime.Now.AddYears(200),

                },
                new AppUser
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    UserName = "janesmith",
                    Email = "jane@app.com",
                    Company = "EvilCorp",
                    Role = "guest",
                    AccountExpire = DateTime.Now.AddDays(5),
                },
                new AppUser
                {
                    FirstName = "Sonny",
                    LastName = "Bonds",
                    UserName = "sonnybonds",
                    Email = "sonny@app.com",
                    Company = "LAPD",
                    Role = "Guest",
                    AccountExpire= DateTime.Now.AddDays(-5),
                }
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Password123");
            }
        }
    }
}
