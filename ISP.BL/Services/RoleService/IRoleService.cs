using ISP.BL.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL.Services.RoleService
{
    public interface IRoleService
    {
        Task<ReadRoleDto?> GetById(int id);
        string GetRoleNameByID(int id);
    }
}
