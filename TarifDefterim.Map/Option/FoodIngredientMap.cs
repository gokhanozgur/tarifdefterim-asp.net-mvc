using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class FoodIngredientMap:CoreMap<FoodIngredient>
    {

        public FoodIngredientMap()
        {
            // Table property settings

            ToTable("dbo.FoodIngredients");
            Property(x => x.Quantity);
            Property(x => x.UnitOf);

            // Table Relations

            // Meal table relation

            HasRequired(x => x.Meal)
                .WithMany(x => x.FoodIngredients)
                .HasForeignKey(x => x.IngredientID)
                .WillCascadeOnDelete(false);

            // Ingredient table relation

            HasRequired(x => x.Ingredient)
                .WithMany(x => x.FoodIngredients)
                .HasForeignKey(x => x.IngredientID)
                .WillCascadeOnDelete(false);

        }

    }
}
