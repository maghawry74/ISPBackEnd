using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class UpdateProviderDTO
    {
        public required int Id { get; set; }
        public  string Name { get; set; } = string.Empty;
        public  bool IsActive { get; set; }
    }
}
