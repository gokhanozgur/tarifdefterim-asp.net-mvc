using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class DinnerTableLikeMap:CoreMap<DinnerTableLike>
    {

        public DinnerTableLikeMap()
        {

            // Table property settings

            ToTable("dbo.DinnerTableLikes");

            // Table relations

            // AppUser table relation

            HasRequired(x => x.AppUser)
                .WithMany(x => x.DinnerTableLikes)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            // DinnerTable table relation

            HasRequired(x => x.DinnerTable)
                .WithMany(x => x.DinnerTableLikes)
                .HasForeignKey(x => x.DinnerTableID)
                .WillCascadeOnDelete(false);

        }
    }
}
