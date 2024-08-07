using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessAccessLayer.Interface;
using Common.Constants;
using Common.Exceptions;
using Entities.DataModels;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessAccessLayer.Services;

public class JwtManagerService : IJwtManagerService
{
    #region Constructor

    public IConfiguration _configuration;
    public IHttpContextAccessor _httpContext;

    public JwtManagerService(IConfiguration configuration, IHttpContextAccessor httpContext)
    {
        _configuration = configuration;
        _httpContext = httpContext;
    }

    #endregion Constructor

    #region Methods

    public TokensDTO GenerateToken(User user)
    {
        return GenerateJwtToken(user);
    }

    public TokensDTO GenerateRefreshToken(User user)
    {
        return GenerateJwtToken(user);
    }

    public TokensDTO GenerateJwtToken(User user)
    {
        //set key and credential
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        //add claim
        Claim[]? claims =
        [
                new Claim(SystemConstants.USER_ID_CLAIM,user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.RoleId.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.FirstName+" "+user.LastName),
        ];
        //make token
        JwtSecurityToken? token = new(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(600),
            signingCredentials: credentials);
        return new TokensDTO { AccessToken = new JwtSecurityTokenHandler().WriteToken(token) };
    }

    public ClaimsPrincipal GetPrincipalFormExpiredToken(string token)
    {
        byte[]? key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        TokenValidationParameters? tokenValidatorParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero,
        };
        JwtSecurityTokenHandler? tokenHandler = new();
        ClaimsPrincipal? principal = tokenHandler.ValidateToken(token, tokenValidatorParameters, out SecurityToken securityToken);

        JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException(MessageConstants.ErrorMessage.INVALID_TOKEN);
        }
        return principal;
    }

    public LoggedUser GetLoggedUser()
    {
        string authToken = _httpContext.HttpContext.Request.Headers.Authorization.FirstOrDefault() ?? throw new CustomException(StatusCodes.Status401Unauthorized, MessageConstants.ErrorMessage.UNAUTHORIZE);
        string? jsonToken = authToken.ToString().Replace(SystemConstants.BEARER, string.Empty);

        ClaimsPrincipal? claims = GetPrincipalFormExpiredToken(jsonToken);

        return new LoggedUser
        {
            UserId = Convert.ToInt64(claims.FindFirstValue(SystemConstants.USER_ID_CLAIM) ?? SystemConstants.ZERO_STRING),
            Role = Convert.ToInt32(claims.FindFirstValue(ClaimTypes.Role) ?? SystemConstants.ZERO_STRING),
            Name = claims.FindFirstValue(ClaimTypes.Name).ToString(),
            Email = claims.FindFirstValue(ClaimTypes.Email).ToString(),
        };
    }

    #endregion
}
