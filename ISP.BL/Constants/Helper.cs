using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL.Constants
{
    public static class Helper
    {
        public enum Roles
        {
            Admin,
            SuperAdmin
        }

        // create names of permissions
        public enum PermissionsModuleName
        {
            //Controllers Permissins
            Bill,
            Branch,
            Central,
            Client,
            Governarate,
            Offer,
            Package,
            Provider,
            Role,
            User,

        }
    }
}
