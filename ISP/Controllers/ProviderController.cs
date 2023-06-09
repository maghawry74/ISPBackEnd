using ISP.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
   
    public class ProviderController : CustomControllerBase
    {
        private readonly IProviderService providerService;

        public ProviderController(IProviderService providerService)
        {
            this.providerService = providerService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<ReadProviderDTO>>> GetAll()
        {
            var ProviderList = await providerService.GetAll();
            return ProviderList;
        }


        [HttpGet]
        [Route("{Id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ReadProviderDTO>> GetById(int Id)
        {
            var Provider= await providerService.GetById(Id);
            if (Provider == null)
            {
                return NotFound();
            }
            return Provider;
        }    


        [HttpPost]

        public async Task<ActionResult<ReadProviderDTO>> Add([Required] WriteProviderDTO writeProviderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await providerService.Insert(writeProviderDTO);
        }




        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<ReadProviderDTO>> Edit(int Id, UpdateProviderDTO updateProviderDTO)
        {
            if (Id != updateProviderDTO.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await providerService.Edit(Id, updateProviderDTO);
            return CreatedAtAction(actionName: "GetById", routeValues: new { Id = updateProviderDTO.Id }, value: "Updated Successfully");


        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<ReadProviderDTO>> Delete(int Id)
        {
            var getProvider = await providerService.GetById(Id);
            if (getProvider == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            var Providertodelete = await providerService.Remove(getProvider);
            return Providertodelete;
        }







    }
}
