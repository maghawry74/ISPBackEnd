using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ISPContext Context) : base(Context)
        {
        }
    }
}
