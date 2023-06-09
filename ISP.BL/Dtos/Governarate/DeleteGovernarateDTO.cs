using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class DeleteGovernarateDTO
    {
        public required int Code { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
