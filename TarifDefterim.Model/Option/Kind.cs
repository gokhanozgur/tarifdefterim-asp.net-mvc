using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class Kind:CoreEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }

    }
}
