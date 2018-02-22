using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class CommentMap:CoreMap<Comment>
    {

        public CommentMap()
        {
            // Table property settings

            ToTable("dbo.Comments");
            Property(x => x.UserComment).HasMaxLength(250).IsRequired();

            // Table relations

            // AppUser table relation

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            // Recipre table relation

            HasRequired(x => x.Recipe)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.RecipeID)
                .WillCascadeOnDelete(false);


        }

    }
}
