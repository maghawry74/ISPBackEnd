using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class WriteBranchDTO
    {
        public required string Name { get; set; } = string.Empty;

        public required string address { get; set; } = string.Empty;

        public string phone1 { get; set; } = string.Empty;

        public string phone2 { get; set; } = string.Empty;

        public string mobile1 { get; set; } = string.Empty;

        public string mobile2 { get; set; } = string.Empty;


       // public required ICollection<WritePhoneDto> Phones { get; set; } = new HashSet<WritePhoneDto>();
       // public required ICollection<WriteMobileDto> Mobiles { get; set; } = new HashSet<WriteMobileDto>();
        public int? Fax { get; set; }
        public required string ManagerId { get; set; } = string.Empty;
    }
}
