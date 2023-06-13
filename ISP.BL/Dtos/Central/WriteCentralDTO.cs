using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class WriteCentralDTO
    {
        public required string Name { get; set; } = string.Empty;
        public required int GovernorateCode { get; set; }
    }
}
