using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class IngredientMap:CoreMap<Ingredient>
    {

        public IngredientMap()
        {
            // Table property settings

            ToTable("dbo.Ingredients");
            Property(x => x.IngredientName).HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasMaxLength(120);

            // Table relations

            // FoodIngredient relation

            HasMany(x => x.FoodIngredients)
                .WithRequired(x => x.Ingredient)
                .HasForeignKey(x => x.IngredientID)
                .WillCascadeOnDelete(false);

            // Benefit table relation

            /*HasMany(x => x.Benefits)
                .WithRequired(x => x.Ingredient)
                .HasForeignKey(x => x.IngredientID)
                .WillCascadeOnDelete(false);*/

            // Loss table relation

            /*HasMany(x => x.Losses)
                .WithRequired(x => x.Ingredient)
                .HasForeignKey(x => x.IngredientID)
                .WillCascadeOnDelete(false);*/

            // Kind table relation

            HasRequired(x => x.Kind)
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.KindID)
                .WillCascadeOnDelete(false);

        }

    }
}
