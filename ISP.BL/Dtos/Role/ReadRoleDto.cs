using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL.Dtos.Role
{
    public class ReadRoleDto
    {
        public int Id { get; set; }        
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public bool IsClientsOrder { get; set; }
        public bool IsSearch { get; set; }
        public bool IsAddNewClient { get; set; }
    }
}
