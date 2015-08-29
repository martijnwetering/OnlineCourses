using System;

namespace OnlineCourses.Model.Domain
{
    public class CourseSubscription
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}