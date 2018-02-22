using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class SubCategory:CoreEntity
    {

        public string SubCategoryName { get; set; }

        public string Description { get; set; }

        public Guid CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<AssignedCategory> AssignedCategories { get; set; }

    }
}
