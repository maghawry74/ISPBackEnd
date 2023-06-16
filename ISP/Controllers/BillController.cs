using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [AllowAnonymous]
    public class BillController : CustomControllerBase
    {
        private readonly IBillService billService;

        public BillController(IBillService billService )
        {
            this.billService = billService;
        }


        [HttpGet]
        [Route("{NMonth}/{clientId}")]
     
        public IActionResult GetNextMonthBill(int NMonth, int clientId)
        {
            var billobj  = billService.GetNextMonthBill(NMonth, clientId);
            return Ok(billobj);
        }


    }
        


   
}
