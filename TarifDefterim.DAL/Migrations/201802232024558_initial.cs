namespace TarifDefterim.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategory", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AssignedCategories", "SubCategoryID", "dbo.SubCategory");
            DropIndex("dbo.AssignedCategories", new[] { "SubCategoryID" });
            DropIndex("dbo.SubCategory", new[] { "CategoryID" });
            DropColumn("dbo.AssignedCategories", "SubCategoryID");
            DropTable("dbo.SubCategory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        SubCategoryName = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 150),
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AssignedCategories", "SubCategoryID", c => c.Guid(nullable: false));
            CreateIndex("dbo.SubCategory", "CategoryID");
            CreateIndex("dbo.AssignedCategories", "SubCategoryID");
            AddForeignKey("dbo.AssignedCategories", "SubCategoryID", "dbo.SubCategory", "ID");
            AddForeignKey("dbo.SubCategory", "CategoryID", "dbo.Categories", "ID");
        }
    }
}
