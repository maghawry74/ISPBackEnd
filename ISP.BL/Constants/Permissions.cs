using static ISP.API.Helpers.Helper;

namespace ISP.API.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsOfModule(string module)
        {
            return new List<string>
            {
                $"{module}.View",
                $"{module}.Create",
                $"{module}.Edit",
                $"{module}.Delete",
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
    }
}
