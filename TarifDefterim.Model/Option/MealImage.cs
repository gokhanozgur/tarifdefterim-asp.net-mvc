using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class MealImage:CoreEntity
    {
        public string ImageURL { get; set; }

        public Guid MealID { get; set; }

        public virtual Meal Meal { get; set; }

    }
}
