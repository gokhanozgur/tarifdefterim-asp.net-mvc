using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.Option;

namespace TarifDefterim.UI.Controllers
{
    public class MealController : Controller
    {

        MealService _mealService;

        public MealController()
        {
            _mealService = new MealService();
        }

        //Bu metot PartialView'i yönlendirmek için kullanılıyor. ChildActionOnly bu action'ın sadece bu durumlarda çağırılabileceğini belirtir.Opsiyoneldir... 
        [ChildActionOnly]
        public ActionResult GetSliderContent()
        {     
            return PartialView("_version_1_Slider", _mealService.GetSliderMeals().OrderByDescending(x => x.CreatedDate));
        }

        [ChildActionOnly]
        public ActionResult GetMealContent(int page=1)
        {

            List<Meal> model = _mealService.GetActive().OrderByDescending(x => x.CreatedDate).ToList();
            
            return PartialView("_version_1_MealList",model.ToPagedList(page,5));

        }
    }
}