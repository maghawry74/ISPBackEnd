﻿using ISP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
   public class ReadCentralDTO
    {

        public required string Name { get; set; } = string.Empty;
       public required int GovernarateCode { get; set; }
     

    }
}