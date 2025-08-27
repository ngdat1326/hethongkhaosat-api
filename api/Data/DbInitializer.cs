using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Tạo tài khoản admin mặc định
            string adminEmail = "admin@example.com";
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var admin = new AppUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    FullName = "Administrator"
                };

                var result = await userManager.CreateAsync(admin, "Admin123$Secure");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
            else
            {
                // Nếu admin tồn tại rồi, đảm bảo vẫn được gán role
                var adminRoles = await userManager.GetRolesAsync(existingAdmin); // Renamed variable to avoid conflict
                if (!adminRoles.Contains("Admin"))
                {
                    await userManager.AddToRoleAsync(existingAdmin, "Admin");
                }
            }
        }
    }
}
