using Microsoft.EntityFrameworkCore;
using EFC = Microsoft.EntityFrameworkCore;
using DataLayer.Model.UserAccount;
using DataLayer.TableMapper.UserAccountConfiguration;

namespace PMSRepository.Context
{
    public class PMSContext : EFC::DbContext
    {
        public PMSContext(EFC::DbContextOptions<PMSContext> options)
        : base(options)
        {
           
        }

        protected  override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<User>()
                   .HasOne<Role>(user => user.Role)
                   .WithMany(role => role.Users);


            PermissionsConfigurations.MapPermisssionsConfiguration(builder);
            //Applying  configuration.
            UserConfiguration.MapUserConfiguration(builder.Entity<User>().ToTable("tbl_users"));
            RoleConfiguration.MapRoleConfiguration(builder.Entity<Role>().ToTable("tbl_roles"));
  
            UserCredentialConfiguration.MapUserCredentialConfiguration(builder
                                                                           .Entity<UserCredential>()
                                                                           .ToTable("tbl_usersCredential"));



        }

        public DbSet<User> tbl_users;
        public DbSet<Role> tbl_roles;
        public DbSet<UserCredential> tbl_userCredentials;

        public DbSet<PermissionsConfigurations> tbl_permissions;
    }

}
