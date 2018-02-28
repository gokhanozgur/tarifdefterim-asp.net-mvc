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

        public List<Recipe> GetRecipeInfo(Guid id)
        {

            List<Recipe> recipe = GetByExp(x => x.MealID == id && x.Status != Core.Enum.Status.Deleted);
            return recipe;

        }

        public bool AddRecipeFromList(List<Recipe> mealList)
        {
            try
            {
                Add(mealList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
