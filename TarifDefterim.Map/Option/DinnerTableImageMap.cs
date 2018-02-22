using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class DinnerTableImageMap:CoreMap<DinnerTableImage>
    {

        public DinnerTableImageMap()
        {

            // Table property settings

            ToTable("dbo.DinnerTableImages");
            Property(x => x.ImageURL).HasMaxLength(50);

            // Table relations

            // DinnerTable table relation

            HasRequired(x => x.DinnerTable)
                .WithMany(x => x.DinnderTableImages)
                .HasForeignKey(x => x.DinnerTableID)
                .WillCascadeOnDelete(false);

        }

    }
}
