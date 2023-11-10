using Common.Constants;
using Common.Exceptions;
using Common.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagementAPI.ExtAuthorization
{
    public class AuthHelper
    {
        #region Constructor

        public HttpContext _httpContext;
        public IConfiguration _confi;

        public AuthHelper(HttpContext httpContext, IConfiguration configuration)
        {
            _httpContext = httpContext;
            _confi = configuration;
        }

        #endregion

        #region Methods

        internal void AuthorizeRequest()
        {
            string authToken = _httpContext.Request.Headers.Authorization.FirstOrDefault() ?? throw new UnauthorizedException(MessageConstants.UNAUTHORIZE);
            var jsonToken = authToken.ToString().Replace(SystemConstants.BEARER, string.Empty);

            JwtSetting jwtSetting = GetJwtSetting(_confi);

            ClaimsPrincipal? claims = GetClaimsWithValidationToken(jwtSetting, jsonToken) ?? throw new UnauthorizedAccessException();

            // Create the CurrentUserModel object from the claims
            SetLoggedUser(_httpContext, claims);
        }

        public ClaimsPrincipal? GetClaimsWithValidationToken(JwtSetting jwtSetting, string jsonToken)
        {

            JwtSecurityTokenHandler tokenHandler = new();

            byte[] key = Encoding.ASCII.GetBytes(jwtSetting.Key);

            TokenValidationParameters validationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = jwtSetting.Issuer,
                ClockSkew = TimeSpan.Zero
            };

            HasTokenExpired(jsonToken);

            ClaimsPrincipal? claims = tokenHandler.ValidateToken(jsonToken, validationParameters, out var validatedToken);
            return claims;
        }

        public LoggedUser GetLoggedUser()
        {
            string authToken = _httpContext.Request.Headers.Authorization.FirstOrDefault() ?? throw new UnauthorizedException(MessageConstants.UNAUTHORIZE);

            string? jsonToken = authToken.ToString().Replace(SystemConstants.BEARER, string.Empty);

            JwtSetting jwtSetting = GetJwtSetting(_confi);

            ClaimsPrincipal? claims = GetClaimsWithValidationToken(jwtSetting, jsonToken);

            return new LoggedUser
            {
                UserId = Convert.ToInt64(claims.FindFirstValue(SystemConstants.USER_ID_CLAIM) ?? SystemConstants.ZERO_STRING),
                Role = Convert.ToInt32(claims.FindFirstValue(ClaimTypes.Role) ?? SystemConstants.ZERO_STRING),
                Name = claims.FindFirstValue(ClaimTypes.Name).ToString(),
                Email = claims.FindFirstValue(ClaimTypes.Email).ToString()
            };
        }

        #endregion

        #region Private_Methods

        private static JwtSetting GetJwtSetting(IConfiguration configuration)
        {
            JwtSetting jwtSetting = new();
            configuration.GetSection("Jwt").Bind(jwtSetting);
            return jwtSetting;
        }

        private static void SetLoggedUser(HttpContext httpContext, ClaimsPrincipal claims)
        {
            LoggedUser loggedUser = new()
            {
                UserId = Convert.ToInt64(claims.FindFirstValue(SystemConstants.USER_ID_CLAIM) ?? SystemConstants.ZERO_STRING),
                Role = Convert.ToInt32(claims.FindFirstValue(ClaimTypes.Role) ?? SystemConstants.ZERO_STRING),
                Name = claims.FindFirstValue(ClaimTypes.Name).ToString(),
                Email = claims.FindFirstValue(ClaimTypes.Email).ToString(),
            };

            // Set the authenticated user
            ClaimsIdentity? identity = new ClaimsIdentity(claims.Identity);
            ClaimsPrincipal? principal = new ClaimsPrincipal(identity);
            httpContext.User = principal;

            // Attach the CurrentUserModel to the HttpContext.User
            httpContext.Items[SystemConstants.LOGGED_USER] = loggedUser;
        }

        private void HasTokenExpired(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken? jsonToken = handler.ReadJwtToken(token);

            if (jsonToken.ValidTo < DateTime.UtcNow) throw new UnauthorizedException(MessageConstants.TOKEN_EXPIRED);
        }

        #endregion
    }
}
