using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Controllers
{
    public class HomeController : Controller
    {
        AppUserService _appUserService;

        public HomeController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(Guid? id)
        {

            if (id != null)
            {
                AppUser user = _appUserService.GetByID((Guid)id);

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, true);

                        if (user.Role == Role.Admin)
                        {
                            return Redirect("/Admin/Home/Index");
                        }
                    
                    }
                    else
                    {
                        ViewBag.Message = "Bu kullanıcı sistemde kayıtlı değildir.";
                        return View();
                    }
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        
    }
}