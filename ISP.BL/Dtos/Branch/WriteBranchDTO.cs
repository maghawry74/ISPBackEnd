using ISP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class WriteBranchDTO
    {
        [StringLength(50)]
        public required string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public required string address { get; set; } = string.Empty;
        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string phone1 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string phone2 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string mobile1 { get; set; } = string.Empty;
        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string mobile2 { get; set; } = string.Empty;

        public int? Fax { get; set; }
        public required string ManagerId { get; set; } = string.Empty;
    }
}
