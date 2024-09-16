using Microsoft.AspNetCore.Identity;
using ProductsManager.Models;

namespace ProductsManager
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var admin = new ApplicationUser
            {
                UserName = "admin@productmgr.com",
                Email = "admin@productmgr.com"
            };

            string adminPassword = "Admin@123";
            var user = await userManager.FindByEmailAsync("admin@productmgr.com");

            if (user == null)
            {
                var createAdmin = await userManager.CreateAsync(admin, adminPassword);
                if (createAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
