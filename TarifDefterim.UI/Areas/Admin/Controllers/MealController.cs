using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;
using TarifDefterim.UI.Authorize;
using TarifDefterim.Utility;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    [UserAuthorize(Role.Admin, Role.Cook)]
    public class MealController : Controller
    {

        MealService _mealService;
        AppUserService _appUserService;
        CategoryService _categoryService;
        AssignedCategoryService _assignedCategory;


        public MealController()
        {
            _mealService = new MealService();
            _appUserService = new AppUserService();
            _categoryService = new CategoryService();
            _assignedCategory = new AssignedCategoryService();
        }
        
        public ActionResult AddMeal()
        {

            MealDTO model = new MealDTO();
            model.Categories = _categoryService.GetActive();

            return View(model);

        }

        [HttpPost]
        public ActionResult AddMeal(Meal data, string[] Categories)
        {

            data.Slug = GenerateSlug.GenerateSlugURL(data.Name);

            AppUser user = _appUserService.FindByUserName(User.Identity.Name);

            data.AppUserID = user.ID;
            

            try
            {

                _mealService.Add(data);

                foreach (var categoryItem in Categories)
                {
                    Guid cGuid = new Guid(categoryItem);

                    Category CatchedCategory = _categoryService.GetByID(cGuid);

                    if (!_assignedCategory.IsAssignedCategoryAlreadyExist(data.ID,CatchedCategory.ID))
                    {
                        _assignedCategory.AddAssignedCategoryFromMealController(data.ID, CatchedCategory.ID);

                    }

                }


                TempData["Basarili"] = "Temel yemek bilgisi sisteme başarıyla eklendi.";
                return RedirectToAction("MealList","Meal");

            }
            catch (Exception ex)
            {

                TempData["Hata"] = "Temel yemek bilgisi sisteme ekleme işlemi başarısız. - "+ ex.Message;
                return RedirectToAction("AddMeal", "Meal");

            }

        }

        public ActionResult MealList()
        {

            List<Meal> model = _mealService.GetAll();

            return View(model);

        }

        public ActionResult UpdateMeal(Guid id)
        {

            Meal meal = _mealService.GetByID(id);

            MealDTO model = new MealDTO();

            model.ID = meal.ID;
            model.Name = meal.Name;
            model.Description = meal.Description;
            model.PreparationTime = meal.PreparationTime;
            model.PreparationTimeUnitOf = meal.PreparationTimeUnitOf;
            model.CookingTime = meal.CookingTime;
            model.CookingTimeUnitOf = meal.CookingTimeUnitOf;
            model.Person = meal.Person;
            model.Tricks = meal.Tricks;
            model.VideoURL = meal.VideoURL;
            model.Status = meal.Status;
            model.IsSliderActive = meal.IsSliderActive;

            model.Categories = _categoryService.GetActive();

            // atanmış kategorilerden kontrol edilerek çekilmeli

            return View(model);

        }

        [HttpPost]
        public ActionResult UpdateMeal(MealDTO data)
        {

            Meal update = _mealService.GetByID(data.ID);

            update.Name = data.Name;
            update.Description = data.Description;
            update.PreparationTime = data.PreparationTime;
            update.PreparationTimeUnitOf = data.PreparationTimeUnitOf;
            update.CookingTime = data.CookingTime;
            update.CookingTimeUnitOf = data.CookingTimeUnitOf;
            update.Person = data.Person;
            update.Tricks = data.Tricks;
            update.VideoURL = data.VideoURL;

            update.Slug = GenerateSlug.GenerateSlugURL(data.Name);


            AppUser user = _appUserService.FindByUserName(User.Identity.Name);

            data.AppUserID = user.ID;

            update.AppUserID = data.AppUserID;
            update.Status = data.Status;
            update.IsSliderActive = data.IsSliderActive;


            try
            {

                _mealService.Update(update);
                TempData["Basarili"] = "Temel yemek bilgisi sistede başarıyla güncellendi.";
                return RedirectToAction("MealList", "Meal");

            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Temel yemek bilgisi güncelleme işlemi başarısız." + ex.Message;
                return RedirectToAction("UpdateMeal", "Meal", new { id = data.ID});
            }


        }

    }
}