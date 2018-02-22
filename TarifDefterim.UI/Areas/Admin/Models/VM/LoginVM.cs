using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarifDefterim.UI.Areas.Admin.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Kullanıcı bilgisi gereklidir.")]
        public string User { get; set; }

        [Required(ErrorMessage ="Kullanıcı şifresi gereklidir.")]
        public string Password { get; set; }

        //public string RememberMe { get; set; }

    }
}