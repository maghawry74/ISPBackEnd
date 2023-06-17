using ISP.BL.Dtos.Permission;
using ISP.BL.Dtos.Role;
using ISP.BL.Services.RolePermissionsService;
using ISP.BL.Services.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Permissions.Role.View)]
    //[AllowAnonymous]
    public class RoleController : ControllerBase
    {        

        private readonly IRoleService roleService;
        private readonly IRolePermissionService rolePermissionService;

        public RoleController(IRoleService roleService ,IRolePermissionService rolePermissionService) 
        {
            this.roleService = roleService;
            this.rolePermissionService = rolePermissionService;
           
        }

        [HttpPost]
        // [Authorize(Permissions.Role.Create)]
        [AllowAnonymous]
        public async Task<ActionResult<ReadRoleDto>> Add(WriteRoleDto writeRoleDto)
        {
            if (!ModelState.IsValid)            
                return BadRequest(ModelState);
            

            var isAddedRole = await roleService.Insert(writeRoleDto.Name);            

            if (isAddedRole == null)

                return Problem(detail: "Errror in Create Role", statusCode: 404,
                   title: "error", type: "null reference");



            var isAddedClaims = await roleService.CreateRoleClaims(writeRoleDto);

            if (!isAddedClaims)
                return Problem(detail: "Errror in Adding Claims to Role", statusCode: 404,
                  title: "error", type: "null reference");


            return Ok();
        }



        [HttpGet]
        //[Authorize(Permissions.Role.View)]
        //[Authorize]
        [Authorize(Roles = "SuperAdmin")]
        
        public async Task<ActionResult<List<ReadRoleDto>>> GetAll()
        {
            return await roleService.GetAll();
        }

             
        
        [HttpGet]
        [Route("{Id}")]
        //[Authorize(Permissions.Role.View)]
        public async Task<ActionResult<ReadRoleDto>> GetById(string Id)

        {
            var getRole = await roleService.GetRoleById(Id);
            if (getRole == null)
            {
                return NotFound();
            }
            return getRole;
        }


        [HttpGet]
        [Route("GetRoleName/{Id}")]
        //[Authorize(Permissions.Role.View)]
        public async Task<ActionResult<string>> GetRoleName(string Id)
        {
            var roleName = await roleService.GetRoleNameByID(Id);
            if (roleName == null)
            {
                return NotFound();
            }
            return roleName;
        }


        
        [HttpDelete("{id}")]
        //[Authorize(Permissions.Role.Delete)]
        public async Task<ActionResult<ReadRoleDto>> Delete( string id)
        {
            var getRole = await roleService.Delete(id);
            if (getRole == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }            
            return getRole;
        }



        [HttpGet]
        [Route("GetRolePermissionsById/{Id}")]
        // [Authorize(Permissions.RolePermissions.View)]
        public async Task<ActionResult<ReadRolePermissions>> GetRolePermissionsById(string Id)
        {
            var permissions = await rolePermissionService.GetPermissionByRoleId(Id);
            if (permissions == null)
            {
                return NotFound();
            }
            return Ok(permissions);
        }


        [HttpPut]
        [Route("EditRolePermissions")]
        //[Authorize(Permissions.RolePermissions.Edit)]
        public async Task<ActionResult> EditRolePermissions(ReadPermissions readPermissions)
        {
            await rolePermissionService.UpdatePermissionsOfRole(readPermissions);
            return Ok();
        }

    }
}
