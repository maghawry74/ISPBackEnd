using ISP.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    
    public class GovernarateController : CustomControllerBase
    {
        private readonly IGovernarateService governarateService;

        public GovernarateController(IGovernarateService governarateService)
        {
            this.governarateService = governarateService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<ReadGovernarateDTO>>> GetAll()
        {
            var GovernarateList = await governarateService.GetAll();
            return GovernarateList;
        }


        [HttpGet]
        [Route("{Code}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ReadGovernarateDTO>> GetById(int Code)
        {
            var Governarate = await governarateService.GetById(Code);
            if (Governarate == null)
            {
                return NotFound();
            }
            return Governarate;
        }

        [HttpPost]

        public async Task<ActionResult<ReadGovernarateDTO>> Add([Required] WriteGovernarateDTO writeGovernarateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await governarateService.AddGovernarate(writeGovernarateDTO);
        }




        [HttpPut]
        [Route("{Code}")]
        public async Task<ActionResult<ReadGovernarateDTO>> Edit(int Code, UpdateGovernarateDTO updateGovernarateDTO)
        {
            if (Code != updateGovernarateDTO.Code)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await governarateService.UpdateGovernarate(Code, updateGovernarateDTO);
            return CreatedAtAction(actionName: "GetById", routeValues: new { Code = updateGovernarateDTO.Code }, value: "Updated Successfully");


        }

        [HttpDelete]
        public async Task<ActionResult<ReadGovernarateDTO>> Delete(DeleteGovernarateDTO deleteGovernarateDTO)
        {
            var Governaratetodelete = await governarateService.DeleteGovernarate(deleteGovernarateDTO);
            if (Governaratetodelete == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            return Governaratetodelete;
        }


    }
}
