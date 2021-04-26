using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.MyModels
{
    public class InfinityIdentityUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<InfinityIdentityUserRole> Roles { get; set; }
    }
}
