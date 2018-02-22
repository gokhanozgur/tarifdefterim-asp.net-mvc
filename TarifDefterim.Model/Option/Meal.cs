using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;
using TarifDefterim.Core.Enum;

namespace TarifDefterim.Model.Option
{
    public class Meal:CoreEntity
    {
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

        public Guid AppUserID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual List<AssignedCategory> AssignedCategories { get; set; }

        public virtual List<MealImage> MealImages { get; set; }        

        public virtual List<DinnerTable> DinnerTables { get; set; }

        public virtual List<FoodIngredient> FoodIngredients { get; set; }

        public virtual List<Recipe> Recipes { get; set; }

        public virtual List<FavoriteMeal> FavoriteMeals { get; set; }

        public virtual List<FavoriteDinnerTable> FavoriteDinnerTables { get; set; }

    }
}
