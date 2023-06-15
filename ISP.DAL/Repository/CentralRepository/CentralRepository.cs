using ISP.DAL.Repository.CentralRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class CentralRepository : GenericRepository<Central>, ICentralRepository
    {
        private readonly ISPContext context;

        public CentralRepository(ISPContext Context) : base(Context)
        {
            context = Context;
        }

        public async Task<List<Central>> getAllCentralwithGovernarate()
        {
            return await context.Set<Central>().Include(a => a.Governarate).ToListAsync();
        }

        public async Task<Central?> GetBYNameAsync(string Name)
        {
            return await context.Set<Central>().FirstOrDefaultAsync(a => a.Name ==Name);
        }
    }
}
