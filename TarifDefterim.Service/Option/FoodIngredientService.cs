using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class FoodIngredientService:MainService<FoodIngredient>
    {

        public bool IsIngredientAlreadyExist(Guid id)
        {
            return Any(x => x.MealID == id);
        }

        public List<FoodIngredient> GetRecipeInfo(Guid id)
        {

            List<FoodIngredient> foodIngredient = GetByExp(x => x.MealID == id && x.Status != Core.Enum.Status.Deleted);
            return foodIngredient;

        }

        public bool AddFoodIngredientFromList(List<FoodIngredient> foodIngredientList)
        {
            try
            {
                Add(foodIngredientList);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RemoveIngredientFromSelectedItem(Guid id)
        {
            try
            {
                Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
