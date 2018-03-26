using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Models.VM;
using TarifDefterim.Utility;

namespace TarifDefterim.UI.Controllers
{
    public class RecipeController : Controller
    {
        
        MealService _mealService;
        MealImageService _mealImage;
        FoodIngredientService _foodIngredient;
        RecipeService _recipeService;
        CommentService _commentService;

        public RecipeController()
        {
            _mealService = new MealService();
            _mealImage = new MealImageService();
            _foodIngredient = new FoodIngredientService();
            _recipeService = new RecipeService();
            _commentService = new CommentService();
        }
        
        public ActionResult Index()
        {
            return View();
        }


        
        public ActionResult RecipeDetail(string slug)
        {

            Meal meal = _mealService.GetMealDetail(slug);

            MealVM model = new MealVM();
            model.ID = meal.ID;
            model.Name = meal.Name;
            model.Description = meal.Description;
            model.Slug = meal.Slug;
            model.PreparationTime = meal.PreparationTime;
            model.PreparationTimeUnitOf = meal.PreparationTimeUnitOf;
            model.CookingTime = meal.CookingTime;
            model.CookingTimeUnitOf = meal.CookingTimeUnitOf;
            model.Person = meal.Person;
            model.Tricks = meal.Tricks;
            model.VideoURL = meal.VideoURL;

            List<MealImage> mealImageList = _mealImage.GetByExp(x => x.MealID == meal.ID && x.Status == Status.Active);

            if (mealImageList.Count != 0)
            {
                model.MealImages = mealImageList;

                MealImage mImage = _mealImage.TakeFirstMealImagePath(meal.ID);
                model.RandomImagePath = mImage.ImageURL;
            }
            else
            {
                model.RandomImagePath = ImageUploader.DefaultMealImagePath;
            }

            //List<FoodIngredient> foodIngredientList = _foodIngredient.GetByExp(x => x.MealID == meal.ID && x.Status == Status.Active);            

            model.FoodIngredients = _foodIngredient.GetByExp(x => x.MealID == meal.ID && x.Status == Status.Active);

            List<Recipe> recipeList = _recipeService.GetByExp(x => x.MealID == meal.ID && x.Status == Status.Active).OrderBy(x => x.Alignment).ToList();

            model.Recipes = recipeList;

            model.Comments = _commentService.GetByExp(x => x.MealID == meal.ID && x.Status == Status.Active);

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult GetMealContent(int page = 1)
        {

            List<Meal> mealList = new List<Meal>();
            mealList = _mealService.GetSliderMeals().OrderByDescending(x => x.CreatedDate).ToList();

            List<MealVM> modelList = new List<MealVM>();

            foreach (var item in mealList)
            {
                MealVM model = new MealVM();
                model.ID = item.ID;
                model.Name = item.Name;
                model.Description = item.Description;
                model.Slug = item.Slug;
                model.PreparationTime = item.PreparationTime;
                model.PreparationTimeUnitOf = item.PreparationTimeUnitOf;
                model.CookingTime = item.CookingTime;
                model.CookingTimeUnitOf = item.CookingTimeUnitOf;
                model.Person = item.Person;
                model.Tricks = item.Tricks;
                model.VideoURL = item.VideoURL;

                MealImage mImage = _mealImage.TakeFirstMealImagePath(item.ID);

                if (mImage == null)
                {
                    model.RandomImagePath = ImageUploader.DefaultMealImagePath;
                }
                else
                {
                    model.RandomImagePath = mImage.ImageURL;
                }

                modelList.Add(model);
            }

            // ToPagetList kullanmak için NuGet Package Manager`dan PagetList referanslara eklenir.

            return PartialView("_version_1_RecipePage_MealList", modelList.ToPagedList(page, 6));

        }

        public ActionResult AddRecipe()
        {
            return View();
        }

    }
}