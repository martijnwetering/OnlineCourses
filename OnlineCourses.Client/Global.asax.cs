using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineCourses.Data;
using OnlineCourses.Data.SampleData;

namespace OnlineCourses.Client
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityWebActivator.Start();
            //Database.SetInitializer<OnlineCoursesDbContext>(null);
            
            //var context = new OnlineCoursesDbContext();
            //context.Database.Initialize(true); 
        }
    }
}