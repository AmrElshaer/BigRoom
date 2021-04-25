using BigRoom.Model.Common;
using BigRoom.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigRoom.Repository.Contexts
{
    public  class BigRoomDbContext :IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BigRoomDbContext(DbContextOptions<BigRoomDbContext> options, IHttpContextAccessor httpContextAccessor)
           : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroups> UserGroups { get; set; }
        public DbSet<Quize> Quizes { get; set; }

        public DbSet<Degree> Degrees { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.CreatedBy = httpContextAccessor.HttpContext.User.Identity.Name;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = httpContextAccessor.HttpContext.User.Identity.Name;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
     
       
    }
}
