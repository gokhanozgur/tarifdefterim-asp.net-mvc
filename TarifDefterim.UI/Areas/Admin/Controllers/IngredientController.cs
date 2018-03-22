using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;
using TarifDefterim.UI.Areas.Admin.Models.VM;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    public class IngredientController : Controller
    {
        IngredientService _ingredientService;
        KindService _kindService;
        public IngredientController()
        {
            _ingredientService = new IngredientService();
            _kindService = new KindService();

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

            IngredientVM model = new IngredientVM();

            model.Ingredients = _ingredientService.GetAll();

            //List<Ingredient> model = _ingredientService.GetAll();

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


    }
}