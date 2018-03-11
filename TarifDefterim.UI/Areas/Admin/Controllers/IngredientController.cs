using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;

namespace TarifDefterim.UI.Areas.Admin.Controllers
{
    public class IngredientController : Controller
    {
        IngredientService _ıngredientService;
        KindService _kindService;
        public IngredientController()
        {
            _ıngredientService = new IngredientService();
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
                _ıngredientService.Add(data);
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
            List<Ingredient> model = _ıngredientService.GetAll();
            return View(model);
        }

        public ActionResult UpdateIngredient(Guid id)
        {
            Ingredient update = _ıngredientService.GetByID(id);

            IngredientDTO model = new IngredientDTO();

            model.ID = update.ID;
            model.Description = update.Description;
            model.IngredientName = update.IngredientName;
            model.Kinds = _kindService.GetActive();

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateIngredient(Ingredient data)
        {
            return View();
        }

    }
}