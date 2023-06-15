using AutoMapper;
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
        private readonly IMapper mapper;

        public BillService(IBillRepository billRepository  ,  IMapper mapper)
        {
            this.billRepository = billRepository;
            this.mapper = mapper;
        }

        public int BillGenerationSP()
        {
            
            return billRepository.BillGenerationSP();

        }

        public ReadBillDTO? GetNextMonthBill(int Nmonth, int ClientId)
        {
            var billfromdb =  billRepository.GetNextMonthBill(Nmonth, ClientId);
            return mapper.Map<ReadBillDTO>(billfromdb);
        }
    }
}
