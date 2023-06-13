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
        // [ResponseCache(Duration = 60)]
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

            var updatedGovernarate = await governarateService.UpdateGovernarate(Code, updateGovernarateDTO);

            if (updatedGovernarate == null)
            {
                return NotFound();
            }

            return Ok(updatedGovernarate);
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult<ReadGovernarateDTO>> Delete(int code)
        {
            var getGovernarate = await governarateService.DeleteGovernarate(code);

            if (getGovernarate == null)
            {
                return Problem(detail: "the object does not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }

            return Ok(getGovernarate);
        }


    }
}
