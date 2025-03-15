using Jobpost.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPost.API.Database
{
    public static class SeedUser
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var admin = await userManager.FindByNameAsync("admin@admin.com");

            if (admin == null)
            {
                admin = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    Id = Guid.NewGuid().ToString(),
                    LastName = "admin",
                    FirstName = "admin"
                };
                admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "Pass123$");

                var result = userManager.CreateAsync(admin).Result;

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(result.Errors.First().Description);
                }

            }
        }
    }
}
