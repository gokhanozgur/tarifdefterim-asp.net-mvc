using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.VM
{
    public class AppUserRoleAndStatus
    {

        public Role Role { get; set; }

        public Status Status { get; set; }

    }
}