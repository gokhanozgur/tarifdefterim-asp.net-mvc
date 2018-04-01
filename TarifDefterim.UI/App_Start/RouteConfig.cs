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

            // Username kontrolü rotası

            routes.MapRoute(
              name: "CheckUserNameFromUI",
              url: "Home/CheckUserNameFromRegisterForm/{username}",
              defaults: new { controller = "Home", action = "CheckUserNameFromRegisterForm", username = UrlParameter.Optional },
              namespaces: new[] { "TarifDefterim.UI.Controllers" }
            );

            // Email kontrolü rotası

            routes.MapRoute(
              name: "CheckEmailFromUI",
              url: "Home/CheckEMailFromRegisterForm/{email}",
              defaults: new { controller = "Home", action = "CheckEMailFromRegisterForm", email = UrlParameter.Optional },
              namespaces: new[] { "TarifDefterim.UI.Controllers" }
            );


            // Hata kontrolü rotası

            routes.MapRoute(
              name: "Error",
              url: "Error/{code}",
              defaults: new { controller = "Error", action = "Page404", code = UrlParameter.Optional }
            );


            // Default

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TarifDefterim.UI.Controllers" }
            );  

        }
    }
}
