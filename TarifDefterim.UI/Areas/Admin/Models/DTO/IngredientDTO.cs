using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class IngredientDTO
    {

        public Guid ID { get; set; }

        public Guid KindID { get; set; }

        public string IngredientName { get; set; }

        public string Description { get; set; }

        public List<Kind> Kinds { get; set; }

        public Status Status { get; set; }

    }
}