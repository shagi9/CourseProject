using CourseProject.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataAccess.DataContext
{
    public class DBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseToUser> CoursesToUsers { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
