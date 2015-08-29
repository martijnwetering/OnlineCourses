using System;
using MassTransit;

namespace OnlineCourses.Contracts.Messages
{
    public interface ICourseSubscriptionCommand : CorrelatedBy<Guid>
    {
        string FirstName { get; }
        string LastName { get; }
        string MiddleName { get; }
        string Email { get; }
        DateTime BirthDate { get; }
        int CourseId { get; }
        string CourseName { get; }
    }
}