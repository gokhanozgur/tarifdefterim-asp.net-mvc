using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class Recipe:CoreEntity
    {
        public string Description { get; set; }

        public Int16 Alignment { get; set; }

        public Guid MealID { get; set; }        

        public virtual Meal Meal { get; set; }

        public virtual List<RecipeLike> RecipeLikes { get; set; }

        //public virtual List<Comment> Comments { get; set; }


    }
}
