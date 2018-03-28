using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class Comment:CoreEntity
    {
        public string UserComment { get; set; }

        //public Guid RecipeID { get; set; }

        public Guid MealID { get; set; }

        public Guid AppUserID { get; set; }

        //public virtual Recipe Recipe { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual AppUser AppUser { get; set; }

    }
}
