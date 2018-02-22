using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class RecipeLike:CoreEntity
    {
        public Guid AppUserID { get; set; }

        public Guid RecipeID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Recipe Recipe { get; set; }

    }
}
