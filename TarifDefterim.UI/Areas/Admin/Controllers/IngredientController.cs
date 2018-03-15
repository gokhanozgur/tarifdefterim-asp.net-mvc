using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    public class IngredientController : Controller
    {
        IngredientService _ingredientService;
        KindService _kindService;
        FoodIngredientService _foodIngredient;
        public IngredientController()
        {
            _ingredientService = new IngredientService();
            _kindService = new KindService();
            _foodIngredient = new FoodIngredientService();

        }

        public ActionResult AddIngredient()
        {

            IngredientDTO model = new IngredientDTO();
            model.Kinds = _kindService.GetActive();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddIngredient(Ingredient data)
        {
            
            try
            {
                _ingredientService.Add(data);
                TempData["Basarili"] = "Malzeme bilgisi sisteme eklendi.";
                return RedirectToAction("IngredientList", "Ingredient");
            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Malzeme bilgisi sisteme eklenemedi. " + ex.Message;
                return RedirectToAction("AddIngredient", "Ingredient");
            }
            
        }

        public ActionResult IngredientList()
        {
            List<Ingredient> model = _ingredientService.GetAll();
            
            return View(model);
        }

        public ActionResult UpdateIngredient(Guid id)
        {
            Ingredient ingredient = _ingredientService.GetByID(id);

            IngredientDTO model = new IngredientDTO();

            model.ID = ingredient.ID;
            model.Description = ingredient.Description;
            model.IngredientName = ingredient.IngredientName;
            model.Kinds = _kindService.GetActive();
            model.Status = ingredient.Status;
            model.KindID = ingredient.KindID;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateIngredient(Ingredient data)
        {

            Ingredient update = _ingredientService.GetByID(data.ID);

            update.IngredientName = data.IngredientName;
            update.Description = data.Description;
            update.KindID = data.KindID;
            update.Status = data.Status;

            try
            {
                _ingredientService.Update(update);
                TempData["Basarili"] = "Malzeme bilgisi güncellendi.";
                return RedirectToAction("IngredientList", "Ingredient");
            }
            catch (Exception ex)
            {
                TempData["Hata"] = "Malzeme bilgisi güncellenirken bir hata oluştu. " + ex.Message;
                return RedirectToAction("UpdateIngredient", "Ingredient" , new { id = data.ID});
            }
            
        }


        public bool CheckIngredient(Guid id)
        {

            bool isExist = _foodIngredient.IsIngredientAlreadyExist(id);
            return isExist;

        }


        public JsonResult GetIngredients(string id)
        {

            if (id != null)
            {
                Guid mealID = new Guid(id);

                if (CheckIngredient(mealID))
                {
                    List<FoodIngredient> recipeList = _foodIngredient.GetRecipeInfo(mealID); // Dikkat                  


                    List<FoodIngredientDTO> ingredientDtoList = recipeList.Select(x => new FoodIngredientDTO()
                    {

                        ID = x.ID,
                        Quantity = x.Quantity,
                        UnitOf = x.UnitOf

                    }).ToList();

                    return Json(ingredientDtoList, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Empty", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("Empty", JsonRequestBehavior.AllowGet);
            }

        }

        public bool AddIngredientFromList(string id, string[] Quantity, string[] UnitOf, string[] IngredientID)
        {

            if (id == null || Quantity.Count() <= 0 || UnitOf.Count() <= 0 || IngredientID.Count() <= 0)
            {
                return false;
            }
            
            Guid mealID = new Guid(id);

            List<FoodIngredient> foodIngredientList = new List<FoodIngredient>();

            FoodIngredient foodIngredient;

            for (int i = 0; i < IngredientID.Count(); i++)
            {
                Guid ingredientID = new Guid(IngredientID[i]);

                foodIngredient = new FoodIngredient();
                foodIngredient.IngredientID = ingredientID;
                foodIngredient.MealID = mealID;
                foodIngredient.Quantity = Int16.Parse(Quantity[i]);
                foodIngredient.UnitOf = (TarifDefterim.Core.Enum.UnitOf)Enum.Parse(typeof(UnitOf),UnitOf[i]);

                foodIngredientList.Add(foodIngredient);

            }

            try
            {
                _foodIngredient.AddFoodIngredientFromList(foodIngredientList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


    }
}