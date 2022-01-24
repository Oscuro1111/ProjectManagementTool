using MaleServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PMServices.UserAccountServices.JWT;
using PMSServices.UserAccountServices.JWT;
using PMSServices.UserAccountServices.RoleServices;
using PMSServices.UserAccountServices.UserCredentialServices;
using PMSServices.UserAccountServices.UserServices;
using System.Text;

namespace PMSServices.ServicesSetup
{
   public  class Setup
    {
     
        public static void ConfigureServices(IServiceCollection services,IConfiguration config)
        {
            var key = config.GetSection("JWTKey").Value;

            PMSRepository.Repositorysetup.Setup.ConfigureRepository(services,config);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false ,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
                };
            });

            services.AddSingleton<IJWTAuth>(new JWTAuth(key));
            services.AddSingleton<ITokenManager>(new TokenManager(config));

            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IRoleServices, RoleServices>();
            services.AddTransient<IUserCredentialServices, UserCredentialServices>();
        }
    }
}
