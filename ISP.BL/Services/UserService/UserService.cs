using ISP.BL.Dtos.Users;
using ISP.DAL.Repository.UserRepository;

namespace ISP.BL.Services.UserPermissionsService
{
    public class UserService : IUserService
    {
       
        private readonly IUserRepository userRepository;
       
        public UserService( IUserRepository userRepository)
        {
           
            this.userRepository = userRepository;      
           
        }


        public async Task<List<ReadUserDto>> GetAll()
        {
           
            var users = await userRepository.GetAllUsers();

            List<ReadUserDto> readUserDto = new List<ReadUserDto>();
            foreach (var user in users)
            {
               var role = await userRepository.GetRoleNameByUserID(user.Id);
                readUserDto.Add(new ReadUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Branch = user.Branch?.Name ?? "",
                    Status = user.Status,
                    Role = role
                });
            }

            return readUserDto;
        }



    }
}
