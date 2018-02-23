using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class AssignedCategoryMap:CoreMap<AssignedCategory>
    {

        public AssignedCategoryMap()
        {

            // Table property settings

            ToTable("dbo.AssignedCategories");

            // Category table relations

            HasRequired(x => x.Category)
                .WithMany(x => x.AssignedCategories)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

            // Meal table relation

            HasRequired(x => x.Meal)
                .WithMany(x => x.AssignedCategories)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);

            // SubCategory table relation

            /*HasRequired(x => x.SubCategory)
                .WithMany(x => x.AssignedCategories)
                .HasForeignKey(x => x.SubCategoryID)
                .WillCascadeOnDelete(false);*/
             

        }

    }
}
