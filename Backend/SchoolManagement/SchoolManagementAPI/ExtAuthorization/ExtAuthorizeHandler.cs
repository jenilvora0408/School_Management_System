using Common.Constants;
using Common.Enums;
using Common.Exceptions;
using Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace SchoolManagementAPI.ExtAuthorization
{
    public class ExtAuthorizeHandler : AuthorizationHandler<ExtAuthorizeRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ExtAuthorizeHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ExtAuthorizeRequirement requirement)
        {
            HttpContext? httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            new AuthHelper(httpContext, _configuration).AuthorizeRequest();

            if (CheckUserType(httpContext, requirement))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }

        private static bool CheckUserType(HttpContext context, ExtAuthorizeRequirement requirement)
        {
            LoggedUser? loggedUser = context.Items[SystemConstants.LOGGED_USER] as LoggedUser;

            if (loggedUser == null) return false;

            // Handle the Policy requirement
            if (requirement.PolicyName == SystemConstants.PRINCIPAL_POLICY)
            {
                if (loggedUser.Role == (int)UserRoleType.PRINCIPAL) return true;
            }
            else if (requirement.PolicyName == SystemConstants.TEACHER_POLICY)
            {
                if (loggedUser.Role == (int)UserRoleType.TEACHER) return true;
            }
            else if (requirement.PolicyName == SystemConstants.STUDENT_POLICY)
            {
                if (loggedUser.Role == (int)UserRoleType.STUDENT) return true;
            }
            else if (requirement.PolicyName == SystemConstants.LAB_INSTRUCTOR_POLICY)
            {
                if (loggedUser.Role == (int)UserRoleType.LAB_INSTRUCTOR) return true;
            }
            else if (requirement.PolicyName == SystemConstants.ALL_USER_POLICY)
            {
                if (loggedUser.Role == (int)UserRoleType.PRINCIPAL || loggedUser.Role == (int)UserRoleType.TEACHER || loggedUser.Role == (int)UserRoleType.STUDENT || loggedUser.Role == (int)UserRoleType.LAB_INSTRUCTOR) return true;
            }

            throw new UnauthorizedException(MessageConstants.UNAUTHORIZE);
        }
    }
}
