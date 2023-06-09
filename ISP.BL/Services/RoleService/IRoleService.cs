﻿using ISP.BL.Dtos.Role;

namespace ISP.BL.Services.RoleService
{
    public interface IRoleService 
    {
        Task<ReadRoleDto?> GetById(int id);
        string GetRoleNameByID(int id);
        Task<ReadRoleDto> Insert(WriteRoleDto writeRoleDto);
        Task<List<ReadRoleDto>> GetAll();
        Task<ReadRoleDto> Update(int id, UpdateRoleDto updateRoleDto);
        Task<ReadRoleDto> Delete( DeleteRoleDto deleteRoleDto);

    }
}
