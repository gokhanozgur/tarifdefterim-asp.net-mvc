using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.VM;
using TarifDefterim.UI.Authorize;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    [Authorize]
    //[UserAuthorize(Role.Admin)]
    public class HomeController : Controller
    {

        AppUserService _appUserService;
        MealService _mealService;
        CategoryService _categoryService;

        public HomeController()
        {
            _appUserService = new AppUserService();
            _mealService = new MealService();
            _categoryService = new CategoryService();
        }

        public ActionResult Index()
        {
            DashboardVM model = new DashboardVM();
            model.TotalUser = _appUserService.GetTotalAppUser();
            model.TotalMeal = _mealService.GetTotalMeal();
            model.TotalCategory = _categoryService.GetTotalCategory();

            return View(model);
        }
    }
}