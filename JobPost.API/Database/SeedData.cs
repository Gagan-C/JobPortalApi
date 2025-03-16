using Jobpost.API.Model;
using Microsoft.AspNetCore.Identity;

namespace JobPost.API.Database
{
    public static class SeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await AddDefaultRolesIfNotExistAsync(roleManager);

            var initUserData = new List<(string Email, string Role, string Name)> {
                    ("admin@admin.com", Constants.Cons.getAdminRole(), "Admin"),
                    ("employer@emp.com", Constants.Cons.getEmployerRole(), "Employer"),
                    ("employee@emp.com", Constants.Cons.getEmployeeRole(), "Employee")
            };
            foreach (var userData in initUserData)
            {
                await AddUserIfNotExistAsync(userManager, roleManager, userData.Email, userData.Name, userData.Role);
            }

        }
        public static async Task AddDefaultRolesIfNotExistAsync(RoleManager<IdentityRole> roleManager)
        {
            
            foreach( var role in Constants.Cons.Roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            
        }
        public static async Task AddUserIfNotExistAsync(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            string userEmail,
            string userFirstName,
            string userRole,
            string userPassword="Pass123$")
        {
            var existingUser = await userManager.FindByNameAsync(userEmail);
            if (existingUser == null)
            {
                var newUser = new User
                {
                    UserName = userEmail,
                    Email = userEmail,
                    EmailConfirmed = true,
                    Id = Guid.NewGuid().ToString(),
                    LastName = "TestUser",
                    FirstName = userFirstName
                };

                var result = await userManager.CreateAsync(newUser, userPassword);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(result.Errors.First().Description);
                }
                if(!await roleManager.RoleExistsAsync(userRole))
                {
                    throw new InvalidDataException(userRole);
                }
                await userManager.AddToRoleAsync(newUser, userRole);
            }

        }
    }
}
