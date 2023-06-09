using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class ReadBranchDTO
    {
        
        public required string Name { get; set; } = string.Empty;
        public required string Address { get; set; } = string.Empty;


        public string Phone1 { get; set; } = string.Empty;

        public string Phone2 { get; set; } = string.Empty;

        public string Mobile1 { get; set; } = string.Empty;

        public string Mobile2 { get; set; } = string.Empty;

        public int? Fax { get; set; }
        public required string ManagerId { get; set; } = string.Empty;

 
    }
}
