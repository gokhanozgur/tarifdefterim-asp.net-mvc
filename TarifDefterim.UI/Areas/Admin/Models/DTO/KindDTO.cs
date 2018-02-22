using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class KindDTO
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

    }
}