using System.Data.Entity;
using OnlineCourses.Model.Domain;

namespace OnlineCourses.Data.SampleData
{
    public class OnlineCoursesDatabaseInitializer : DropCreateDatabaseIfModelChanges<OnlineCoursesDbContext>
    {
        protected override void Seed(OnlineCoursesDbContext context)
        {
            var course = new Course { Name = "Bedrijfskunde" };
            context.Courses.Add(course);
            context.SaveChanges();
        }
    }
}
