using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TarifDefterim.Core.Enum;
using TarifDefterim.Model.Option;

namespace TarifDefterim.UI.Models.VM
{
    public class MealVM
    {

        public MealVM()
        {
            Categories = new List<Category>();
            Category = new Category();
            Comments = new List<Comment>();
            Recipes = new List<Recipe>();
            FoodIngredients = new List<FoodIngredient>();
            //MealImages = new List<MealImage>();
            AssignedCategories = new List<AssignedCategory>();
        }

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

        public string RandomImagePath { get; set; }

        public string FullName { get; set; }

        public List<MealImage> MealImages { get; set; }

        public List<AssignedCategory> AssignedCategories { get; set; }

        public List<FoodIngredient> FoodIngredients { get; set; }

        public List<Recipe> Recipes { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Category> Categories { get; set; }

        public Category Category { get; set; }

    }
}