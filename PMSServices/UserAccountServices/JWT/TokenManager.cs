using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PMSServices.UserAccountServices.JWT;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PMServices.UserAccountServices.JWT
{
  public class TokenManager : ITokenManager
    {
        IConfiguration config;
        public TokenManager(IConfiguration config)
        {
            this.config = config;
        }

        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                JwtSecurityToken jwtToken = new JwtSecurityToken();

                SecurityToken securityToken;

                if (jwtToken == null) return null;

                TokenValidationParameters parameters = new TokenValidationParameters() {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.config.GetSection("JWTKey").Value))
                };


                ClaimsPrincipal cp = tokenHandler.ValidateToken(token,parameters,out securityToken);
                return cp;
            }
            catch (System.Exception)
            {
                //Handle
                throw;
             }

         
        }

       public string ValidateToken(string token)
        {
            string username = null;
            
            ClaimsPrincipal principal = GetPrincipal(token);
            ClaimsIdentity identity;
            Claim userClaim = null;

            if (principal==null)
            {
                return null;
            }

            try
            {
                identity = (ClaimsIdentity)principal.Identity;

            }
            catch (NullReferenceException)
            {

                //handle

                return null;
            }

            userClaim = identity.FindFirst(ClaimTypes.Name);
            username = userClaim.Value;
            return username;
        }
    }
}
