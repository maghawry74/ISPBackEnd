using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [AllowAnonymous]
    public class BillController : CustomControllerBase
    {
        private readonly IBillService billService;

        public BillController(IBillService billService)
        {
            this.billService = billService;
        }


        [HttpGet]
        [Route("next-month-bill")]
        public IActionResult GetNextMonthBill([FromQuery(Name = "NMonth")] int NMonth,
            [FromQuery(Name = "clientId")] int clientId
            )
        {
            var billobj = billService.GetNextMonthBill(NMonth, clientId);
            return Ok(billobj);
        }

        [HttpPut]

        [Route("payBill/{id}")]
        public IActionResult payBill(int id)
        {
            billService.paidBill(id); 
            return NoContent();
        }


    }
        


   
}
