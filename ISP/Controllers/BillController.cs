using Hangfire;
using ISP.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers
{
    
    public class BillController : CustomControllerBase
    {
        private readonly IBillService billService;

        public BillController(IBillService billService )
        {
            this.billService = billService;
        }

        [HttpPost]
        public IActionResult ScheduleJob()
        {
            RecurringJob.AddOrUpdate("MyJob", () => billService.BillGenerationSP(), "35 18 * * *");
            return Ok();
        }


    }
}
