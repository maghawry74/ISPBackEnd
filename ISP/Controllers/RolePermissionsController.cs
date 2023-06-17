using ISP.BL.Dtos.Permission;
using ISP.BL.Services.RolePermissionsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize(Permissions.RolePermissions.View)]
    public class RolePermissionsController : ControllerBase
    {
        private readonly IRolePermissionService rolePermissionService;
        public RolePermissionsController(IRolePermissionService rolePermissionService)
        {
            this.rolePermissionService = rolePermissionService; 
        }


        [HttpGet]
        [Route("{Id}")]
       // [Authorize(Permissions.RolePermissions.View)]
        public async Task<ActionResult<ReadRolePermissions>> GetRolePermissionsById(string Id)
        {
            var permissions = await rolePermissionService.GetPermissionByRoleId(Id);
            if (permissions == null)
            {
                return NotFound();
            }
            return Ok( permissions);
        }


        [HttpPut]
        //[Authorize(Permissions.RolePermissions.Edit)]
        public async Task<ActionResult> EditRolePermissions(ReadPermissions readPermissions)
        {
            await rolePermissionService.UpdatePermissionsOfRole(readPermissions);
            return Ok();
        }

        
    }
}
