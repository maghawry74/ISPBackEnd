using ISP.API.Constants;
using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    [AllowAnonymous]
    
    public class CentralController : CustomControllerBase
    {
        private readonly ICentalService centalService;

        public CentralController(ICentalService centalService)
        {
            this.centalService = centalService;
        }


        [HttpGet]
        public async Task<ActionResult<List<ReadCentralDTO>>> GetAll()
        {
            var CentralList = await centalService.GetAll();
            return CentralList;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<ReadCentralDTO>>> GetAll()
        //{
        //    var CentralList = await centalService.GetAll();
        //    return CentralList;
        //}

        [HttpGet]
        [Route("getallwithgov")]
        public async Task<ActionResult<List<ReadCentralWithGovernarateDTO>>> getallwithgov()
        {
            var CentralList = await centalService.GetAllwithgov();
            return CentralList;
        }


        [HttpGet]
        [Route("{Id}")]

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

           return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadCentralDTO>> Delete(int id)
        {
            var getCentral = await centalService.Delete(id);            
            if (getCentral == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            
            return getCentral;
        }


    }
}
