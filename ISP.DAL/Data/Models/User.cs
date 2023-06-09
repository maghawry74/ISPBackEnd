using ISP.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
   public class User:IdentityUser
    {
        [Required]
        public bool Status { get; set; }

        [ForeignKey("Branch")]
        public int? BranchId { get; set; }

        [ForeignKey("Role")]
        public int? RoleId { get; set; }

        [ForeignKey("Bill")]
        public int? BillId { get; set; }
        public Branch? Branch { get; set; }
        public Role? Role { get; set; }
        public Bill? Bill { get; set; }
    }
}
