using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class RecipeService:MainService<Recipe>
    {

        public bool IsRecipAlreadyExist(Guid id)
        {
            return Any(x => x.MealID == id);
        }

    }
}
