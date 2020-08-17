using CourseProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.DataAccess.Configurations
{
    class CourseToUserConfiguration : IEntityTypeConfiguration<CourseToUser>
    {
        public void Configure(EntityTypeBuilder<CourseToUser> builder)
        {
            builder.HasKey(x => new { x.UserId, x.CourseId, x.StartDate });
            builder.HasOne(u => u.User).WithMany(c => c.CourseToStudents).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.Course).WithMany(u => u.CourseToStudents).HasForeignKey(c => c.CourseId);

            builder.HasData(
                new CourseToUser
                {
                    UserId = 1,
                    CourseId = 1,
                    StartDate = DateTime.Now.AddDays(15)
                },
                new CourseToUser
                {
                    UserId = 1,
                    CourseId = 2,
                    StartDate = DateTime.Now.AddDays(15)
                },
                new CourseToUser
                {
                    UserId = 2,
                    CourseId = 2,
                    StartDate = DateTime.Now.AddDays(15)
                },
                new CourseToUser
                {
                    UserId = 2,
                    CourseId = 2,
                    StartDate = DateTime.Now.AddDays(15)
                },
                new CourseToUser
                {
                    UserId = 2,
                    CourseId = 3,
                    StartDate = DateTime.Now.AddDays(15)
                });
        }
    }
}
