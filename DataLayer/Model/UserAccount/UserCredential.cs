
using System.Collections.Generic;

namespace DataLayer.Model.UserAccount
{
    public class UserCredential:BaseEntity
    {
        public string PassHash { get; set; }

        public string Salt { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
