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

namespace TarifDefterim.UI.Controllers
{
    public class MealController : Controller
    {

        MealService _mealService;
        MealImageService _mealImage;
        AppUserService _appUserService;
        AssignedCategoryService _assignedCategoryService;

        public MealController()
        {
            _mealService = new MealService();
            _mealImage = new MealImageService();
            _appUserService = new AppUserService();
            _assignedCategoryService = new AssignedCategoryService();
        }

        //Bu metot PartialView'i yönlendirmek için kullanılıyor. ChildActionOnly bu action'ın sadece bu durumlarda çağırılabileceğini belirtir.Opsiyoneldir... 
        [ChildActionOnly]
        public ActionResult GetSliderContent()
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
                model.FullName = _appUserService.TakeMealCreatetorFullName(item.AppUser.UserName);
                model.AssignedCategories = _assignedCategoryService.GetByExp(x => x.MealID == model.ID && x.Status == Status.Active);
                model.RandomImagePath = _mealImage.TakeFirstMealImagePath(item.ID);

                modelList.Add(model);
            }

            return PartialView("_version_1_Slider", modelList);
        }

        [ChildActionOnly]
        public ActionResult GetMealContent(int page=1)
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
                model.RandomImagePath = _mealImage.TakeFirstMealImagePath(model.ID);

                modelList.Add(model);
            }

            return PartialView("_version_1_MealList", modelList.ToPagedList(page,5));

        }
    }
}