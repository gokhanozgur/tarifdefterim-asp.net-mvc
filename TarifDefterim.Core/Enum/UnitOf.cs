using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifDefterim.Core.Enum
{
    public enum UnitOf
    {
        [Display(Name = "Belirtilmiyor")]
        None = 0,
        mg = 1,
        gr = 2,
        kg = 3,
        [Display(Name ="Litre")]
        liter = 4,
        [Display(Name ="Tane")]
        piece = 5

    }
}
