using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class KindService:MainService<Kind>
    {
        public bool IsKindAlreadyExist(string kindName)
        {
            return Any(x => x.Name == kindName);
        }

    }
}
