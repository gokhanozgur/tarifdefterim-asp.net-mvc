using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.VM
{
    public class IngredientVM
    {

        public IngredientVM()
        {
            Kind = new Kind();
        }

        public Guid ID { get; set; }

        public string IngredientName { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public Kind Kind { get; set; }

        public Status Status { get; set; }

    }
}