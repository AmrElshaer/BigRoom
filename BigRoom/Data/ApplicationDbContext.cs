using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using BigRoom.Models;

namespace Classroom.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserGroups>()
                        .HasKey(s => new { s.CodeJoin, s.UserName });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Admin" }, new IdentityRole { Id = "2", Name = "Teacher" }, new IdentityRole { Id = "3", Name = "Student" });
            modelBuilder.Entity<Group>().HasMany<Quize>(a => a.quizes).WithOne(a => a.Group);
            modelBuilder.Entity<Degree>().HasKey(a => new { a.user, a.quize });


        }
        public DbSet<BigRoom.Models.Group> Group { get; set; }
        public DbSet<BigRoom.Models.UserGroups> UserGroups { get; set; }
        public DbSet<BigRoom.Models.Quize> Quize { get; set; }
       
        public DbSet<BigRoom.Models.Degree> Degree { get; set; }
    }
}
