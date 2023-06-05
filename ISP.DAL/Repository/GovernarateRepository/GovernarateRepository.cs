using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL;

public class GovernarateRepository : GenericRepository<Governarate>, IGovernarateRepository
{
    public GovernarateRepository(ISPContext Context) : base(Context)
    {
    }
}
