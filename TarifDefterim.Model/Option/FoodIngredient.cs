using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;
using TarifDefterim.Core.Enum;

namespace TarifDefterim.Model.Option
{
    public class FoodIngredient:CoreEntity
    {
        public Int16 Quantity { get; set; }
        public UnitOf UnitOf { get; set; }

        public Guid MealID { get; set; }

        public Guid IngredientID { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual Ingredient Ingredient { get; set; }

    }
}
