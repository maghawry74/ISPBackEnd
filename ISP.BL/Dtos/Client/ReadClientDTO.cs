﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class ReadClientDTO
    {


        public int SSID { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Tel{ get; set; } = string.Empty;
        public string? GovernorateName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ProviderName { get; set; } = string.Empty;
        public string? PackageName { get; set; } = string.Empty;
        public string? CentralName { get; set; } = string.Empty;
        public string? BranchName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
