using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class Category:CoreEntity
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public virtual List<AssignedCategory> AssignedCategories { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }

    }
}
