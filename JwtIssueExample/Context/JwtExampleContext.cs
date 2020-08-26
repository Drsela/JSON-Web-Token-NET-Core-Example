using JwtIssueExample.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JwtIssueExample.Context
{
    public class JwtExampleContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public JwtExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(x => x.UserName)
                .IsUnique();

            var regularUser = new User { Id = Guid.Parse("54D39F1A-EF2D-4816-B2E8-90991F548BF0"), UserName = "Regular", Password = "RegularPassword", Type = UserType.Regular };
            var adminUser = new User { Id = Guid.Parse("36F72591-1D95-4E4F-877C-261D3386DF94"), UserName = "Admin", Password = "AdminPassword", Type = UserType.Admin };
            var superUser = new User { Id = Guid.Parse("FB270C9A-9479-4BD0-9C86-589F3FA84527"), UserName = "Super", Password = "SuperPassword", Type = UserType.SuperUser };
            builder.Entity<User>().HasData(regularUser, adminUser, superUser);
        }
    }

}
