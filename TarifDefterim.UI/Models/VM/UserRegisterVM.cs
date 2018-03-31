using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarifDefterim.UI.Models.VM
{
    public class UserRegisterVM
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

    }
}