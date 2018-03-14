using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class FoodIngredientDTO
    {

        public Guid ID { get; set; }
        public Int16 Quantity { get; set; }
        public UnitOf UnitOf { get; set; }

    }
}