namespace BOMB.Web
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    ///   Route Registration
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        ///   Registers the routes.
        /// </summary>
        /// <param name="routes"> The routes. </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            routes.MapRoute(
                name: "Default", 
                url: "{controller}/{action}/{id}", 
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, 
                namespaces: new[] { "BOMB.Web.Controllers" });
        }
    }
}