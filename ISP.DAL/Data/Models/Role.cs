using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ISP.DAL
{
    public class Role
    {
        public string id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public bool IsAdmin { get; set; }
        public bool IsClientsOrder { get; set; }
        public bool IsSearch { get; set; }
        public bool IsAddNewClient { get; set; }

        //public ICollection<User> Users { get; set; } = new HashSet<User>(); 



    }
}
