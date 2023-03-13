using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Models.Domains
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<User_Role> UserRoles { get; set; }
    }   
}
