using AutoMapper;
using ISP.BL.Dtos.Bill;
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

        public IEnumerable<ReadBillDTO> getClientBills(string Ssid, bool condition)
        {
            var bill_list_fromdb = billRepository.getClientBills(Ssid , condition);

            return mapper.Map<List<ReadBillDTO>>(bill_list_fromdb);
        }

        public ReadBillDTO? GetNextMonthBill(int Nmonth, int ClientId)
        {
            var billfromdb =  billRepository.GetNextMonthBill(Nmonth, ClientId);
            return mapper.Map<ReadBillDTO>(billfromdb);
        }

        public IEnumerable<ReadBillwithClientDTO> GetNopaid_bilist()
        {
            var billfromdb = billRepository.GetNopaid_bilist();
            return mapper.Map<List<ReadBillwithClientDTO>>(billfromdb);
        }

        public void paidBill(int id)
        {
            billRepository.paidBill(id);
        }
    }
}
