using Microsoft.AspNetCore.Identity;

namespace ISP.DAL
{
<<<<<<< HEAD
    public class Role:IdentityRole
    {
        public string id { get; set; } = string.Empty;
       // public string Name { get; set; } = string.Empty;
       // public string NormalizedName { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        //public bool IsAdmin { get; set; }
        //public bool IsClientsOrder { get; set; }
        //public bool IsSearch { get; set; }
        //public bool IsAddNewClient { get; set; }
        //public ICollection<User> Users { get; set; } = new HashSet<User>(); 


=======

    public class Role : IdentityRole
    {
        public bool Status { get; set; } = true;       
>>>>>>> 1449b4ba56d78d5831f9b7d224a587664e6b7586

    }
}
