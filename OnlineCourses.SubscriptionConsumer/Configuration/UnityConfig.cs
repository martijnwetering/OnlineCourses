using System;
using MassTransit;
using MassTransit.BusConfigurators;
using Microsoft.Practices.Unity;
using OnlineCourses.Contracts.Data;
using OnlineCourses.Contracts.Messages;
using OnlineCourses.Data;
using OnlineCourses.Data.Repositories;
using OnlineCourses.Model.Domain;
using OnlineCourses.SubscriptionConsumer.Consumers;

namespace OnlineCourses.SubscriptionConsumer.Configuration
{
    public class UnityConfig
    {
        private static readonly string _rabbitMQBaseUri = "rabbitmq://localhost/OnlineCourses_";
        private static readonly string _queueName = "subscriptionconsumer";
        private static readonly int _retryLimit = 5;

        private static IUnityContainer _container;

        public static IUnityContainer GetConfiguredContainer(Action<ServiceBusConfigurator> extraConfig = null)
        {
            if (_container == null)
            {
                _container = new UnityContainer();
                RegisterTypes(_container, extraConfig);
                return _container;
            }
            return _container;
        }

        private static void RegisterTypes(IUnityContainer container, Action<ServiceBusConfigurator> extraConfig)
        {
            container.RegisterInstance<IServiceBus>(ServiceBusFactory.New(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.ReceiveFrom($"{_rabbitMQBaseUri}{_queueName}");

                sbc.SetDefaultRetryLimit(_retryLimit);
                sbc.DisablePerformanceCounters();

                if (extraConfig != null)
                    extraConfig(sbc);
            }));

            container.RegisterType<IRepository<CourseSubscription>, EFRepository<CourseSubscription>>(
                new InjectionConstructor(new OnlineCoursesDbContext()));
        }
    }
}