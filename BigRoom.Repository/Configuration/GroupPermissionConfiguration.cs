using BigRoom.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Configuration
{
    public class GroupPermissionConfiguration : IEntityTypeConfiguration<GroupPermission>
    {
        public void Configure(EntityTypeBuilder<GroupPermission> builder)
        {
            builder.HasOne(a => a.Group).WithMany(a => a.GroupPermissions).HasForeignKey(a => a.GroupId);
            builder.HasOne(a => a.Quize).WithMany(a => a.GroupPermissions).HasForeignKey(a => a.QuizeId);
            builder.HasOne(a => a.UserProfile).WithMany(a => a.GroupPermissions).HasForeignKey(a => a.UserProfileId);
        }
    }
}
