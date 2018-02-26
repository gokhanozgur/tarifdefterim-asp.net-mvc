namespace TarifDefterim.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        PhoneNumber = c.String(maxLength: 11),
                        Birthdate = c.DateTime(precision: 7, storeType: "datetime2"),
                        UserImage = c.String(maxLength: 250),
                        XSmallUserImage = c.String(),
                        CruptedUserImage = c.String(),
                        Role = c.Int(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        UserComment = c.String(nullable: false, maxLength: 250),
                        RecipeID = c.Guid(nullable: false),
                        AppUserID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .Index(t => t.RecipeID)
                .Index(t => t.AppUserID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Description = c.String(maxLength: 250),
                        Alignment = c.Short(nullable: false),
                        MealID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meals", t => t.MealID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 120),
                        Description = c.String(maxLength: 120),
                        Slug = c.String(nullable: false),
                        PreparationTime = c.String(),
                        PreparationTimeUnitOf = c.Int(),
                        CookingTime = c.String(),
                        CookingTimeUnitOf = c.Int(),
                        Person = c.Short(),
                        Tricks = c.String(maxLength: 120),
                        VideoURL = c.String(),
                        AppUserID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .Index(t => t.AppUserID);
            
            CreateTable(
                "dbo.AssignedCategories",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        MealID = c.Guid(nullable: false),
                        CategoryID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Meals", t => t.MealID)
                .Index(t => t.MealID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 120),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DinnerTables",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DinnerName = c.String(),
                        Slug = c.String(),
                        MealID = c.Guid(nullable: false),
                        AppUserID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .Index(t => t.AppUserID);
            
            CreateTable(
                "dbo.DinnerTableImages",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ImageURL = c.String(maxLength: 50),
                        DinnerTableID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DinnerTables", t => t.DinnerTableID)
                .Index(t => t.DinnerTableID);
            
            CreateTable(
                "dbo.DinnerTableLikes",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        AppUserID = c.Guid(nullable: false),
                        DinnerTableID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DinnerTables", t => t.DinnerTableID)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .Index(t => t.AppUserID)
                .Index(t => t.DinnerTableID);
            
            CreateTable(
                "dbo.FavoriteDinnerTables",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DinnerTableID = c.Guid(nullable: false),
                        AppUserID = c.Guid(nullable: false),
                        MealID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DinnerTables", t => t.DinnerTableID)
                .ForeignKey("dbo.Meals", t => t.MealID)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .Index(t => t.DinnerTableID)
                .Index(t => t.AppUserID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.FavoriMeals",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        MealID = c.Guid(nullable: false),
                        AppUserID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meals", t => t.MealID)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .Index(t => t.MealID)
                .Index(t => t.AppUserID);
            
            CreateTable(
                "dbo.FoodIngredients",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Quantity = c.Short(nullable: false),
                        UnitOf = c.Int(nullable: false),
                        MealID = c.Guid(nullable: false),
                        IngredientID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID)
                .ForeignKey("dbo.Meals", t => t.IngredientID)
                .Index(t => t.IngredientID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 120),
                        KindID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kinds", t => t.KindID)
                .Index(t => t.KindID);
            
            CreateTable(
                "dbo.Kinds",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 120),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MealImages",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        ImageURL = c.String(maxLength: 50),
                        MealID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meals", t => t.MealID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.RecipeLikes",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        AppUserID = c.Guid(nullable: false),
                        RecipeID = c.Guid(nullable: false),
                        MasterID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedComputerName = c.String(maxLength: 50),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedBy = c.Guid(),
                        CreatedIP = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedComputerName = c.String(maxLength: 50),
                        ModifiedIP = c.String(),
                        ModifiedUserName = c.String(maxLength: 50),
                        ModifiedBy = c.Guid(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .Index(t => t.AppUserID)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.DinnerTableMeal",
                c => new
                    {
                        DinnerTable_ID = c.Guid(nullable: false),
                        Meal_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.DinnerTable_ID, t.Meal_ID })
                .ForeignKey("dbo.DinnerTables", t => t.DinnerTable_ID, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Meal_ID, cascadeDelete: true)
                .Index(t => t.DinnerTable_ID)
                .Index(t => t.Meal_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeLikes", "AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.Meals", "AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.FavoriMeals", "AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.FavoriteDinnerTables", "AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.DinnerTables", "AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.DinnerTableLikes", "AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeLikes", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "MealID", "dbo.Meals");
            DropForeignKey("dbo.MealImages", "MealID", "dbo.Meals");
            DropForeignKey("dbo.FoodIngredients", "IngredientID", "dbo.Meals");
            DropForeignKey("dbo.FoodIngredients", "IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.Ingredients", "KindID", "dbo.Kinds");
            DropForeignKey("dbo.FavoriMeals", "MealID", "dbo.Meals");
            DropForeignKey("dbo.FavoriteDinnerTables", "MealID", "dbo.Meals");
            DropForeignKey("dbo.DinnerTableMeal", "Meal_ID", "dbo.Meals");
            DropForeignKey("dbo.DinnerTableMeal", "DinnerTable_ID", "dbo.DinnerTables");
            DropForeignKey("dbo.FavoriteDinnerTables", "DinnerTableID", "dbo.DinnerTables");
            DropForeignKey("dbo.DinnerTableLikes", "DinnerTableID", "dbo.DinnerTables");
            DropForeignKey("dbo.DinnerTableImages", "DinnerTableID", "dbo.DinnerTables");
            DropForeignKey("dbo.AssignedCategories", "MealID", "dbo.Meals");
            DropForeignKey("dbo.AssignedCategories", "CategoryID", "dbo.Categories");
            DropIndex("dbo.DinnerTableMeal", new[] { "Meal_ID" });
            DropIndex("dbo.DinnerTableMeal", new[] { "DinnerTable_ID" });
            DropIndex("dbo.RecipeLikes", new[] { "RecipeID" });
            DropIndex("dbo.RecipeLikes", new[] { "AppUserID" });
            DropIndex("dbo.MealImages", new[] { "MealID" });
            DropIndex("dbo.Ingredients", new[] { "KindID" });
            DropIndex("dbo.FoodIngredients", new[] { "IngredientID" });
            DropIndex("dbo.FavoriMeals", new[] { "AppUserID" });
            DropIndex("dbo.FavoriMeals", new[] { "MealID" });
            DropIndex("dbo.FavoriteDinnerTables", new[] { "MealID" });
            DropIndex("dbo.FavoriteDinnerTables", new[] { "AppUserID" });
            DropIndex("dbo.FavoriteDinnerTables", new[] { "DinnerTableID" });
            DropIndex("dbo.DinnerTableLikes", new[] { "DinnerTableID" });
            DropIndex("dbo.DinnerTableLikes", new[] { "AppUserID" });
            DropIndex("dbo.DinnerTableImages", new[] { "DinnerTableID" });
            DropIndex("dbo.DinnerTables", new[] { "AppUserID" });
            DropIndex("dbo.AssignedCategories", new[] { "CategoryID" });
            DropIndex("dbo.AssignedCategories", new[] { "MealID" });
            DropIndex("dbo.Meals", new[] { "AppUserID" });
            DropIndex("dbo.Recipes", new[] { "MealID" });
            DropIndex("dbo.Comments", new[] { "AppUserID" });
            DropIndex("dbo.Comments", new[] { "RecipeID" });
            DropTable("dbo.DinnerTableMeal");
            DropTable("dbo.RecipeLikes");
            DropTable("dbo.MealImages");
            DropTable("dbo.Kinds");
            DropTable("dbo.Ingredients");
            DropTable("dbo.FoodIngredients");
            DropTable("dbo.FavoriMeals");
            DropTable("dbo.FavoriteDinnerTables");
            DropTable("dbo.DinnerTableLikes");
            DropTable("dbo.DinnerTableImages");
            DropTable("dbo.DinnerTables");
            DropTable("dbo.Categories");
            DropTable("dbo.AssignedCategories");
            DropTable("dbo.Meals");
            DropTable("dbo.Recipes");
            DropTable("dbo.Comments");
            DropTable("dbo.AppUsers");
        }
    }
}
