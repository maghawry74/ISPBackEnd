using ISP.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class Branch
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;

        public int? Fax { get; set; }
        public bool Status { get; set; }

        [ForeignKey("Manager")]
        public string? ManagerId { get; set; }

        // Navigation property
        public User? Manager { get; set; }


        public string Phone1 { get; set; } = string.Empty;

        public string Phone2 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string Mobile1 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string Mobile2 { get; set; } = string.Empty;

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();

        [ForeignKey("Governarate")]
        public int? GovernarateCode { get; set; }
        public Governarate? Governarate { get; set; } 

    }
}
