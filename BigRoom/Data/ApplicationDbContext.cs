using BigRoom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Group>().HasMany<Quize>(a => a.quizes).WithOne(a => a.Group).HasForeignKey(a => a.GroupId);
            modelBuilder.Entity<Degree>().HasKey(a => new { a.user, a.quize });
            modelBuilder.Entity<User>().HasMany<Group>(a => a.GroupsThatAdmin).WithOne(a => a.Admin);
            modelBuilder.Entity<Group>().HasMany<UserGroups>(a => a.Groups).WithOne(a => a.group).HasForeignKey(a => a.groupId);
            modelBuilder.Entity<User>().HasMany<UserGroups>(a => a.Groups).WithOne(a => a.user).HasForeignKey(a => a.userId);


        }
        public DbSet<BigRoom.Models.Group> Group { get; set; }
        public DbSet<BigRoom.Models.UserGroups> UserGroups { get; set; }
        public DbSet<BigRoom.Models.Quize> Quize { get; set; }

        public DbSet<BigRoom.Models.Degree> Degree { get; set; }
    }
}
