using ISP.BL;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ISP.API.Controllers
{
    public class PackageController : CustomControllerBase
    {
        private readonly IPackageService PackageService;
        public PackageController(IPackageService PackageService)
        {
            this.PackageService = PackageService;
        }
        [HttpGet]

        public async Task<ActionResult<List<ReadPackageDTO>>> GetAll()
        {
            var PackageList = await PackageService.GetAll();
            return PackageList;
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ReadPackageDTO>> GetById(int id)
        {
            var Package= await PackageService.GetById(id);
            if (Package == null)
            {
                return NotFound();
            }
            return Package;
        }


        [HttpPost]

        public async Task<ActionResult<ReadPackageDTO>> Add([Required] WritePackageDTO writePackageDTO)
        {
            
            return await PackageService.AddPackage(writePackageDTO);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ReadPackageDTO>> Edit(int id, UpdatePackageDTO updatePackageDTO)
        {
            if (id != updatePackageDTO.Id)
            {
                return Problem(detail: "the object To Edit dees not exsits", statusCode: 404,
                   title: "error", type: "null reference");
            }

            await PackageService.UpdatePackage(id, updatePackageDTO);
            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadPackageDTO>> Delete(int id)
        {
            var Packagetodelete = await PackageService.DeletePackage(id);
            if (Packagetodelete == null)
            {
                return Problem(detail: "the object dees not exsits", statusCode: 404,
                    title: "error", type: "null reference");
            }
            return Packagetodelete;
        }

    }
}
