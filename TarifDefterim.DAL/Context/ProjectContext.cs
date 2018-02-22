using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TarifDefterim.Core.Entity;
using TarifDefterim.Core.Enum;
using TarifDefterim.Map.Option;
using TarifDefterim.Model.Option;
using TarifDefterim.Utility;

namespace TarifDefterim.DAL.Context
{
    public class ProjectContext:DbContext
    {

        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=TarifDefterim;uid=sa;pwd=12567849";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new AssignedCategoryMap());
            /*modelBuilder.Configurations.Add(new BenefitMap());*/
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new DinnerTableMap());
            modelBuilder.Configurations.Add(new DinnerTableImageMap());
            modelBuilder.Configurations.Add(new DinnerTableLikeMap());
            modelBuilder.Configurations.Add(new FavoriteDinnerTableMap());
            modelBuilder.Configurations.Add(new FavoriteMealMap());
            modelBuilder.Configurations.Add(new FoodIngredientMap());
            modelBuilder.Configurations.Add(new IngredientMap());
            modelBuilder.Configurations.Add(new KindMap());
            /*modelBuilder.Configurations.Add(new LossMap());*/
            modelBuilder.Configurations.Add(new MealMap());
            modelBuilder.Configurations.Add(new MealImageMap());
            modelBuilder.Configurations.Add(new RecipeMap());
            modelBuilder.Configurations.Add(new RecipeLikeMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AssignedCategory> AssignedCategories { get; set; }

        /*public DbSet<Benefit> Benefits { get; set; }*/

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<DinnerTable> DinnerTables { get; set; }

        public DbSet<DinnerTableImage> DinnerTableImages { get; set; }

        public DbSet<DinnerTableLike> DinnerTableLikes { get; set; }

        public DbSet<FavoriteDinnerTable> FavoriteDinnerTables { get; set; }

        public DbSet<FavoriteMeal> FavoriteMeals { get; set; }

        public DbSet<FoodIngredient> FoodIngredients { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Kind> Kinds { get; set; }

        /*public DbSet<Loss> Losses { get; set; }*/

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealImage> MealImages { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeLike> RecipeLikes { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }


        public override int SaveChanges()
        {

            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string getIp = RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Status.Active;
                        entity.CreatedUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = dateTime;
                        entity.CreatedIP = getIp;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.Status = Status.Updated;
                        entity.ModifiedUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = dateTime;
                        entity.ModifiedIP = getIp;
                    }

                }
            }


            return base.SaveChanges();
        }

    }
}
