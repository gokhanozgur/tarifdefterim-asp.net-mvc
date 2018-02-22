using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifDefterim.Core.Enum
{
    public enum Time
    {
        [Display(Name = "Belirtilmiyor")]
        None =0,
        [Display(Name ="Saniye")]
        Second=1,
        [Display(Name = "Dakika")]
        Minute =2,
        [Display(Name = "Saat")]
        Hour =3,
        [Display(Name = "Gün")]
        Day =4

    }
}
