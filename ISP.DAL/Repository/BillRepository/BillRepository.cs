using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class BillRepository : IBillRepository
    {
        private readonly ISPContext context;

        public BillRepository(ISPContext context)
        {
            this.context = context;
        }
        public int BillGenerationSP()
        {
            var bill = context.Database.ExecuteSqlRaw("sp_generateBills");
            return bill;
        }
    }
}
