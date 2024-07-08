using System.Security.Claims;
using Entities.DataModels;
using Entities.DTOs;

namespace BusinessAccessLayer.Interface;

public interface IJwtManagerService
{
    TokensDTO GenerateToken(User user);

    TokensDTO GenerateRefreshToken(User user);

    TokensDTO GenerateJwtToken(User user);

    LoggedUser GetLoggedUser();

    ClaimsPrincipal GetPrincipalFormExpiredToken(string token);
}
