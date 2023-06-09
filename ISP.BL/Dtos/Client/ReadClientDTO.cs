using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class ReadClientDTO
    {


        public  string Name { get; set; } = string.Empty;


        public string Phone { get; set; } = string.Empty;

        public string? Status { get; set; }

        public int PackageId { get; set; }

        public int? IpPackage { get; set; }

        public int BranchId { get; set; }
        public int ProviderId { get; set; }
        public string? DisstrubtorId { get; set; }

        public int OfferId { get; set; }

        public int CentralId { get; set; }
        public string userName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
