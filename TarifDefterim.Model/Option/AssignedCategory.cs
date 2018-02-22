using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class AssignedCategory:CoreEntity
    {
        public Guid MealID { get; set; }

        public Guid CategoryID { get; set; }

        public Guid SubCategoryID { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual Category Category { get; set; }

        public virtual SubCategory SubCategory { get; set; }

    }
}
