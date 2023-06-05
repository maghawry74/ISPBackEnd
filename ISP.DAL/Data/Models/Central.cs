using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISP.DAL
{
    public class Central
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }  = string.Empty;

        [ForeignKey("Governarate")]
        public int GovernarateCode { get; set; }
        public Governarate? Governarate { get; set; }

        public ICollection<Provider> Providers { get; set; } = new HashSet<Provider>();

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    }
}