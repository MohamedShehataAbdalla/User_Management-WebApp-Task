using Microsoft.AspNetCore.Authorization;

namespace User_Management_WebApp.Filters
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set;}
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }

        
    }
}
