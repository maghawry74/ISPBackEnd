using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class Governarate
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();   
        public ICollection<Central> Centrals { get; set; } = new HashSet<Central>();

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    } 
}
