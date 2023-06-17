using AutoMapper;
using ISP.BL.Dtos.Role;
using ISP.BL.Services.RolePermissionsService;
using ISP.DAL;
using ISP.DAL.Repository.RoleRepository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ISP.BL.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;
        private readonly RoleManager<Role> roleManager;    
        private readonly IRolePermissionService rolePermissionService ;
        private readonly ISPContext context;
        public RoleService(IRoleRepository roleRepository, IMapper mapper, ISPContext context,
            RoleManager<Role> roleManager, IRolePermissionService rolePermissionService)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
            this.context = context;
            this.roleManager = roleManager;
            this.rolePermissionService = rolePermissionService;
        }

        public async Task<ReadRoleDto> Insert(string roleName)
        {
            var isExist = await roleManager.FindByNameAsync(roleName);
            if (isExist != null)
                return null;


            var role = new Role{Name = roleName};
           
            await roleManager.CreateAsync(role);       


            return mapper.Map<ReadRoleDto>(role);
        }

        public async Task<bool> CreateRoleClaims(WriteRoleDto writeRoleDto)
        {

            var role = await roleManager.FindByNameAsync(writeRoleDto.Name);
            if (role == null)
                return false;


            foreach (var claim in writeRoleDto.RolePermissions)
                await roleManager.AddClaimAsync(role, new Claim("Permission", claim));

            return true;
        }
        public async Task<List<ReadRoleDto>> GetAll()
        {        

            var rolesList = await roleRepository.GetAll();
            return mapper.Map<List<ReadRoleDto>>(rolesList);           
        }
       
        public async Task<ReadRoleDto?> GetRoleById(string id)
        {
            var roleDB = await roleRepository.GetByID(id);
            return  mapper.Map<ReadRoleDto>(roleDB);
        }

        public async Task<string?> GetRoleNameByID(string name)
        {
            var roleName = await roleRepository.GetByName(name);
            return roleName;
        }        

        public async Task<ReadRoleDto> Delete(string id)
        {
            var getRole = await roleManager.FindByIdAsync(id);
            if (getRole == null)
            {
                return null;
            }
            getRole.Status = false;
            await roleManager.UpdateAsync(getRole);
            
            return mapper.Map<ReadRoleDto>(getRole);

        }

        
    }
}
