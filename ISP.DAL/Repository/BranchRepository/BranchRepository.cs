using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Repository.BranchRepository
{
    public class BranchRepository : GenericRepository<Branch>,IBranchRepository
    {
        public BranchRepository(ISPContext Context) : base(Context)
        {
        }
    }
}
