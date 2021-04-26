using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.MyModels
{
    public class InfinityDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InfinityIdentityUser>(u =>
            {
                u.Property(p => p.Id).HasDefaultValue(Guid.NewGuid());
                u.HasMany(p => p.Roles).WithOne(r => r.User).HasForeignKey(r => r.UserId).IsRequired();
            });
            builder.Entity<InfinityIdentityRole>(i =>
            {
                i.Property(p => p.Id).HasDefaultValue(Guid.NewGuid());
                i.HasMany(p => p.Users).WithOne(r => r.Role).HasForeignKey(f => f.RoleId).IsRequired();
                i.HasMany<IdentityRoleClaim<Guid>>().WithOne().HasForeignKey(p => p.RoleId).IsRequired();
            });
        }
    }
}
