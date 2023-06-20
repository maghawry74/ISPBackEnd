
namespace ISP.BL.Dtos.Users
{
    public class ReadUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Status { get; set; }


    }
}
