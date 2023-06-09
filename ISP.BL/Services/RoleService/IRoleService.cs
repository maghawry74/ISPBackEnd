using ISP.BL.Dtos.Role;

namespace ISP.BL.Services.RoleService
{
    public interface IRoleService
    {
        Task<ReadRoleDto?> GetById(int id);
        string GetRoleNameByID(int id);
    }
}
