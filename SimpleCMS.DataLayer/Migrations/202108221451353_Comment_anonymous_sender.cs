namespace SimpleCMS.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment_anonymous_sender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Name", c => c.String(maxLength: 150));
            AddColumn("dbo.Comments", "Email", c => c.String(maxLength: 150));
            AddColumn("dbo.Comments", "IsAnonymous", c => c.Boolean(nullable: false));
            AddColumn("dbo.SubComments", "Name", c => c.String(maxLength: 150));
            AddColumn("dbo.SubComments", "Email", c => c.String(maxLength: 150));
            AddColumn("dbo.SubComments", "IsAnonymous", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubComments", "IsAnonymous");
            DropColumn("dbo.SubComments", "Email");
            DropColumn("dbo.SubComments", "Name");
            DropColumn("dbo.Comments", "IsAnonymous");
            DropColumn("dbo.Comments", "Email");
            DropColumn("dbo.Comments", "Name");
        }
    }
}
