﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public interface IBillRepository: IGenericRepository<Bill>
    {
        int BillGenerationSP();
        Bill? GetNextMonthBill(int Nmonth , int ClientId);

        void paidBill(int id);
    }
}
