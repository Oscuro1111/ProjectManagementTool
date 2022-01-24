using System.Security.Claims;

namespace PMSServices.UserAccountServices.JWT
{
    public interface ITokenManager
    {
         ClaimsPrincipal GetPrincipal(string token);
         string ValidateToken(string token);
    }
}
