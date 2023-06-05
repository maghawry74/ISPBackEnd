using ISP.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
   public class User:IdentityUser
    {
        [Required]
        public bool Status { get; set; }
        public Branch? Branch { get; set; }
        public Role? Role { get; set; }
        public Bill? Bill { get; set; }
    }
}
