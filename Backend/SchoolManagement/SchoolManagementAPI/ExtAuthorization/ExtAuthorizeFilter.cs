using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolManagementAPI.ExtAuthorization
{
    public class ExtAuthorizeFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;


        public ExtAuthorizeFilter(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
                throw new UnauthorizedAccessException();

            new AuthHelper(_httpContextAccessor.HttpContext, _configuration).AuthorizeRequest();
        }
    }
}
