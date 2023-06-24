﻿using ISP.BL.Dtos.Users;
using ISP.DAL;
using Microsoft.AspNetCore.Mvc;

namespace ISP.BL.Services.UserPermissionsService
{
    public interface IUserService
    {
        Task<List<ReadUserDto>> GetAll();
        Task <ReadUserDto> GetById(string id);
        Task<List<string>> GetRoleClaims(Role role);
        Task<Role> GetRole(User user);
        Task<bool> Update(string id, UpdateUserDto updateUserDto);
        Task<bool> Delete(string id);
        Task<bool> UserRegister(RegisterDto registerDto);
        Task<TokenDto> Login(LoginDto loginData);

    }
}
