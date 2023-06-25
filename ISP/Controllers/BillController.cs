
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



        [HttpGet]
        [Route("NotpaidBill")]
        [Authorize(Permissions.Bill.View)]
        public IActionResult NotpaidBill()
        {
            var billlist = billService.GetNopaid_bilist().ToList();
            return Ok(billlist);
        }



        [HttpGet]
        [Route("ClientBills")]
        [Authorize(Permissions.Bill.View)]
        public IActionResult ClientBills([FromQuery(Name = "SSid")] string SSid,
            [FromQuery(Name = "Condition")] bool Condition)
        {
            var billlist = billService.getClientBills(SSid, Condition);
            return Ok(billlist);
        }


        [HttpPut]
        [Route("payBill/{id}")]
        [Authorize(Permissions.Bill.Edit)]
        public IActionResult payBill(int id)
        {
            billService.paidBill(id); 
            return NoContent();
        }


    }
        


   
}
