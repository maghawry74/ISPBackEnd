using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Repository.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        string GetRoleNameByID(int id);
    }
}
