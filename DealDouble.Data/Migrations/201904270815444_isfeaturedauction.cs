namespace DealDouble.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isfeaturedauction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auctions", "isFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auctions", "isFeatured");
        }
    }
}
