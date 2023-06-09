using ISP.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    
    public class CentralController : CustomControllerBase
    {
        private readonly ICentalService centalService;

        public CentralController(ICentalService centalService)
        {
            this.centalService = centalService;
        }

        [HttpGet]
        [ResponseCache(Duration =60)]
        public async Task<ActionResult<List<ReadCentralDTO>>> GetAll()
        {
            var CentralList = await centalService.GetAll();
            return CentralList;
        }


        [HttpGet]
        [Route("getallwithgov")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<ReadCentralWithGovernarateDTO>>> getallwithgov()
        {
            var CentralList = await centalService.GetAllWithGov();
            return CentralList;
        }


        [HttpGet]
        [Route("{Id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ReadCentralDTO>> GetById(int Id)
        {
            var Cental = await centalService.GetById(Id);
            if (Cental == null)
            {
                return NotFound();
            }
            return Cental;
        }



        [HttpGet]
        [Route("GetByName/{Name}")]

        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ReadCentralDTO>> GetByName(String Name)
        {
            var Cental = await centalService.GetByName(Name);
            if (Cental == null)
            {
                return NotFound();
            }
            return Cental;
        }


        [HttpPost]

        public async Task<ActionResult<ReadCentralDTO>> Add([Required] WriteCentralDTO writeCentralDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await centalService.Insert(writeCentralDTO);
        }




        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult<ReadCentralDTO>> Edit(int Id, UpdateCentralDTO updateCentralDTO)
        {
            if (Id != updateCentralDTO.Id) { 
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await centalService.Edit(Id, updateCentralDTO);
            return CreatedAtAction(actionName: "GetById", routeValues: new { Id = updateCentralDTO.Id}, value: "Updated Successfully");


        }

        [HttpDelete]
     
        public async Task<ActionResult<ReadCentralDTO>> Delete(DeleteCentralDTO deleteCentralDTO)
        {
            var getCentral = await centalService.Delete(deleteCentralDTO);            
            if (getCentral == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            
            return getCentral;
        }
    }
}
