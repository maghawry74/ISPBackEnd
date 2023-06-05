using ISP.DAL;

namespace ISP.DAL
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public ICollection<Central> Centrals { get; set; } = new HashSet<Central>();
        public ICollection<Package> Packages { get; set; } = new HashSet<Package>();

        public ICollection<Offer> offers { get; set; } = new HashSet<Offer>();

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    }
}