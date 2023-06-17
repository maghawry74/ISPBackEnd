﻿
using static ISP.BL.Constants.Helper;

namespace ISP.API.Constants
{
    public static class Permissions
    {
                 

        public static List<string> GeneratePermissionsOfModule(string module)
        {
            return new List<string>
            {
                $"Permission.{module}.View",
                $"Permission.{module}.Create",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete",
            };
        }



        public static List<string> PermissionsList()
        {
            var allPermissions = new List<string>();
            foreach (var module in Enum.GetValues(typeof(PermissionsModuleName)))
            {
                allPermissions.AddRange(GeneratePermissionsOfModule(module.ToString())); 
            }
            return allPermissions;
        }


       
       
        public static class Bill
        {
            public const string View = "Permission.Bill.View";
            public const string Create = "Permission.Bill.Create";
            public const string Edit = "Permission.Bill.Edit";
            public const string Delete = "Permission.Bill.Delete";
        }
        public static class Branch
        {
            public const string View = "Permission.Branch.View";
            public const string Create = "Permission.Branch.Create";
            public const string Edit = "Permission.Branch.Edit";
            public const string Delete = "Permission.Branch.Delete";
        }
        public static class Central
        {
            public const string View = "Permission.Central.View";
            public const string Create = "Permission.Central.Create";
            public const string Edit = "Permission.Central.Edit";
            public const string Delete = "Permission.Central.Delete";
        }
        public static class Client
        {
            public const string View = "Permission.Client.View";
            public const string Create = "Permission.Client.Create";
            public const string Edit = "Permission.Client.Edit";
            public const string Delete = "Permission.Client.Delete";
        }
        public static class Governarate
        {
            public const string View = "Permission.Governarate.View";
            public const string Create = "Permission.Governarate.Create";
            public const string Edit = "Permission.Governarate.Edit";
            public const string Delete = "Permission.Governarate.Delete";
        }
        public static class Offer
        {
            public const string View = "Permission.Offer.View";
            public const string Create = "Permission.Offer.Create";
            public const string Edit = "Permission.Offer.Edit";
            public const string Delete = "Permission.Offer.Delete";
        }
        public static class Package
        {
            public const string View = "Permission.Package.View";
            public const string Create = "Permission.Package.Create";
            public const string Edit = "Permission.Package.Edit";
            public const string Delete = "Permission.Package.Delete";
        }
        public static class Provider
        {
            public const string View = "Permission.Provider.View";
            public const string Create = "Permission.Provider.Create";
            public const string Edit = "Permission.Provider.Edit";
            public const string Delete = "Permission.Provider.Delete";
        }
        public static class Role
        {
            public const string View = "Permission.Role.View";
            public const string Create = "Permission.Role.Create";
            public const string Edit = "Permission.Role.Edit";
            public const string Delete = "Permission.Role.Delete";
        }
        
        public static class User
        {
            public const string View = "Permission.User.View";
            public const string Create = "Permission.User.Create";
            public const string Edit = "Permission.User.Edit";
            public const string Delete = "Permission.User.Delete";
        }

        public static class RolePermissions
        {
            public const string View = "Permission.RolePermissions.View";
            public const string Create = "Permission.RolePermissions.Create";
            public const string Edit = "Permission.RolePermissions.Edit";
            public const string Delete = "Permission.RolePermissions.Delete";
        }

    }
}
