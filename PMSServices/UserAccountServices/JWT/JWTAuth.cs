using System.Linq;
using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PMSRepository;
using DataLayer.Model.UserAccount;
using PMSServices.UserAccountServices.UserCredentialServices;
using PMSServices.UserAccountServices.UserServices;
using System.Collections.Generic;

namespace PMSServices.UserAccountServices.JWT
{
   public  class JWTAuth : IJWTAuth
    {
        private IUserServices userServices;

        private  IUserCredentialServices credentialService;
        
        private readonly string key;
      
        public JWTAuth(string key)
        {
            this.key = key;
        }


        public void setDependency(IUserServices userServices ,IUserCredentialServices userCredentialServices)
        {

            this.userServices = userServices;

            this.credentialService = userCredentialServices;

        }
        public string Authentication(string userEmail, string password)
        {
            User user;

           List<User> users = userServices.GetUsers().Where(user => user.Email.Equals(userEmail)).ToList();

            

            if (users.Count==0)
            {
                return null;
            }

            user = users[0];

            bool value = credentialService.VerifyHashPassword(user.CredentialId, password);
            if (!value)
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }

}

