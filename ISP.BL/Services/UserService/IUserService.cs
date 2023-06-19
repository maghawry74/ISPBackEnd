using ISP.BL.Dtos.Users;
using ISP.DAL;

namespace ISP.BL.Services.UserPermissionsService
{
    public interface IUserService
    {
        Task<List<ReadUserDto>> GetAll();
        Task<bool> SeedAdminClaimsAsync(string roleName);
        Task AddPermissionsClaimsAsync(string module, Role role);
        Task SuperAdminRegister();
    }
}
