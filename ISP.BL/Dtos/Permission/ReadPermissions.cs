namespace ISP.BL.Dtos.Permission
{
    public class ReadPermissions
    {
        public string RoleId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public List<ReadRolePermissions> RolePermissions { get; set;} = new List<ReadRolePermissions>();
    }
}
