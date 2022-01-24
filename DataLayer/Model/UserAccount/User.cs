using DataLayer.Model.UserAccount.AccountPermissions;
namespace DataLayer.Model.UserAccount
{
   public class User:BaseEntity
    {
  
        public string UserName { get; set; }
        public string Email { get; set; }
        public long CredentialId { get; set; }
        public UserCredential Credential { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public Permissions permissions{get;set;}

    }
}