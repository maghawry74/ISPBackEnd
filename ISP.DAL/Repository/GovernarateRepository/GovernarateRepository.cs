using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL;

public class GovernarateRepository : GenericRepository<Governarate>, IGovernarateRepository
{
    private readonly ISPContext context;
    public GovernarateRepository(ISPContext Context) : base(Context)
    {
        this.context = Context;
    }

    public void Delete(Governarate governarate)
    {
        context.Remove(governarate);
    }
}
