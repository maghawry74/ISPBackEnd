using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
       public string Name { get; set; } = string.Empty;
       public string NormalizedName { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }
        public bool IsClientsOrder { get; set; }
        public bool IsSearch { get; set; }
        public bool IsAddNewClient { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>(); 


    }
}
