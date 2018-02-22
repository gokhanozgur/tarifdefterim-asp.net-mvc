using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class FavoriteMealMap:CoreMap<FavoriteMeal>
    {

        public FavoriteMealMap()
        {

            // Table property settings

            ToTable("dbo.FavoriMeals");

            // Table relations

            // AppUser relation

            HasRequired(x => x.AppUser)
                .WithMany(x => x.FavoriteMeals)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            // Meal table relation

            HasRequired(x => x.Meal)
                .WithMany(x => x.FavoriteMeals)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);

            // 

        }

    }
}
