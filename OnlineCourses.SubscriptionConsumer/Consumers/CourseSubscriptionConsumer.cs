using System;
using MassTransit;
using Newtonsoft.Json;
using OnlineCourses.Contracts.Data;
using OnlineCourses.Contracts.Messages;
using OnlineCourses.Model.Domain;
using OnlineCourses.SubscriptionConsumer.Configuration;
using Microsoft.Practices.Unity;

namespace OnlineCourses.SubscriptionConsumer.Consumers
{
    public class CourseSubscriptionConsumer : Consumes<ICourseSubscriptionCommand>.Context
    {
        private IRepository<CourseSubscription> _repo;

        public CourseSubscriptionConsumer()
        {
            var container = UnityConfig.GetConfiguredContainer();
            _repo = container.Resolve<IRepository<CourseSubscription>>();
        }

        public void Consume(IConsumeContext<ICourseSubscriptionCommand> command)
        {
            _repo.Add(new CourseSubscription
            {
                FirstName = command.Message.FirstName,
                LastName = command.Message.LastName,
                MiddleName = command.Message.MiddleName,
                BirthDate = command.Message.BirthDate,
                Email = command.Message.Email,
                CourseId = command.Message.CourseId,
                CourseName = command.Message.CourseName
            });
            _repo.Commit();

            Console.WriteLine(JsonConvert.SerializeObject(command.Message, Formatting.Indented));
        }
    }
}