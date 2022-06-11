using Microsoft.AspNetCore.Identity;
using Wordle.Api.Data;

namespace Wordle.Api.Identity
{
    public static class IdentitySeed
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            await SeedRolesAsync(roleManager);

            // Seed Admin User
            await SeedAdminUserAsync(userManager);

            //Seed Old Master
            await SeedMasterAsync(userManager);

            //Seed Young Master
            await SeedYoungMasterAsync(userManager);

            //Seed Normie
            await SeedNormieAsync(userManager);
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Grant))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Grant));
            }
            if (!await roleManager.RoleExistsAsync(Roles.MasterOfTheUniverse))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.MasterOfTheUniverse));
            }
        }

        private static async Task SeedAdminUserAsync(UserManager<AppUser> userManager)
        {
            // Seed Admin User
            if (await userManager.FindByNameAsync("Admin@intellitect.com") == null)
            {
                AppUser user = new()
                {
                    UserName = "Admin@intellitect.com",
                    Email = "Admin@intellitect.com",
                    DOB = "12/24/2001",
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                    await userManager.AddToRoleAsync(user, Roles.Grant);
                }
            }
        }

        private static async Task SeedMasterAsync(UserManager<AppUser> userManager)
        {
            // Seed Of-Age Master User
            if (await userManager.FindByNameAsync("Master@intellitect.com") == null)
            {
                AppUser user = new()
                {
                    UserName = "Master@intellitect.com",
                    Email = "Master@intellitect.com",
                    DOB = "7/20/1969",
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);
                }
            }
        }

        private static async Task SeedYoungMasterAsync(UserManager<AppUser> userManager)
        {
            // Seed Young Master User
            if (await userManager.FindByNameAsync("Young@intellitect.com") == null)
            {
                AppUser user = new()
                {
                    UserName = "Young@intellitect.com",
                    Email = "Young@intellitect.com",
                    DOB = "8/22/2008"
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.MasterOfTheUniverse);
                }
            }
        }

        private static async Task SeedNormieAsync(UserManager<AppUser> userManager)
        {
            // Seed Normie User
            if (await userManager.FindByNameAsync("User@intellitect.com") == null)
            {
                AppUser user = new()
                {
                    UserName = "User@intellitect.com",
                    Email = "User@intellitect.com",
                    DOB = "9/11/1999"
                };

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd123").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Grant);
                }
            }
        }
    }
}
