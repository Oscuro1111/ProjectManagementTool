using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataLayer.Model.UserAccount;
using DataLayer.Model.UserAccount.AccountPermissions;

namespace DataLayer.TableMapper.UserAccountConfiguration
{
    public class UserConfiguration 
    {
        public static void MapUserConfiguration(EntityTypeBuilder<User>builder) {

            builder.Property(user => user.UserName).HasMaxLength(64).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);


          /*Relationship*/
            builder.HasOne(u=>u.permissions)    //has one relationship with  permission . 
                   .WithOne(p=>p.User) //permission table
                   .HasForeignKey<Permissions>(p=>p.Id); 

        }
    }
}
