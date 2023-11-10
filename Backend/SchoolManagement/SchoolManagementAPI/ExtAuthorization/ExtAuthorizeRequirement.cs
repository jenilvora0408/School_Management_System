using Microsoft.AspNetCore.Authorization;

namespace SchoolManagementAPI.ExtAuthorization
{
    public class ExtAuthorizeRequirement : IAuthorizationRequirement
    {
        public string PolicyName { get; }

        public ExtAuthorizeRequirement(string policyName)
        {
            PolicyName = policyName;
        }
    }
}
