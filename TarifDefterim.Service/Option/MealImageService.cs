﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;
using TarifDefterim.Service.BaseService;

namespace TarifDefterim.Service.Option
{
    public class MealImageService:MainService<MealImage>
    {

        public MealImage TakeFirstMealImagePath(Guid id) {

            return GetFirstOrDefault(x => x.MealID == id && x.Status == Status.Active);

        }

    }
}
