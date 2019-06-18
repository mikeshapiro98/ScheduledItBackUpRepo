using ScheduleIt2._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace ScheduleIt2._0
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Added to prevent the following error message:(kw)
            //  System.InvalidOperationException: 'The model backing the 'ApplicationDbContext' 
            //  context has changed since the database was created. 
            //  Consider using Code First Migrations to update the database (http://go.microsoft.com/fwlink/?LinkId=238269).'
            Database.SetInitializer<ApplicationDbContext>(null);
        }
    }
}
