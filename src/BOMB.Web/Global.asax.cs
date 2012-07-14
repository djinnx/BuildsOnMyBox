namespace BOMB.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using BOMB.Core;

    /// <summary>
    /// It all starts here...
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Application_s the start.
        /// </summary>
        protected void Application_Start()
        {
            DataMigrations.Run();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}