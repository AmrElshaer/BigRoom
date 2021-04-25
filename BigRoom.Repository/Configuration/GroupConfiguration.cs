using BigRoom.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasMany(a=>a.Quizes).WithOne(a=>a.Group).HasForeignKey(a=>a.GroupId);
            builder.HasMany(a => a.Groups).WithOne(a => a.Group).HasForeignKey(a => a.GroupId);
            builder.HasOne(a => a.Admin).WithMany(a => a.GroupsThatAdmin).HasForeignKey(a=>a.AdminId);
            
        }
    }
}
