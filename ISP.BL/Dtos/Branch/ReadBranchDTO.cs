﻿using AutoMapper;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    //[AutoMap(typeof(Branch))]
    public class ReadBranchDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Address { get; set; } = string.Empty;


        public string Phone1 { get; set; } = string.Empty;

        public string Phone2 { get; set; } = string.Empty;

        public string Mobile1 { get; set; } = string.Empty;

        public string Mobile2 { get; set; } = string.Empty;

        public int? Fax { get; set; }
<<<<<<< HEAD
        public  string ManagerId { get; set; } = string.Empty;
=======
        public  string? ManagerId { get; set; } = string.Empty;
>>>>>>> 8309075f0b8a9b3c61d05e2515bcc78bcfd8302e

 
    }
}
