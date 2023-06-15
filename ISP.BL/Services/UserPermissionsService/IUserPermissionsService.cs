﻿using ISP.DAL;

namespace ISP.BL.Services.UserPermissionsService
{
    public interface IUserPermissionsService
    {
        public Task<bool> SeedClaimsAsync(string roleName);
        public Task AddPermissionsClaimsAsync(string module, Role role);
    }
}
