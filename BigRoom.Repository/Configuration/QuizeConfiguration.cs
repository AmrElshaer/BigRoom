using BigRoom.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BigRoom.Repository.Configuration
{
    public class QuizeConfiguration : IEntityTypeConfiguration<Quize>
    {
        public void Configure(EntityTypeBuilder<Quize> builder)
        {
            builder.HasOne(a => a.UserProfile).WithMany(a => a.QuizesCreate).HasForeignKey(a => a.UserProfileId);
            builder.HasOne(a => a.Group).WithMany(a => a.Quizes).HasForeignKey(a=>a.GroupId);
        }
    }
}
