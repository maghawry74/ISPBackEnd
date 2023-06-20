using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class UpdateBranchDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;

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
<<<<<<< HEAD
        public string ManagerId{ get; set; } = string.Empty;
=======
        public  string? ManagerId{ get; set; } = string.Empty;
>>>>>>> 8309075f0b8a9b3c61d05e2515bcc78bcfd8302e
    }
}
