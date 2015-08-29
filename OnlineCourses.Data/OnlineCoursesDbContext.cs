using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OnlineCourses.Model.Domain;

namespace OnlineCourses.Data
{
    public class Test
    {
        public int Id { get; set; }
    }

    public class OnlineCoursesDbContext : DbContext
    {
        public OnlineCoursesDbContext()
            : base(nameOrConnectionString: "OnlineCourses") { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubscription> Subscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
