using ISP.BL;
using ISP.BL.Dtos.Client;
using ISP.BL.Dtos.Role;
using ISP.BL.Services.RoleService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    public class ClientController : CustomControllerBase
    {
        private readonly IClientservice clientservice;

        public ClientController(IClientservice clientservice)
        {
            this.clientservice = clientservice;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<ReadClientDTO>>> GetAll()
        {
            var ClientList = await clientservice.GetAll();
            return ClientList;
        }


        [HttpGet]
        [Route("{SSn}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ReadClientDTO>> GetById(int SSn)
        {
            var client = await clientservice.GetById(SSn);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        [HttpPost]

        public async Task<ActionResult<ReadClientDTO>> Add([Required] WriteClientDTO writeClientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await clientservice.AddClient(writeClientDTO);
        }




        [HttpPut]
        [Route("{Code}")]
        public async Task<ActionResult<ReadClientDTO>> Edit(int SSn, UpdateClientDTO updateClientDTO)
        {
            if (SSn != updateClientDTO.SSn)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await clientservice.UpdateClient(SSn, updateClientDTO);
            return CreatedAtAction(actionName: "GetById", routeValues: new { SSn = updateClientDTO.SSn },
                value: "Updated Successfully");


        }



        [HttpDelete]
        public async Task<ActionResult<ReadClientDTO>> Delete(DeleteClientDto deleteClientDto)
        {
            var getClient = await clientservice.DeleteClient(deleteClientDto);

            if (getClient == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
           
            return getClient;
        }




    }
}
