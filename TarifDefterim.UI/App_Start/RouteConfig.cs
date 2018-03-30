using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TarifDefterim.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Dikkat: Default rota her zaman aşağıda kalmalıdır.
            
            // Slug kontrolü rotası

            routes.MapRoute(
              name: "RecipeDetail",
              url: "Recipe/RecipeDetail/{slug}",
              defaults: new { controller = "Recipe", action = "RecipeDetail", slug = "" },
              namespaces: new[] { "TarifDefterim.UI.Controllers" } // Area içerisindeki aynı isimdeki controller ile çakışmaması için kullanıyoruz.
            );

            // Default

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TarifDefterim.UI.Controllers" }
            );


            // Hata kontrolü rotası

            routes.MapRoute(
              name: "Error",
              url: "Error/{code}",
              defaults: new { controller = "Error", action = "Page404", code = UrlParameter.Optional }
            );

            // Username kontrolü rotası

            routes.MapRoute(
              name: "CheckUserName",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "AppUser", action = "CheckUserName", id = UrlParameter.Optional }
            );            

                 


        }
    }
}
