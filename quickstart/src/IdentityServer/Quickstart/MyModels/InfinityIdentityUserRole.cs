using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.MyModels
{
    public class InfinityIdentityUserRole : IdentityUserRole<Guid>
    {
        public InfinityIdentityUser User { get; set; }
        public InfinityIdentityRole Role { get; set; }
    }
}
