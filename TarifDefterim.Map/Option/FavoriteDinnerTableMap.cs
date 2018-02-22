using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class FavoriteDinnerTableMap:CoreMap<FavoriteDinnerTable>
    {

        public FavoriteDinnerTableMap()
        {

            // Table property settings

            ToTable("dbo.FavoriteDinnerTables");

            // Table relations

            // AppUser relation

            HasRequired(x => x.AppUser)
                .WithMany(x => x.FavoriteDinnerTables)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            // DinnerTable table relation

            HasRequired(x => x.DinnerTable)
                .WithMany(x => x.FavoriteDinnerTables)
                .HasForeignKey(x => x.DinnerTableID)
                .WillCascadeOnDelete(false);

            // 

        }
    }
}
