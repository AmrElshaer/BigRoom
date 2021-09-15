﻿// <auto-generated />
using System;
using BigRoom.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BigRoom.Repository.Migrations
{
    [DbContext(typeof(BigRoomDbContext))]
    partial class BigRoomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BigRoom.Repository.Contexts.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Image");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExamDegree");

                    b.Property<int>("QuizeId");

                    b.Property<int>("TotalDegree");

                    b.Property<int?>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("QuizeId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId");

                    b.Property<string>("CodeJion");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.GroupPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Create");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("Delete");

                    b.Property<bool>("Edit");

                    b.Property<int>("GroupId");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<int?>("QuizeId");

                    b.Property<int?>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("QuizeId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("GroupPermissions");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.Quize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("File");

                    b.Property<string>("Fileanswer");

                    b.Property<int>("GroupId");

                    b.Property<int?>("Hour");

                    b.Property<string>("LastModifiedBy");

                    b.Property<DateTime?>("LastModifiedOn");

                    b.Property<int?>("Minute");

                    b.Property<DateTime>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.Property<int?>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Quizes");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.UserGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId");

                    b.Property<int?>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "2655809d-f389-4582-8ef8-ce6608f1dfd3",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "8a202024-3c78-4163-b198-a90a03306e6e",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.Degree", b =>
                {
                    b.HasOne("BigRoom.Repository.Entities.Quize", "Quize")
                        .WithMany("Degrees")
                        .HasForeignKey("QuizeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BigRoom.Repository.Entities.UserProfile", "UserProfile")
                        .WithMany("Degrees")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.Group", b =>
                {
                    b.HasOne("BigRoom.Repository.Entities.UserProfile", "Admin")
                        .WithMany("GroupsThatAdmin")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.GroupPermission", b =>
                {
                    b.HasOne("BigRoom.Repository.Entities.Group", "Group")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BigRoom.Repository.Entities.Quize", "Quize")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("QuizeId");

                    b.HasOne("BigRoom.Repository.Entities.UserProfile", "UserProfile")
                        .WithMany("GroupPermissions")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.Quize", b =>
                {
                    b.HasOne("BigRoom.Repository.Entities.Group", "Group")
                        .WithMany("Quizes")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BigRoom.Repository.Entities.UserProfile", "UserProfile")
                        .WithMany("QuizesCreate")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.UserGroups", b =>
                {
                    b.HasOne("BigRoom.Repository.Entities.Group", "Group")
                        .WithMany("Groups")
                        .HasForeignKey("GroupId");

                    b.HasOne("BigRoom.Repository.Entities.UserProfile", "UserProfile")
                        .WithMany("Groups")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("BigRoom.Repository.Entities.UserProfile", b =>
                {
                    b.HasOne("BigRoom.Repository.Contexts.ApplicationUser", "ApplicationUser")
                        .WithMany("UserProfiles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BigRoom.Repository.Contexts.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BigRoom.Repository.Contexts.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BigRoom.Repository.Contexts.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BigRoom.Repository.Contexts.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
