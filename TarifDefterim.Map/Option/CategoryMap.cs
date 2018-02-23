using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class CategoryMap:CoreMap<Category>
    {

        public CategoryMap()
        {

            // Table property settings

            ToTable("dbo.Categories");
            Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasMaxLength(120).IsOptional();

            // Table Relations

            // AssingCategory table relation

            HasMany(x => x.AssignedCategories)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

            // SubCategory table relation

            /*HasMany(x => x.SubCategories)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryID);*/

        }

    }
}
