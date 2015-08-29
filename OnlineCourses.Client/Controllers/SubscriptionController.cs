using System;
using System.Web.Mvc;
using MassTransit;
using OnlineCourses.Client.Models;
using OnlineCourses.Contracts.Messages;

namespace OnlineCourses.Client.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IServiceBus _bus;

        public SubscriptionController(IServiceBus bus)
        {
            _bus = bus;
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(SubscriptionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CourseSubscriptionCommand
                {
                    CorrelationId = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    CourseName = model.CourseName,
                    CourseId = model.CourseId

                };

                _bus.Publish<ICourseSubscriptionCommand>(command, x => x.SetDeliveryMode(DeliveryMode.Persistent));

                return View("SubscriptionConfirmation");
            }
            return View(model);
        }
    }
}