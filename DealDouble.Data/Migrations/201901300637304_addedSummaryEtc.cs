namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSummaryEtc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "Summary", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.Categories", "Summary", c => c.String());
            AlterColumn("dbo.Auctions", "Title", c => c.String());
            AlterColumn("dbo.Comments", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Mobile", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Comments", "UserID", c => c.String());
            AlterColumn("dbo.Auctions", "Title", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Categories", "Summary");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.Auctions", "Summary");
        }
    }
}
