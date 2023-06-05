namespace ISP.DAL
{
    public class Central
    {
        public int Id { get; set; }
        public string Name { get; set; }  = string.Empty;
        public Governarate? Governarate { get; set; }

        public ICollection<Provider> Providers { get; set; } = new HashSet<Provider>();

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    }
}