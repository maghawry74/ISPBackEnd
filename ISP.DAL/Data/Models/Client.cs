using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class Client
    {
        [Key]
        public int SSn { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public Governarate? Governarate { get; set; }

        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

       public Provider? Provider { get; set; }
        public Offer? Offer { get; set; }
        public Package? Package { get; set; }

        public Central? Central { get; set; }

        public int IpPackage { get; set; }
        /// -------->


        public DateTime Contractdate { get; set; }

        public ICollection<Mobile> Mobiles = new HashSet<Mobile>();

        public string LineOwner { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public Branch? Branch { get; set; }

        public string RouterSerial { get; set; } = string.Empty;

        public int OrderNumber { get; set; }

        public int PortSlot { get; set; }


        public int PortBlock { get; set; }

        public string userName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int VPI { get; set; }
        public int VCI { get; set; }

        public int OrderWorkNumber { get; set; }


        public DateTime Orderworkdate { get; set; }

        public double PrePaid { get; set; }

        public double installationFee { get; set; }
        public double ContractFee { get; set; }

        public int Slotnum { get; set; }


        public int Blocknum { get; set; }

        public ICollection<Bill> Bills = new HashSet<Bill>();

    }


}
