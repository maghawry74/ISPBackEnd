
namespace ISP.DAL.Repository.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public Task<Role?> GetByID(string id);
        public Task<string?> GetByName(string id);
    }
}
