using ISP.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class WriteClientDTO
    {

        [Required(ErrorMessage ="the client ssn must not be empty")]
        [MaxLength(14)]
        
        public  int SSn { get; set; }

        [StringLength(50 , ErrorMessage ="client name must not exceed 50 character")]
        public required string Name { get; set; } = string.Empty;

        public string Status { get; set; }

        [MaxLength(10)]
        public required string Phone { get; set; } = string.Empty;


        public int GovernarateCode { get; set; }


        [StringLength(100)]
        public string Address { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        public int ProviderId { get; set; }

        public int OfferId { get; set; }


        public int PackageId { get; set; }



        public int CentralId { get; set; }


        public int? IpPackage { get; set; }
        /// -------->


        public DateTime Contractdate { get; set; }

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string Mobile1 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string Mobile2 { get; set; } = string.Empty;

        public string LineOwner { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public int BranchId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string RouterSerial { get; set; } = string.Empty;

        public int? OrderNumber { get; set; }

        public int? PortSlot { get; set; }


        public int? PortBlock { get; set; }

        [StringLength(50)]
        public string userName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public int? VPI { get; set; }
        public int? VCI { get; set; }

        public int? OrderWorkNumber { get; set; }


        public DateTime Orderworkdate { get; set; }

        public double PrePaid { get; set; }

        public required double installationFee { get; set; }
        public required double ContractFee { get; set; }

        public int? Slotnum { get; set; }


        public int? Blocknum { get; set; }

    }
}
