using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace PMSRepository.Repositorysetup
{
   public class Setup
    {

        public static void ConfigureRepository(IServiceCollection services,IConfiguration config)
        {
            services.AddScoped(typeof(IPMSRepository<>), typeof(PMSRepository<>));

            services.AddDbContext<Context.PMSContext>(
           options => options.UseSqlServer(config.GetConnectionString("WIN_PMS_DB")));
        }
    }
}
