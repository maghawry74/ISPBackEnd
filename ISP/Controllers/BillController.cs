using ISP.API.Constants;
using ISP.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    [Authorize(Permissions.Bill.View)]
    public class BillController : CustomControllerBase
    {
        private readonly IBillService billService;

        public BillController(IBillService billService)
        {
            this.billService = billService;
        }


        [HttpGet]
        [Route("next-month-bill")]
        [Authorize(Permissions.Bill.View)]
        public IActionResult GetNextMonthBill([FromQuery(Name = "NMonth")] int NMonth,
            [FromQuery(Name = "clientId")] int clientId
            )
        {
            var billobj = billService.GetNextMonthBill(NMonth, clientId);
            return Ok(billobj);
        }

        [HttpPut]
        [Route("payBill/{id}")]
        [Authorize(Permissions.Bill.View)]
        public IActionResult payBill(int id)
        {
            billService.paidBill(id); 
            return NoContent();
        }


    }
        


   
}
