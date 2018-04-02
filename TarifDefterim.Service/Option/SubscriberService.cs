﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class SubscriberService:MainService<Subscriber>
    {

        public bool IsExistMail(string email)
        {
            return Any(x => x.Email == email);
        }

    }
}
