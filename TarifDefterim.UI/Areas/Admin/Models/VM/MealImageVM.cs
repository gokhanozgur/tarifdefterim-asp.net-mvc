using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarifDefterim.UI.Areas.Admin.Models.VM
{
    public class MealImageVM
    {
        public Guid ID { get; set; }

        public string ImageURL { get; set; }

        public Guid MealID { get; set; }

    }
}