using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class DinnerTableMap:CoreMap<DinnerTable>
    {

        public DinnerTableMap()
        {

            // Table property settings

            ToTable("dbo.DinnerTables");
            Property(x => x.DinnerName);
            Property(x => x.Slug);

            // Table relations

            // AppUser table relation

            HasRequired(x => x.AppUser)
                .WithMany(x => x.DinnerTables)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            // DinnerTableImage table relation

            HasMany(x => x.DinnderTableImages)
                .WithRequired(x => x.DinnerTable)
                .HasForeignKey(x => x.DinnerTableID)
                .WillCascadeOnDelete(false);

            // Meal table relation

            HasMany(x => x.Meals)
                .WithMany(x => x.DinnerTables);

            // DinnerTableLike table relation

            HasMany(x => x.DinnerTableLikes)
                .WithRequired(x => x.DinnerTable)
                .HasForeignKey(x => x.DinnerTableID)
                .WillCascadeOnDelete(false);


        }

    }
}
