using System.Data.Entity;
using OnlineCourses.Model.Domain;

namespace OnlineCourses.Data.Repositories
{
    public class CourseSubscriptionRepository : EFRepository<CourseSubscription>
    {
        public CourseSubscriptionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}