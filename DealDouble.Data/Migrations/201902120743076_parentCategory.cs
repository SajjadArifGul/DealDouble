namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ParentCategoryID", c => c.Int());
            CreateIndex("dbo.Categories", "ParentCategoryID");
            AddForeignKey("dbo.Categories", "ParentCategoryID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ParentCategoryID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentCategoryID" });
            DropColumn("dbo.Categories", "ParentCategoryID");
        }
    }
}
