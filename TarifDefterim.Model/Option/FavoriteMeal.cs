using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class FavoriteMeal:CoreEntity
    {
        public Guid MealID { get; set; }

        public Guid AppUserID { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
