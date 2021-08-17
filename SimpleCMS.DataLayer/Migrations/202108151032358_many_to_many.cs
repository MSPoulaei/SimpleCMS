namespace SimpleCMS.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class many_to_many : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "SubCategory_SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Posts", new[] { "SubCategory_SubCategoryId" });
            CreateTable(
                "dbo.SubCategoryPosts",
                c => new
                    {
                        SubCategory_SubCategoryId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategory_SubCategoryId, t.Post_PostId })
                .ForeignKey("dbo.SubCategories", t => t.SubCategory_SubCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.SubCategory_SubCategoryId)
                .Index(t => t.Post_PostId);
            
            AddColumn("dbo.Comments", "Post_PostId", c => c.Int());
            CreateIndex("dbo.Comments", "Post_PostId");
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId");
            DropColumn("dbo.Posts", "SubCategory_SubCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "SubCategory_SubCategoryId", c => c.Int());
            DropForeignKey("dbo.SubCategoryPosts", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.SubCategoryPosts", "SubCategory_SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.SubCategoryPosts", new[] { "Post_PostId" });
            DropIndex("dbo.SubCategoryPosts", new[] { "SubCategory_SubCategoryId" });
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropColumn("dbo.Comments", "Post_PostId");
            DropTable("dbo.SubCategoryPosts");
            CreateIndex("dbo.Posts", "SubCategory_SubCategoryId");
            AddForeignKey("dbo.Posts", "SubCategory_SubCategoryId", "dbo.SubCategories", "SubCategoryId");
        }
    }
}
