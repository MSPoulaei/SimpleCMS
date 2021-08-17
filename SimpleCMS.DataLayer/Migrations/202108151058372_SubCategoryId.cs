namespace SimpleCMS.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
        }
    }
}
