using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class MealImageMap:CoreMap<MealImage>
    {

        public MealImageMap()
        {
            // Table property settings

            ToTable("dbo.MealImages");
            Property(x => x.ImageURL).HasMaxLength(50);


            // Table relations

            // Meal table relation

            HasRequired(x => x.Meal)
                .WithMany(x => x.MealImages)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);
        }

    }
}
