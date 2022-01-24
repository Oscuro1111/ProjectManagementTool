using System.Collections.Generic;
using DataLayer.Model.UserAccount;
using PMSRepository;

namespace PMSServices.UserAccountServices.UserServices
{
   public class UserServices:IUserServices
    {
        private readonly IPMSRepository<User> userRepository;


        public UserServices(IPMSRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUser(long id)
        {
            return userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            User user = GetUser(id);
            
            userRepository.Delete(user);

           
        }

    }
}
