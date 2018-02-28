using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class RecipeDTO
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public Int16 Alignment { get; set; }
    }
}