﻿// <auto-generated />
using System;
using CourseProject.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseProject.DataAccess.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200819082404_addedsomething")]
    partial class addedsomething
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseProject.DataAccess.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "his is a complete project based course from start to finish with real world experience using technologies that are currently in demand in the market. People interested in learning latest technologies should consider this course",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1200px-.NET_Logo.svg.png",
                            Name = "Build an app with ASPNET Core and Angular from scratch"
                        },
                        new
                        {
                            Id = 2,
                            Description = "his is a complete project based course from start to finish with real world experience using technologies that are currently in demand in the market. People interested in learning latest technologies should consider this course",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1200px-.NET_Logo.svg.png",
                            Name = "Build an app with ASPNET Core and Angular from scratch"
                        },
                        new
                        {
                            Id = 3,
                            Description = "his is a complete project based course from start to finish with real world experience using technologies that are currently in demand in the market. People interested in learning latest technologies should consider this course",
                            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1200px-.NET_Logo.svg.png",
                            Name = "Build an app with ASPNET Core and Angular from scratch"
                        });
                });

            modelBuilder.Entity("CourseProject.DataAccess.Entities.CourseToUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "CourseId", "StartDate");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesToUsers");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CourseId = 1,
                            StartDate = new DateTime(2020, 9, 3, 11, 24, 3, 921, DateTimeKind.Local).AddTicks(2291)
                        },
                        new
                        {
                            UserId = 1,
                            CourseId = 2,
                            StartDate = new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1072)
                        },
                        new
                        {
                            UserId = 2,
                            CourseId = 2,
                            StartDate = new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1131)
                        },
                        new
                        {
                            UserId = 2,
                            CourseId = 2,
                            StartDate = new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1138)
                        },
                        new
                        {
                            UserId = 2,
                            CourseId = 3,
                            StartDate = new DateTime(2020, 9, 3, 11, 24, 3, 925, DateTimeKind.Local).AddTicks(1142)
                        });
                });

            modelBuilder.Entity("CourseProject.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Age = 23,
                            ConcurrencyStamp = "8bd41438-25a0-4ad9-af22-fe330403ce96",
                            Email = "shagoferov@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ilya",
                            LastName = "Shagoferov",
                            LockoutEnabled = false,
                            PasswordHash = "password",
                            PhoneNumberConfirmed = false,
                            RegistrationDate = new DateTime(2020, 8, 19, 11, 24, 3, 933, DateTimeKind.Local).AddTicks(9588),
                            TwoFactorEnabled = false,
                            UserName = "Shagi"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Age = 21,
                            ConcurrencyStamp = "b4cd3ec2-7c8f-4c07-9db3-4e07d63eff69",
                            Email = "yurii@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Yurii",
                            LastName = "Smazhniy",
                            LockoutEnabled = false,
                            PasswordHash = "password",
                            PhoneNumberConfirmed = false,
                            RegistrationDate = new DateTime(2020, 8, 19, 11, 24, 3, 933, DateTimeKind.Local).AddTicks(9716),
                            TwoFactorEnabled = false,
                            UserName = "Muzilko"
                        });
                });

            modelBuilder.Entity("CourseProject.DataAccess.Entities.UserRefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRefreshTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
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
                            Id = 1,
                            ConcurrencyStamp = "07d9d2cf-9be7-4dfa-83ea-c646b44d9292",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "c4399d5b-d70e-47e8-b2a7-f98980ce311b",
                            Name = "student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CourseProject.DataAccess.Entities.CourseToUser", b =>
                {
                    b.HasOne("CourseProject.DataAccess.Entities.Course", "Course")
                        .WithMany("CourseToStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseProject.DataAccess.Entities.User", "User")
                        .WithMany("CourseToStudents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseProject.DataAccess.Entities.UserRefreshToken", b =>
                {
                    b.HasOne("CourseProject.DataAccess.Entities.User", null)
                        .WithMany("UserRefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("CourseProject.DataAccess.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("CourseProject.DataAccess.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseProject.DataAccess.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("CourseProject.DataAccess.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
