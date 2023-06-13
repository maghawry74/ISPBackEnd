using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class BillService : IBillService
    {
        private readonly IBillRepository billRepository;

        public BillService(IBillRepository billRepository)
        {
            this.billRepository = billRepository;
        }

        public int BillGenerationSP()
        {
            
            return billRepository.BillGenerationSP();


        }
    }
}
