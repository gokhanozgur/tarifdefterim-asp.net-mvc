﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class IngredientDTO
    {

        public Guid ID { get; set; }

        public string IngredientName { get; set; }

        public string Description { get; set; }

        public List<Kind> Kinds { get; set; }

    }
}