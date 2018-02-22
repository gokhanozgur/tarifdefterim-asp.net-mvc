using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class RecipeLikeMap : CoreMap<RecipeLike>
    {
        public RecipeLikeMap()
        {
            // Table property settings

            ToTable("dbo.RecipeLikes");

            // Table relations

            // AppUser table relation

            HasRequired(x => x.AppUser)
                .WithMany(x => x.RecipeLikes)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            // RecipeLike table relation

            HasRequired(x => x.Recipe)
                .WithMany(x => x.RecipeLikes)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);

        }
    }
}