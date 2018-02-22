using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class RecipeMap:CoreMap<Recipe>
    {

        public RecipeMap()
        {
            // Table property settings

            ToTable("dbo.Recipes");
            Property(x => x.Description).HasMaxLength(250);

            // Table relations

            // RecipeLike table relation

            HasMany(x => x.RecipeLikes)
                .WithRequired(x => x.Recipe)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);

            // Meal table relation

            HasRequired(x => x.Meal)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);

            // Comment table relation

            HasMany(x => x.Comments)
                .WithRequired(x => x.Recipe)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);
        }

    }
}
