using ISP.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReadBranchDTO>>> GetAll()
        {
            var BranchList = await branchService.GetAll();
            return BranchList;
        }


        [HttpGet]
        [Route("{id}")]
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
     
        public async Task<ActionResult<ReadBranchDTO>> Add(WriteBranchDTO writeBranchDTO)
        {
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
         return CreatedAtAction(actionName: "GetById", routeValues: new { id = updateBranchDTO.Id }, value: "Updated Successfully");


        }

        [HttpDelete]
        public async Task<ActionResult<ReadBranchDTO>> Delete(DeleteBranchDTO deleteBranchDTO)
        {
            var Branchtodelete = await branchService.DeleteBranch(deleteBranchDTO);
            if (Branchtodelete == null)
            {
                return Problem(detail: "the object dees not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            return Branchtodelete;
        }




    }
}
