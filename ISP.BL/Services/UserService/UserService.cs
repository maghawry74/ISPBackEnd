using ISP.BL.Dtos.Users;
using ISP.DAL;
using ISP.DAL.Repository.UserRepository;
using Microsoft.AspNetCore.Identity;

namespace ISP.BL.Services.UserPermissionsService
{
    public class UserService : IUserService
    {
       
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public UserService( IUserRepository userRepository, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
           
            this.userRepository = userRepository;  
            this.userManager = userManager;
            this.roleManager = roleManager;
           
        }


        public async Task<List<ReadUserDto>> GetAll()
        {
           
            var users = await userRepository.GetAllUsers();

            List<ReadUserDto> readUserDto = new List<ReadUserDto>();
            foreach (var user in users)
            {
                var getRoleName = userManager.GetRolesAsync(user).Result.FirstOrDefault();
                var role = await roleManager.FindByNameAsync(getRoleName);
                var roleClaims = await GetRoleClaims(role);

                ReadRoleByUser readRole = new ReadRoleByUser
                {
                    Id = role.Id,
                    Name = role.Name,
                    Claims = roleClaims
                };                    
                    

                readUserDto.Add(new ReadUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Branch = user.Branch,
                    Status = user.Status,
                    Role = readRole
                   
                });
            }

            return readUserDto;
        }

        public async Task<ReadUserDto> GetById( string id)
        {
            var user = await userManager.FindByIdAsync(id);    

         
            
                var getRoleName = userManager.GetRolesAsync(user).Result.FirstOrDefault();
                var role = await roleManager.FindByNameAsync(getRoleName);
                var roleClaims = await GetRoleClaims(role);

                ReadRoleByUser readRole = new ReadRoleByUser
                {
                    Id = role.Id,
                    Name = role.Name,
                    Claims = roleClaims
                };
   

            return new ReadUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Branch = user.Branch,
                Status = user.Status,
                Role = readRole

            };
        }

        public async Task<List<string>> GetRoleClaims(Role role)
        {
            var roleClaims = await roleManager.GetClaimsAsync(role);

            List<string> permissions = new List<string>();

            foreach (var permission in roleClaims)
                permissions.Add(permission.Value);

            return permissions;

        }
    }
}
