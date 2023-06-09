
namespace ISP.BL.Dtos.Role
{
    public class UpdateRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;       
        public bool IsAdmin { get; set; }
        public bool IsClientsOrder { get; set; }
        public bool IsSearch { get; set; }
        public bool IsAddNewClient { get; set; }
    }
}
