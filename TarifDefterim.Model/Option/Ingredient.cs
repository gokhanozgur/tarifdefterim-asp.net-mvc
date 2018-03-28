using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class Ingredient:CoreEntity
    {
        public string IngredientName { get; set; }

        public string Description { get; set; }

        public Guid KindID { get; set; }

        public virtual List<FoodIngredient> FoodIngredients { get; set; }

        /*public virtual List<Benefit> Benefits { get; set; }*/

        /*public virtual List<Loss> Losses { get; set; }*/

        public virtual Kind Kind { get; set; }

    }
}
