using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class DinnerTable:CoreEntity
    {
        public string DinnerName { get; set; }

        public string Slug { get; set; }

        public Guid MealID { get; set; }

        public Guid AppUserID { get; set; }

        //public virtual Meal Meal { get; set; }

        public virtual List<DinnerTableImage> DinnderTableImages { get; set; }

        public virtual List<Meal> Meals { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual List<FavoriteDinnerTable> FavoriteDinnerTables { get; set; }

        public virtual List<DinnerTableLike> DinnerTableLikes { get; set; }

    }
}
