using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole { Id = "1", Name = "Teacher",NormalizedName= "Teacher".ToUpper() },
                new IdentityRole { Id = "2", Name = "Student",NormalizedName= "Student".ToUpper() });
        }
    }
}
