using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using User_Management_WebApp.Constants;

namespace User_Management_WebApp.Filters
{
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {

        public DefaultAuthorizationPolicyProvider FullbackPolicyProvider { get; }

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            FullbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FullbackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            return FullbackPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(ClaimPermationTypes.Permations.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var Policy = new AuthorizationPolicyBuilder();
                Policy.AddRequirements(new PermissionRequirement(policyName));
                return Task.FromResult(Policy.Build());

            }
            return FullbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
