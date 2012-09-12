namespace BOMB.Web.Areas.Testing
{
    using System.Web.Mvc;

    /// <summary>
    /// Area Registration for the Testing Area
    /// </summary>
    public class TestingAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        /// <returns>The name of the area to register.</returns>
        public override string AreaName
        {
            get
            {
                return "Testing";
            }
        }

        /// <summary>
        /// Registers an area in an ASP.NET MVC application using the specified area's context information.
        /// </summary>
        /// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Testing_default",
                url: "Testing/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BOMB.Web.Areas.Testing.Controllers" });
        }
    }
}
