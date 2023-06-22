﻿using ISP.BL.Dtos.Users;
using ISP.DAL;

namespace ISP.BL.Services.UserPermissionsService
{
    public interface IUserService
    {
        Task<List<ReadUserDto>> GetAll();
        
    }
}
