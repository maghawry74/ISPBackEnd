﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
   public interface IGovernarateRepository:IGenericRepository<Governarate>
    {
        public void Delete(Governarate governarate);
    }
}
