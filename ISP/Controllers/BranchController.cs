using ISP.BL;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    public class BranchController : CustomControllerBase
    {
        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<ReadBranchDTO>>> GetAll()
        {
            var BranchList = await branchService.GetAll();
            return BranchList;
        }


        [HttpGet]
        [Route("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<ReadBranchDTO> >GetById(int id)
        {
            var Branch = await branchService.GetById(id);
            if (Branch ==null)
            {
                return NotFound();
            }
            return Branch;
        }

        [HttpPost]
     
        public async Task<ActionResult<ReadBranchDTO>> Add( [Required] WriteBranchDTO writeBranchDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return  await branchService.AddBranch(writeBranchDTO);
        }




        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ReadBranchDTO>> Edit(int id , UpdateBranchDTO updateBranchDTO)
        {
            if (id !=updateBranchDTO.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

             await branchService.UpdateBranch(id, updateBranchDTO);

            return NoContent(); 
            // return CreatedAtAction(actionName: "GetById", routeValues: new { id = updateBranchDTO.Id }, 
               //  value: "Updated Successfully");


        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ReadBranchDTO>> Delete(int id)
        {
            var getBranch = await branchService.DeleteBranch(id);
            if (getBranch == null)
            {
                return Problem(detail: "the object dees not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }           
            return getBranch;
        }




    }
}
