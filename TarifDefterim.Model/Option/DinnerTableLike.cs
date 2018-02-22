using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;

namespace TarifDefterim.Model.Option
{
    public class DinnerTableLike:CoreEntity
    {

        public Guid AppUserID { get; set; }

        public Guid DinnerTableID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual DinnerTable DinnerTable { get; set; }

    }
}
