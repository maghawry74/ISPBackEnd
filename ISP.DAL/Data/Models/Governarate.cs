using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class Governarate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();   
        public ICollection<Central> Centrals { get; set; } = new HashSet<Central>();

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    } 
}
