using Microsoft.AspNetCore.Authorization;

namespace API.ExtAuthorization;

public class ExtAuthorizeRequirement : IAuthorizationRequirement
{
    public string PolicyName { get; }

    public ExtAuthorizeRequirement(string policyName)
    {
        PolicyName = policyName;
    }
}
