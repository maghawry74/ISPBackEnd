﻿
namespace ISP.BL.Dtos.Users
{
    public class AdminRegisterDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public int? BranchId { get; set; }
        //public int RoleId { get; set; }

    }
}