using AutoMapper;
using ISP.API.Constants;
using ISP.BL.Dtos.Users;
using ISP.DAL;
using ISP.DAL.Repository.UserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ISP.BL.Services.UserPermissionsService
{
    public class UserService : IUserService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        private readonly IMapper mapper;
        public UserService(RoleManager<Role> roleManager, IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.userManager = userManager;
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

        public async Task SuperAdminRegister()
        {
            var user = new User
            {
                UserName ="Reem",
                Email = "reem12@gmail.com",
                PhoneNumber = "01278689712",
                EmailConfirmed = true,
                BranchId = null,
                Status = true

            };
                  
            //Create User
          await userManager.CreateAsync(user, "reem123Yasser");            


            //Add Role To User
          await userManager.AddToRoleAsync(user, "SuperAdmin");
            


            
        }

    }
}
