using ISP.BL.Dtos.Role;

namespace ISP.BL.Services.RoleService
{
    public interface IRoleService 
    {
        Task<ReadRoleDto?> GetRoleById(string id);
        public Task<string?> GetRoleNameByID(string id);
        Task<ReadRoleDto> Insert(WriteRoleDto writeRoleDto);
        Task<List<ReadRoleDto>> GetAll();      
        Task<ReadRoleDto> Delete( string id);

    }
}
