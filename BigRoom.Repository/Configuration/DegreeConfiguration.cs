using BigRoom.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Configuration
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            builder.HasOne(a => a.UserProfile).WithMany(a => a.Degrees).HasForeignKey(a=>a.UserProfileId);
            builder.HasOne(a => a.Quize).WithMany(a => a.Degrees).HasForeignKey(a=>a.QuizeId);
        }
    }
}
