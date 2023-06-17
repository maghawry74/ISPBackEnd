using AutoMapper;
using ISP.API.Constants;
using ISP.BL.Dtos.Users;
using ISP.DAL;
using ISP.DAL.Repository.UserRepository;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ISP.BL.Services.UserPermissionsService
{
    public class UserService : IUserService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(RoleManager<Role> roleManager, IUserRepository userRepository, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }


        public async Task<List<ReadUserDto>> GetAll()
        {
           
            var users = await userRepository.GetAllUsers();
            return mapper.Map<List<ReadUserDto>>(users);
        }


        public async Task AddPermissionsClaimsAsync(string module, Role role)
        {
            var allPermissions = Permissions.GeneratePermissionsOfModule(module);
            var allClaims = await roleManager.GetClaimsAsync(role);

            foreach (var permission in allPermissions)
                if (!allClaims.Any(x => x.Type == "Permission" && x.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));

        }

       
        public async Task<bool> SeedAdminClaimsAsync(string roleName)
        {
            var getRole = await roleManager.FindByNameAsync(roleName);
            if (getRole == null)
                return false;

            var modules = Enum.GetValues(typeof(Permissions.PermissionsModuleName));
            
            foreach (var module in modules)
                await AddPermissionsClaimsAsync(module.ToString(), getRole);

            return true;

        }

      

    }
}
