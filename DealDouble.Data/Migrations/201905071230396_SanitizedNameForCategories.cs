namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SanitizedNameForCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SanitizedName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "SanitizedName");
        }
    }
}
