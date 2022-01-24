using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using PMSServices.UserAccountServices.JWT;


namespace PMS.Middlewears
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JWTAuthentication
    {
        private readonly RequestDelegate _next;

        private readonly ITokenManager tokenManager;
        public JWTAuthentication(RequestDelegate next, ITokenManager tokenManager)
        {
            _next = next;

            this.tokenManager = tokenManager;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string token;
         

            if (httpContext.Request.Path.Value.Equals("/Login")|| httpContext.Request.Path.Value.Equals("/LoginForm"))
            {

                await _next(httpContext);
                return;
            }
            else { 
            

                token = httpContext.Request.Cookies["token"];

                try { 
                if (tokenManager.ValidateToken(token) != null)
                {
                        try { 
                        
                             await _next(httpContext);
                        }catch
                        {
                            httpContext.Response.Redirect("/error/504");
                        }
                   
                        return;

                }

                }
                catch
                {

                      httpContext.Response.Redirect("/LoginForm");
                
                }


          }

       

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JWTAuthenticationExtensions
    {
        public static IApplicationBuilder UseJWTAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JWTAuthentication>();
        }
    }
}
