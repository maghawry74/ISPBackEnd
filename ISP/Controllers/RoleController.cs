using AutoMapper;
using ISP.BL.Dtos.Role;
using ISP.BL.Services.RoleService;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {        

        private readonly IRoleService roleService;
       
        public RoleController(IRoleService roleService) 
        {
            this.roleService = roleService;
           
        }

        [HttpPost]
        public async Task<ActionResult<ReadRoleDto>> Add(WriteRoleDto writeRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isAdded = await roleService.Insert(writeRoleDto);
            if (isAdded == null) 
                return BadRequest();

            return Ok(isAdded);
        }



        [HttpGet]       
        public async Task<ActionResult<List<ReadRoleDto>>> GetAll()
        {
            return await roleService.GetAll();
        }

             
        
        [HttpGet]
        [Route("{Id}")]
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

    }
}
