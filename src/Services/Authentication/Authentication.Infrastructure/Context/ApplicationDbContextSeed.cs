using Authentication.Domain;
using Authentication.Domain.Entities;
using Authentication.Domain.Enums;
using Microsoft.AspNetCore.Identity;


namespace Authentication.Infrastructure.Context
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,ApplicationDbContext applicationDbContext)
        {
            //Seed Roles
            if (!applicationDbContext.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Role.Administrator.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Role.User.ToString()));
            }
            //Seed Default User
            var defaultUser = new ApplicationUser { UserName = Authorization.default_username, Email = Authorization.default_email, EmailConfirmed = true, PhoneNumberConfirmed = true, FirstName = Authorization.default_firstname, LastName = Authorization.default_lastname, PhoneNumber = Authorization.default_phonenumber };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, Authorization.default_password);
                await userManager.AddToRoleAsync(defaultUser, Authorization.default_role.ToString());

            }
        }
    }
}
