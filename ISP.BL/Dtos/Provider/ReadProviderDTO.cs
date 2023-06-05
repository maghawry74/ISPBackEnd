using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
   public class ReadProviderDTO
    {
      
        public required string Name { get; set; } = string.Empty;
        public required bool IsActive { get; set; } 
    }
}
