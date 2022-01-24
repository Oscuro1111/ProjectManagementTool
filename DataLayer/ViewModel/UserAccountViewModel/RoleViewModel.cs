using System;
using System.Collections.Generic;

namespace DataLayer.ViewModel.UserAccountViewModel
{
    public class RoleView
    {
        public long Id { get; set; }
        public String Name { get; set; }
        
    }

    public class RoleViewModel
    {
        public readonly List<RoleView> Roles;

        public RoleViewModel(List<RoleView> roles)
        {
            this.Roles = roles;
        }
    }
}
