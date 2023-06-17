
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ISPContext context;

        public UserRepository(ISPContext Context) : base(Context)
        {
            context = Context;
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await context.Set<User>()
                .Include(a => a.Role)
                .Include(b => b.Branch)
                .ToListAsync();
        }


    }
}
