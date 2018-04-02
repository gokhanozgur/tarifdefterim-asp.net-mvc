using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class SubscriberMap:CoreMap<Subscriber>
    {

        public SubscriberMap()
        {
            ToTable("dbo.Subscriber");
            Property(x => x.Email).HasMaxLength(100).IsRequired();
        }

    }
}
