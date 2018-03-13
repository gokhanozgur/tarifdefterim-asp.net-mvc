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
        MealService _mealService;

        public HomeController()
        {
            _appUserService = new AppUserService();
            _mealService = new MealService();
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

                if (user.Role == Role.Admin || user.Role == Role.Cook) return Redirect("/Admin/Home/Index");
                else if (user.Role == Role.Member) return View();
            }
            else if(User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserService.FindByUserName(User.Identity.Name);

                if (user.Role == Role.Admin || user.Role == Role.Cook) return Redirect("/Admin/Home/Index");
                else if (user.Role == Role.Member) return View();
            }

            return View();
        }

        public RedirectResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        //Bu metot PartialView'i yönlendirmek için kullanılıyor. ChildActionOnly bu action'ın sadece bu durumlarda çağırılabileceğini belirtir.Opsiyoneldir... 
        [ChildActionOnly]
        public ActionResult GetSliderContent()
        {
            return PartialView("_version_1_Slider", _mealService.GetSliderMeals());
        }

    }
}