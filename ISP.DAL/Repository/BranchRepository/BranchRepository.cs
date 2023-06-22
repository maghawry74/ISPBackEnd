using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Repository.BranchRepository
{
    public class BranchRepository : GenericRepository<Branch>,IBranchRepository
    {
        private readonly ISPContext Context;
        public BranchRepository(ISPContext Context) : base(Context)
        {
            this.Context = Context;
        }
        public new async Task<IEnumerable<Branch>> GetAll()
        {
            return await Context.Set<Branch>().Include(b=>b.Manager)
                .ToListAsync();
        }
        //public new async Task<Package?> GetByID(int id)
        //{
        //    return await Context.Set<Package>().Include(P => P.Provider).FirstOrDefaultAsync(p => p.Id == id);
        //}

    }
}
