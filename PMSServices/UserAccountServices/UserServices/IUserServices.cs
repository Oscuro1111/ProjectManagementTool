using System.Collections.Generic;
using DataLayer.Model.UserAccount;

namespace PMSServices.UserAccountServices.UserServices
{
    public interface IUserServices
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }
}
