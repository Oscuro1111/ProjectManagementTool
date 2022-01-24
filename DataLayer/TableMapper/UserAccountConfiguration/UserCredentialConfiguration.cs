using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataLayer.Model.UserAccount;



namespace DataLayer.TableMapper.UserAccountConfiguration
{
    public class UserCredentialConfiguration
    {
        public static void MapUserCredentialConfiguration(EntityTypeBuilder<UserCredential> builder)
        {

            builder.Property(c => c.PassHash).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Salt).HasMaxLength(256).IsRequired();
        }
    }
}
