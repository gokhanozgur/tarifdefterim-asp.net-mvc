using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Map;
using TarifDefterim.Model.Option;

namespace TarifDefterim.Map.Option
{
    public class MealMap:CoreMap<Meal>
    {

        public MealMap()
        {
            // Table property settings

            ToTable("dbo.Meals");
            Property(x => x.Name).HasMaxLength(120).IsRequired();
            Property(x => x.Description).HasMaxLength(120);
            Property(x => x.Slug).IsRequired();
            Property(x => x.PreparationTime).IsOptional();
            Property(x => x.PreparationTimeUnitOf).IsOptional();
            Property(x => x.CookingTime).IsOptional();
            Property(x => x.CookingTimeUnitOf).IsOptional();
            Property(x => x.Person).IsOptional();
            Property(x => x.Tricks).HasMaxLength(120).IsOptional();
            Property(x => x.VideoURL).IsOptional();

            // Table Relations

            // AppUser table relation

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Meals)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            // AssignCategory table relation

            HasMany(x => x.AssignedCategories)
                .WithRequired(x => x.Meal)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);

            // MealImage table relation

            HasMany(x => x.MealImages)
                .WithRequired(x => x.Meal)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);

            // DinnerTable table relation

            HasMany(x => x.DinnerTables)
                .WithMany(x => x.Meals);

            // FoodIngredient table relation

            HasMany(x => x.FoodIngredients)
                .WithRequired(x => x.Meal)
                //.HasForeignKey(x => x.MealID)
                .HasForeignKey(x => x.IngredientID)
                .WillCascadeOnDelete(false);

            // Recipe table relation

            HasMany(x => x.Recipes)
                .WithRequired(x => x.Meal)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);

            // FavoriteMeal table relation

            HasMany(x => x.FavoriteMeals)
                .WithRequired(x => x.Meal)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);

            // FavoriteDinnerTable table relation

            HasMany(x => x.FavoriteDinnerTables)
                .WithRequired(x => x.Meal)
                .HasForeignKey(x => x.MealID)
                .WillCascadeOnDelete(false);


        }

    }
}
