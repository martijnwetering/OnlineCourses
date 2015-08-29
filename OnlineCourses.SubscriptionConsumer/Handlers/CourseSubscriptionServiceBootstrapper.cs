using MassTransit;
using Microsoft.Practices.Unity;
using OnlineCourses.SubscriptionConsumer.Configuration;
using OnlineCourses.SubscriptionConsumer.Consumers;

namespace OnlineCourses.SubscriptionConsumer.Handlers
{
    public class CourseSubscriptionServiceBootstrapper
    {
        private IUnityContainer _container;

        public void Start()
        {
            _container = UnityConfig.GetConfiguredContainer(sbc =>
            {
                sbc.Subscribe(subs =>
                {
                    subs.Consumer<CourseSubscriptionConsumer>().Permanent();
                });
            });
        }

        public void Stop()
        {
            _container.Dispose();
        }
    }
}