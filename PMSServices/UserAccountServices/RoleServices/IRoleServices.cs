using DataLayer.Model.UserAccount;
using System.Collections.Generic;

namespace PMSServices.UserAccountServices.RoleServices
{
    public interface IRoleServices
    {
        Role GetRole(long Id);
        IEnumerable<Role> GetAllRoles();

        void AddRole(Role role);
        void DeleteRole(long Id);

        void  UpdateRole(Role role);
         
    }
}
