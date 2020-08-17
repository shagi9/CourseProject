using CourseProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject.DataAccess.Configurations
{
    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Name = "Build an app with ASPNET Core and Angular from scratch",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1200px-.NET_Logo.svg.png",
                    Description = "his is a complete project based course from start to finish with real world experience using technologies that are currently in demand in the market. People interested in learning latest technologies should consider this course"
                },
                new Course
                {
                    Id = 2,
                    Name = "Build an app with ASPNET Core and Angular from scratch",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1200px-.NET_Logo.svg.png",
                    Description = "his is a complete project based course from start to finish with real world experience using technologies that are currently in demand in the market. People interested in learning latest technologies should consider this course"
                },
                new Course
                {
                    Id = 3,
                    Name = "Build an app with ASPNET Core and Angular from scratch",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1200px-.NET_Logo.svg.png",
                    Description = "his is a complete project based course from start to finish with real world experience using technologies that are currently in demand in the market. People interested in learning latest technologies should consider this course"
                });
        }
    }
}
