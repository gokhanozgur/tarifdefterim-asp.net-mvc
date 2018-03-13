using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Areas.Admin.Models.DTO
{
    public class MealDTO
    {

        public MealDTO()
        {
            Categories = new List<Category>();
        }   

        public List<Category> Categories { get; set; }

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }

        public string PreparationTime { get; set; }

        public Time PreparationTimeUnitOf { get; set; }

        public string CookingTime { get; set; }

        public Time CookingTimeUnitOf { get; set; }

        public Int16 Person { get; set; }

        public string Tricks { get; set; }

        public string VideoURL { get; set; }

        public Status IsSliderActive { get; set; }

        public Guid AppUserID { get; set; }

        public Status Status { get; set; }

        public UnitOf UnitOf { get; set; }

    }
}