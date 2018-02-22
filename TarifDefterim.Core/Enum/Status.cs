using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifDefterim.Core.Enum
{
    public enum Status
    {
        [Display(Name ="Belirtilmiyor")]
        None=0,
        [Display(Name = "Aktif")]
        Active =1,
        [Display(Name = "Silindi")]
        Deleted =3,
        [Display(Name = "Güncellendi")]
        Updated =5

    }
}
