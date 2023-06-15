using AutoMapper;
using ISP.BL.Dtos.Role;
using ISP.BL.Services.RolePermissionsService;
using ISP.DAL;
using ISP.DAL.Repository.RoleRepository;
using Microsoft.AspNetCore.Identity;

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

        public async Task<ReadRoleDto> Insert(WriteRoleDto writeRoleDto)
        {
            var isRoleExist = roleManager.FindByIdAsync(writeRoleDto.Name);
            if (isRoleExist != null)
                return null;

            var role = mapper.Map<Role>(writeRoleDto);
           
            await roleManager.CreateAsync(role);

            //Add Claims To Role 
            var isSeddedClaims = await rolePermissionService.CreatePermissionsToRole(writeRoleDto.RolePermissions,writeRoleDto.Name);

            if (!isSeddedClaims)
                return null;


            return mapper.Map<ReadRoleDto>(role);
        }

        public async Task<List<ReadRoleDto>> GetAll()
        {
            //RoleStore<Role> roleStore = new RoleStore<Role>(context);
            //RoleManager<Role> roleMngr = new RoleManager<Role>(roleStore); 
            //List<Role> roles = roleMngr.Roles.ToList();

            //return  mapper.Map<List<ReadRoleDto>>(roles);

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
