using ISP.API.Constants;
using ISP.BL.Dtos.Permission;
using ISP.DAL;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ISP.BL.Services.RolePermissionsService
{
    public class RolePermissionService :IRolePermissionService
    {
        private readonly RoleManager<Role> roleManager;

        public RolePermissionService(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<ReadPermissions> GetPermissionByRoleId(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            var claims = roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allPermissions = Permissions.PermissionsList().Select(c => new ReadRolePermissions { Value = c }).ToList();

            foreach (var permission in allPermissions)
            {
                if (claims.Any(c => c == permission.Value)) 
                    permission.Selected = true;
            }


            return new ReadPermissions
            {
                RoleId = roleId,
                RoleName = role.Name,
                RolePermissions = allPermissions
            };
        }

        public async Task UpdatePermissionsOfRole(ReadPermissions readPermissions)
        {
            var role = await roleManager.FindByIdAsync(readPermissions.RoleId);
            var claims = roleManager.GetClaimsAsync(role).Result.ToList();

            
            foreach (var claim in claims)
                await roleManager.RemoveClaimAsync(role,claim);


            var selectedClaims = readPermissions.RolePermissions.Where(readPermissions => readPermissions.Selected).ToList();
            foreach (var claim in selectedClaims)
                await roleManager.AddClaimAsync(role, new Claim("Permission", claim.Value ));
           
        }

        public async Task<bool> CreatePermissionsToRole(List<string> claimsList, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
                return false;


            foreach (var claim in claimsList)
                await roleManager.AddClaimAsync(role, new Claim("Permission", claim));

            return true;
        }
    }
}
