
using ISP.API.Constants;
using ISP.DAL;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static ISP.API.Helpers.Helper;

namespace ISP.BL.Services.UserPermissionsService
{
    public class UserPermissionsService : IUserPermissionsService
    {
        private readonly RoleManager<Role> roleManager;
        public UserPermissionsService(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }



        public async Task<bool> SeedClaimsAsync(string roleName)
        {
            var adminRole = await roleManager.FindByNameAsync(roleName);
            if (adminRole == null)
                return false;

            var modules = Enum.GetValues(typeof(PermissionsModuleName));
            foreach (var module in modules)
                await AddPermissionsClaimsAsync(module.ToString(), adminRole);

            return true;

        }




        public async Task AddPermissionsClaimsAsync(string module, Role role)
        {
            var allPermissions = Permissions.GeneratePermissionsOfModule(module);
            var allClaims = await roleManager.GetClaimsAsync(role);

            foreach (var permission in allPermissions)
                if (!allClaims.Any(x => x.Type == "Permission" && x.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));

        }
    }
}
