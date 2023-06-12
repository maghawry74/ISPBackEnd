
namespace ISP.DAL.Repository.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        string GetRoleNameByID(string id);
    }
}
