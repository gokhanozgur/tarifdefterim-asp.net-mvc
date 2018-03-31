using System.Web.Mvc;

namespace TarifDefterim.UI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            // Username kontrolü rotası

            context.MapRoute(
                "CheckUserName",
                "Admin/{controller}/{action}/{username}",
                defaults: new { controller = "AppUser", action = "CheckUserName", username = UrlParameter.Optional },
                namespaces: new[] { "TarifDefterim.UI.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TarifDefterim.UI.Areas.Admin.Controllers" }
            );
        }
    }
}