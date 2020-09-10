using CourseProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CourseProject.DataAccess.Configurations
{
    class CourseToUserConfiguration : IEntityTypeConfiguration<CourseToUser>
    {
        public void Configure(EntityTypeBuilder<CourseToUser> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.UserId });

            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseToUsers)
                .HasForeignKey(x => x.CourseId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.CourseToUsers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new CourseToUser
                {
                    UserId = 2,
                    CourseId = 1,
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(30)
                },
                new CourseToUser
                {
                    UserId = 2,
                    CourseId = 2,
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(30)
                });
        }
    }
}
