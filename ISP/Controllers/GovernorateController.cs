using ISP.BL;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
<<<<<<< HEAD:ISP/Controllers/GovernarateController.cs
    // [Authorize(Permissions.Governarate.View)]
    public class GovernarateController : CustomControllerBase
=======
    
    public class GovernorateController : CustomControllerBase
>>>>>>> b79b305d4ebb83e64f14a0e7a74aa6b3756e6a20:ISP/Controllers/GovernorateController.cs
    {
        private readonly IGovernarateService governarateService;

        public GovernorateController(IGovernarateService governarateService)
        {
            this.governarateService = governarateService;
        }

        [HttpGet]
      //  [Authorize(Permissions.Governarate.View)]

        public async Task<ActionResult<List<ReadGovernarateDTO>>> GetAll()
        {
            var GovernarateList = await governarateService.GetAll();
            return GovernarateList;
        }


        [HttpGet]
        [Route("{Code}")]
        //[Authorize(Permissions.Governarate.View)]
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
       // [Authorize(Permissions.Governarate.Create)]
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
        //[Authorize(Permissions.Governarate.Edit)]
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
       // [Authorize(Permissions.Governarate.Delete)]
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
