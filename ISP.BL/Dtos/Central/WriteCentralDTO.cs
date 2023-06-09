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
        [StringLength(50 , ErrorMessage = "name of Central must not exceed 50 characters")]
        public required string Name { get; set; } = string.Empty;
        public required int GovernarateCode { get; set; }
    }
}
