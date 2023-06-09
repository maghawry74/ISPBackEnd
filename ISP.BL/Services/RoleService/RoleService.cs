using AutoMapper;
using ISP.BL.Dtos.Role;
using ISP.DAL;
using ISP.DAL.Repository.BranchRepository;
using ISP.DAL.Repository.RoleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }
        public async Task<ReadRoleDto?> GetById(int id)
        {
            var roleDB =  roleRepository.GetByID(id);
            return  mapper.Map<ReadRoleDto>(roleDB);
        }

        public string GetRoleNameByID(int id)
        {
            var role = roleRepository.GetRoleNameByID(id);
            return role;
        }
    }
}
