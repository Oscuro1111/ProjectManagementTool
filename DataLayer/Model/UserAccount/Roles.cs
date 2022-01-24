using System;
using System.Collections.Generic;

namespace DataLayer.Model.UserAccount
{
    public class Role:BaseEntity
    {
        public String Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
