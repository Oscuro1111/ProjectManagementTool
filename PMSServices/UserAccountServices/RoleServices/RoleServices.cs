using DataLayer.Model.UserAccount;
using System.Collections.Generic;
using PMSRepository;

namespace PMSServices.UserAccountServices.RoleServices
{
    public class RoleServices : IRoleServices
    {
        private readonly IPMSRepository<Role> roleRepository;

        public RoleServices(IPMSRepository<Role> roleRepo)
        {
            this.roleRepository = roleRepo; 
        }

        public void AddRole(Role role)
        {
            roleRepository.Insert(role);
            
        }

        public void DeleteRole(long Id)
        {
            Role role = GetRole(Id);

            roleRepository.Delete(role);

        }

        public IEnumerable<Role> GetAllRoles()
        {
            return this.roleRepository.GetAll();
        }

        public Role GetRole(long Id)
        {
            return roleRepository.Get(Id); 
        }

        public void UpdateRole(Role role)
        {
            roleRepository.Update(role);
        }
    }
}
