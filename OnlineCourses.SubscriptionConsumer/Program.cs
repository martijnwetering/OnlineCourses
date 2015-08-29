using OnlineCourses.SubscriptionConsumer.Handlers;
using Topshelf;

namespace OnlineCourses.SubscriptionConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                c.SetServiceName("OnlineCourses.CourseSubscriptionConsumer");
                c.RunAsLocalSystem();
                c.Service<CourseSubscriptionServiceBootstrapper>(s =>
                {
                    s.ConstructUsing(name => new CourseSubscriptionServiceBootstrapper());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
            });
        }
    }
}
