using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;
using TarifDefterim.Core.Enum;

namespace TarifDefterim.Service.Option
{
    public class MealService:MainService<Meal>
    {
        public List<Meal> GetSliderMeals()
        {

            List<Meal> SliderMeals = GetByExp(x => x.IsSliderActive == Status.Active).ToList();
            return SliderMeals;

        }        

    }
}
