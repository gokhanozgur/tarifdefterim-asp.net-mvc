using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class AssignedCategoryService:MainService<AssignedCategory>
    {

        public bool IsAssignedCategoryAlreadyExist(Guid mealID,Guid categoryID)
        {
            return Any(x => x.MealID == mealID && x.CategoryID == categoryID);
        }        

        public bool AddAssignedCategoryFromMealController(Guid mealID, Guid categoryID)
        {

            AssignedCategory assignedCategory = new AssignedCategory();
            assignedCategory.MealID = mealID;
            assignedCategory.CategoryID = categoryID;

            try
            {
                Add(assignedCategory);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }


    }
}
