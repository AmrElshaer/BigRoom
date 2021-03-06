﻿using BigRoom.Repository.Entities;
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
            builder.HasMany(a => a.Degrees).WithOne(a => a.Quize).HasForeignKey(a => a.QuizeId);
            builder.HasOne(a => a.UserProfile).WithMany(a => a.QuizesCreate).HasForeignKey(a => a.UserProfileId);
            builder.HasOne(a => a.Group).WithMany(a => a.Quizes).HasForeignKey(a=>a.GroupId);
        }
    }
}
