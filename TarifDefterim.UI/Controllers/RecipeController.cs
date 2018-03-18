using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Controllers
{
    public class RecipeController : Controller
    {

        MealService _mealService;

        public RecipeController()
        {
            _mealService = new MealService();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RecipeDetail()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetMealContent(int page = 1)
        {

            List<Meal> model = _mealService.GetActive().OrderByDescending(x => x.CreatedDate).ToList();

            return PartialView("_version_1_RecipePage_MealList", model.ToPagedList(page, 5));

        }

    }
}