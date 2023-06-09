using ISP.BL.Dtos.Role;
using ISP.BL.Services.RoleService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<ReadRoleDto>>> GetAll()
        {
            return await roleService.GetAll();          
        }


        [HttpGet]
        [Route("{Id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ReadRoleDto>> GetById(int Id)
        {
            var getRole = await roleService.GetById(Id);
            if (getRole == null)
            {
                return NotFound();
            }
            return getRole;
        }

        [HttpPost]

        public async Task<ActionResult<ReadRoleDto>> Add([Required] WriteRoleDto writeRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await roleService.Insert(writeRoleDto);
        }




        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<ReadRoleDto>> Edit(int Id, UpdateRoleDto updateRoleDto)
        {
            if (Id != updateRoleDto.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await roleService.Update(Id, updateRoleDto);
            return CreatedAtAction(actionName: "GetById", routeValues: new { Id = updateRoleDto.Id }, 
                value: "Updated Successfully");


        }

        [HttpDelete]        
        public async Task<ActionResult<ReadRoleDto>> Delete( DeleteRoleDto deleteRoleDto)
        {
            var getRole = await roleService.Delete(deleteRoleDto);
            if (getRole == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }            
            return getRole;
        }

    }
}
