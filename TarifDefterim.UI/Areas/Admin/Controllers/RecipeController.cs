using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    public class RecipeController : Controller
    {

        RecipeService _recipeService;

        public RecipeController()
        {
            _recipeService = new RecipeService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public bool CheckMealRecipe(Guid id)
        {

            bool isExist = _recipeService.IsRecipAlreadyExist(id);

            //return Json(isExist,JsonRequestBehavior.AllowGet);

            return isExist;

        }

        public JsonResult GetRecipe(string id)
        {

            Guid mealID = new Guid(id);

            if (CheckMealRecipe(mealID))
            {
                List<Recipe> list = _recipeService.GetRecipeInfo(mealID);

                return Json(list,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult AddRecipeFromList(string id)
        {
            bool test = true;
            return Json(test, JsonRequestBehavior.AllowGet);

        }

    }
}