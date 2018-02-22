using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class SubCategoryMap:CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {

            // Table Settings

            ToTable("dbo.SubCategory");
            Property(x => x.SubCategoryName).HasMaxLength(150).IsRequired();
            Property(x => x.Description).HasMaxLength(150).IsOptional();


            // Table Relations

            // Category table relation

            HasRequired(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

        }

    }
}
