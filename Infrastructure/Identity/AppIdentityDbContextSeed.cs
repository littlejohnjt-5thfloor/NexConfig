using ApplicationCore.Constants;
using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            // Create roles
            await roleManager.CreateAsync(new IdentityRole(IdentityConstants.Roles.ADMINISTRATORS));

            var adminUserName = configuration["Identity:AdminUsername"];
            var adminPassword = configuration["Identity:AdminPassword"];
            if (string.IsNullOrEmpty(adminUserName) || string.IsNullOrEmpty(adminPassword))
                throw new AdminUserNotFoundException();

            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };

            await userManager.CreateAsync(adminUser, adminPassword);
            adminUser = await userManager.FindByNameAsync(adminUserName);

            await userManager.AddToRoleAsync(adminUser, IdentityConstants.Roles.ADMINISTRATORS);
        }
    }
}
