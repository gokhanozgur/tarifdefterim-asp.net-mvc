﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.VM
{
    public class MealListVM
    {

        public List<Meal> Meals { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public UnitOf UnitOf { get; set; }


    }
}