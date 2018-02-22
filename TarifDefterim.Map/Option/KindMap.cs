using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class KindMap:CoreMap<Kind>
    {

        public KindMap()
        {
            // Table property settings

            ToTable("dbo.Kinds");
            Property(x => x.Name).HasMaxLength(25).IsRequired();
            Property(x => x.Description).HasMaxLength(120);

            // Table relations

            // Ingredient table relation

            HasMany(x => x.Ingredients)
                .WithRequired(x => x.Kind)
                .HasForeignKey(x => x.KindID)
                .WillCascadeOnDelete(false);
        }

    }
}
