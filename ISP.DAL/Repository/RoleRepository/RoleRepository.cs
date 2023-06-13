
namespace ISP.DAL.Repository.RoleRepository
{
    public class RoleRepository : GenericRepository<Role> , IRoleRepository
    {
        private readonly ISPContext context;      
        public RoleRepository(ISPContext Context) : base(Context)
        {
            this.context = Context;
        }

        public string GetRoleNameByID(string id)
        {
            //var getRole = context.Set<Role>().Find(id);
            //return getRole.Name;
            return ("reem"); 

        }
    }
}
