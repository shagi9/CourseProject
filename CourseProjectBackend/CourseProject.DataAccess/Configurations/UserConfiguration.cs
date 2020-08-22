using CourseProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.DataAccess.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.CourseToStudents)
                .WithOne(u => u.User);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.DateOfBirth)
                .IsRequired();

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Ilya",
                    LastName = "Shagoferov",
                    UserName = "Shagi",
                    Email = "shagoferov@gmail.com",
                    PasswordHash = "password",
                    DateOfBirth = new DateTime(1997, 8, 1),
                    RegistrationDate = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    FirstName = "Yurii",
                    LastName = "Smazhniy",
                    UserName = "Muzilko",
                    Email = "yurii@gmail.com",
                    PasswordHash = "password",
                    DateOfBirth = new DateTime(1998, 8, 11),
                    RegistrationDate = DateTime.Now
                });
        }
    }
}
