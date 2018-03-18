using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class FoodIngredientDTO
    {

        public Guid ID { get; set; }
        public Int16 Quantity { get; set; }
        public string UnitOf { get; set; }

        public string IngredientName { get; set; }

    }
}