
namespace ISP.BL.Dtos.Role
{
    public class WriteRoleDto
    {       
        public string Name { get; set; } = string.Empty;
        public List<string> RolePermissions { get; set; } = new List<string>();


        //public List<ReadRolePermissions> RolePermissions { get; set; } = new List<ReadRolePermissions>();
    }
}
