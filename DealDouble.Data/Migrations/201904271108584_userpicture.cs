namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PictureID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "PictureID");
            AddForeignKey("dbo.AspNetUsers", "PictureID", "dbo.Pictures", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PictureID", "dbo.Pictures");
            DropIndex("dbo.AspNetUsers", new[] { "PictureID" });
            DropColumn("dbo.AspNetUsers", "PictureID");
        }
    }
}
