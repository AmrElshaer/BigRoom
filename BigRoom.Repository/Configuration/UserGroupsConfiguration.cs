using BigRoom.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Configuration
{
    public class UserGroupsConfiguration : IEntityTypeConfiguration<UserGroups>
    {
        public void Configure(EntityTypeBuilder<UserGroups> builder)
        {
            builder.HasOne(a=>a.Group).WithMany(a=>a.Groups).HasForeignKey(a=>a.GroupId);
            builder.HasOne(a=>a.UserProfile).WithMany(a=>a.Groups).HasForeignKey(a=>a.UserProfileId);
        }
    }
}
