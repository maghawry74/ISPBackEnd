    using ISP.BL.Dtos.Users;
using ISP.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BL.Services.UserPermissionsService
{
    public interface IUserService
    {
        Task<List<ReadUserDto>> GetAll();
        Task <ReadUserDto> GetById(string id);
        Task<List<string>> GetRoleClaims(Role role);

        public int EmployeeCount();

        Task<Role> GetRole(User user);
        Task<bool> Update(string id, UpdateUserDto updateUserDto);
        Task<bool> Delete(string id);
        Task<int> UserRegister(RegisterDto registerDto);
        Task<TokenDto> Login(LoginDto loginData);
        Task<bool> CheckEmail(string email);

    }
}
