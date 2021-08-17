namespace SimpleCMS.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubComments",
                c => new
                    {
                        SubCommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        MainCommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCommentId)
                .ForeignKey("dbo.Comments", t => t.MainCommentId, cascadeDelete: false)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.PostId)
                .Index(t => t.MainCommentId);
            
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.SubComments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.SubComments", "MainCommentId", "dbo.Comments");
            DropIndex("dbo.SubComments", new[] { "MainCommentId" });
            DropIndex("dbo.SubComments", new[] { "PostId" });
            DropIndex("dbo.SubComments", new[] { "UserId" });
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 150));
            DropTable("dbo.SubComments");
        }
    }
}
