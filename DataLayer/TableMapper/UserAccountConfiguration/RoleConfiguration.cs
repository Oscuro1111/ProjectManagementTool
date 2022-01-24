using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataLayer.Model.UserAccount;

namespace DataLayer.TableMapper.UserAccountConfiguration
{

    public class RoleConfiguration
    {
        public static void  MapRoleConfiguration(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id);
            builder.Property(role=>role.Name).HasMaxLength(124).IsRequired();
        }
    }
}
