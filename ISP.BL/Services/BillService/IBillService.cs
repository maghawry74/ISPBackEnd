using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public interface IBillService
    {
        int BillGenerationSP();
        ReadBillDTO? GetNextMonthBill(int Nmonth, int ClientId);
        void paidBill(int id);
    }
}
