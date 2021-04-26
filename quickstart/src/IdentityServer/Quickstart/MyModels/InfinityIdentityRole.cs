using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.MyModels
{
    public class InfinityIdentityRole : IdentityRole<Guid>
    {
        public ICollection<InfinityIdentityUserRole> Users { get; } = new List<InfinityIdentityUserRole>();
        public InfinityIdentityRole() { }
        public InfinityIdentityRole(string roleName) : base(roleName) { }
    }
}
