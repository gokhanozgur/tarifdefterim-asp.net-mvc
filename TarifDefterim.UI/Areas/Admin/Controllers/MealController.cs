using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;
using TarifDefterim.UI.Areas.Admin.Models.VM;
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
        IngredientService _ingredientService;
        MealImageService _mealImageService;

        public MealController()
        {
            _mealService = new MealService();
            _appUserService = new AppUserService();
            _categoryService = new CategoryService();
            _assignedCategory = new AssignedCategoryService();
            _ingredientService = new IngredientService();
            _mealImageService = new MealImageService();
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
            string slug = GenerateSlug.GenerateSlugURL(data.Name);

            bool IsExistSlugName = _mealService.IsExistSlugName(data.ID,slug);

            if (!IsExistSlugName)
            {
                data.Slug = slug;
            }
            else
            {
                //Random rnd = new Random();
                //data.Slug = slug + "-" + rnd.Next(1, 200);

                data.Slug = slug + "-" + DateTime.Now.ToShortDateString();

            }
            
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
            MealListVM model = new MealListVM();
            model.Meals = _mealService.GetActive();
            model.Ingredients = _ingredientService.GetAll();

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
        public ActionResult UpdateMeal(MealDTO data, string[] Categories)
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

            //update.Slug = GenerateSlug.GenerateSlugURL(data.Name);

            string slug = GenerateSlug.GenerateSlugURL(data.Name);

            bool IsExistSlugName = _mealService.IsExistSlugName(data.ID, slug);

            if (!IsExistSlugName)
            {
                update.Slug = slug;
            }
            else
            {
                update.Slug = slug + "-" + DateTime.Now.ToShortDateString();
            }


            AppUser user = _appUserService.FindByUserName(User.Identity.Name);

            data.AppUserID = user.ID;

            update.AppUserID = data.AppUserID;
            update.Status = data.Status;
            update.IsSliderActive = data.IsSliderActive;


            try
            {

                _mealService.Update(update);

                foreach (var categoryItem in Categories)
                {
                    Guid cGuid = new Guid(categoryItem);

                    Category CatchedCategory = _categoryService.GetByID(cGuid);

                    if (!_assignedCategory.IsAssignedCategoryAlreadyExist(data.ID, CatchedCategory.ID))
                    {
                        _assignedCategory.AddAssignedCategoryFromMealController(data.ID, CatchedCategory.ID);

                    }

                }


                TempData["Basarili"] = "Temel yemek bilgisi sistede başarıyla güncellendi.";
                return RedirectToAction("MealList", "Meal");

            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Temel yemek bilgisi güncelleme işlemi başarısız." + ex.Message;
                return RedirectToAction("UpdateMeal", "Meal", new { id = data.ID});
            }


        }

        public ActionResult MealImages(string id)
        {
            // Bu kısımlar test edilecek.

            Guid mealID = new Guid(id);

            MealImageVM model = new MealImageVM();

            model.MealID = mealID;

            model.MealImages = _mealImageService.GetByExp(x => x.MealID == mealID);

            return View(model);
        }

        [HttpPost]

        public ActionResult MealImages(MealImage data , HttpPostedFileBase Image)
        {

            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalMealImagePath, Image, 2);

            data.ImageURL = UploadedImagePaths[0];

            if (data.ImageURL == "0" || data.ImageURL == "1" || data.ImageURL == "2")
            {
                data.ImageURL = ImageUploader.DefaultMealImagePath;
                data.XSmallMealImage = ImageUploader.DefaultXSmallMealImagePath;
                data.CruptedMealImage = ImageUploader.DefaultCruptedMealImagePath;
            }
            else
            {
                data.XSmallMealImage = UploadedImagePaths[1];
                data.CruptedMealImage = UploadedImagePaths[2];
            }

            try
            {
                _mealImageService.Add(data);
                TempData["Basarili"] = "Resim sisteme eklendi.";
                return RedirectToAction("MealImages", "Meal", new { id = data.MealID });
            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Resim sisteme eklenemedi.";
                return RedirectToAction("MealImages", "Meal", new { id = data.MealID });
            }
            
        }


        public JsonResult RemoveMealImage(string id)
        {
            Guid mealID = new Guid(id);

            try
            {
                _mealImageService.Remove(mealID);
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

    }
}