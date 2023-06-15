using ISP.BL.Dtos.Permission;

namespace ISP.BL.Services.RolePermissionsService
{
    public interface IRolePermissionService
    {
        public Task<ReadPermissions> GetPermissionByRoleId(string roleId);

        public Task UpdatePermissionsOfRole(ReadPermissions readPermissions);
        public Task<bool> CreatePermissionsToRole(List<string> claimsList, string roleName);
    }
}
