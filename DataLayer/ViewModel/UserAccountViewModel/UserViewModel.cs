
using System.Collections.Generic;

namespace DataLayer.ViewModel.UserAccountViewModel
{
    public class UserView
    {
        public long Id;
        public string UserName { get; set; }
        public string Email { get; set; }
        public long CredentialId { get; set; }
        public string Role { get; set; }
    }

    public class UserViewModel {
        public readonly List<UserView> Users;

        public UserViewModel(List<UserView> users)
        {
            this.Users=users;
        }
    }
}
