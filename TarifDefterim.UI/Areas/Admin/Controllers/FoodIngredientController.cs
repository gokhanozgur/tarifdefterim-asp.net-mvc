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
    public class FoodIngredientController : Controller
    {

        FoodIngredientService _foodIngredient;


        public FoodIngredientController()
        {
            _foodIngredient = new FoodIngredientService();
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
                        IngredientName = x.Ingredient.IngredientName,
                        Quantity = x.Quantity,
                        UnitOf = Enum.GetName(typeof(UnitOf), x.UnitOf)

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

        public JsonResult AddIngredientFromList(string id, string[] Quantity, string[] UnitOf, string[] IngredientID)
        {

            if (id == null || Quantity.Count() <= 0 || UnitOf.Count() <= 0 || IngredientID.Count() <= 0)
            {
                return Json("Malzeme listesi boş olamaz.", JsonRequestBehavior.AllowGet);
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
                foodIngredient.UnitOf = (TarifDefterim.Core.Enum.UnitOf)Enum.Parse(typeof(UnitOf), UnitOf[i]);

                foodIngredientList.Add(foodIngredient);

            }

            try
            {
                _foodIngredient.Add(foodIngredientList);

                return Json("İşlem başarılı.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("İşlem başarısız. " + ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult RemoveIngredient(string id)
        {

            Guid ingredientID = new Guid(id);

            bool result = _foodIngredient.RemoveIngredientFromSelectedItem(ingredientID);

            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}