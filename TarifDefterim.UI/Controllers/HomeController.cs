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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index(Guid? id)
        {
            //ID API üzerinden gönderiliyor. Eğer boş ise authentication yapmıyoruz.
            if (id != null)
            {
                AppUser user = _appUserService.GetByID((Guid)id);
                FormsAuthentication.SetAuthCookie(user.UserName, true);

                if (user.Role == Role.Admin) return Redirect("/Admin/Home/Index");
                if (user.Role == Role.Member) return View();


            }

            return View();
        }

        public RedirectResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}