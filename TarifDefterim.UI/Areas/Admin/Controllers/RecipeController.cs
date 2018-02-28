﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;
using TarifDefterim.UI.Areas.Admin.Models.DTO;

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

            if (id != null)
            {
                Guid mealID = new Guid(id);

                if (CheckMealRecipe(mealID))
                {
                    List<RecipeDTO> list = _recipeService.GetRecipeInfo(mealID); // Dikkat

                    return Json(list, JsonRequestBehavior.AllowGet);
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


        public bool AddRecipeFromList(string id, string[] Description, string[] Alignment)
        {

            if (id == null || Description.Count() <= 0 || Alignment.Count() <= 0)
            {
                return false;
            }

            Guid mealID = new Guid(id);

            List<Recipe> recipeList = new List<Recipe>();

            Recipe recipe;

            for (int i = 0; i < Description.Length; i++)
            {
                recipe = new Recipe();
                recipe.MealID = mealID;
                recipe.Description = Description[i];
                recipe.Alignment = Convert.ToInt16(Alignment[i]);

                recipeList.Add(recipe);

            }


            try
            {
                _recipeService.AddRecipeFromList(recipeList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            

        }

    }
}