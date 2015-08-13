using System.Web.Mvc;
using System.Web.Routing;

namespace HN.Pim.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "accountRegisterRoot",
                url: "account/register",
                defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
                name: "accountRegister",
                url: "account/register/{*catchall}",
                defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
              name: "reserveProductRoot",
              url: "customer/reserveproduct",
              defaults: new { controller = "Customer", action = "ReserveProduct" });

            routes.MapRoute(
                name: "reserveProduct",
                url: "customer/reserveproduct/{*catchall}",
                defaults: new { controller = "Customer", action = "ReserveProduct" });

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
