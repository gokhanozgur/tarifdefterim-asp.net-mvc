using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class MealImageService:MainService<MealImage>
    {

        public string TakeFirstMealImagePath(Guid id) {

            return GetByExp(x => x.MealID == id && x.Status == Status.Active).Select(x => new { x.CruptedMealImage }).ToString();

        }

    }
}
