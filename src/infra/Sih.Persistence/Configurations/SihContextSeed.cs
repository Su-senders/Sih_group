using Microsoft.AspNetCore.Identity;
using Sih.Entities.Administration;
using System.Linq;
using System.Threading.Tasks;

namespace Sih.Persistence.Configurations
{
    public static class SihContextSeed
    {
        public async static Task SihInitializer(UserManager<UserEntity> _userManager, RoleManager<IdentityRole> _roleManager, SihDbContext _context)
        {
            await SeedRolesAsync(_userManager, _roleManager);
            await SeedSuperAdminAsync(_userManager, _roleManager);
        }

        // Seed user an role
        public static async Task SeedRolesAsync(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Sih.Entities.Enums.MesEnums.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Sih.Entities.Enums.MesEnums.Roles.CommonUser.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Sih.Entities.Enums.MesEnums.Roles.AdminRoles.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Sih.Entities.Enums.MesEnums.Roles.AdminIdentity.ToString()));
        }
        public static async Task SeedSuperAdminAsync(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new UserEntity
            {
                UserName = "sihsuperadmin@gmail.com",
                Email = "sihsuperadmin@gmail.com",
                NomPrenom = "SIH",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Sih.Entities.Enums.MesEnums.Roles.SuperAdmin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Sih.Entities.Enums.MesEnums.Roles.CommonUser.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Sih.Entities.Enums.MesEnums.Roles.AdminRoles.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Sih.Entities.Enums.MesEnums.Roles.AdminIdentity.ToString());
                }
            }
        }
    }
}
