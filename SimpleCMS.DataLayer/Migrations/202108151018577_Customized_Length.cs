namespace SimpleCMS.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customized_Length : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.SubCategoryPosts", "SubCategory_SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategoryPosts", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropIndex("dbo.SubCategoryPosts", new[] { "SubCategory_SubCategoryId" });
            DropIndex("dbo.SubCategoryPosts", new[] { "Post_PostId" });
            AddColumn("dbo.Posts", "SubCategory_SubCategoryId", c => c.Int());
            AlterColumn("dbo.Comments", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Posts", "ImageName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Posts", "SubCategory_SubCategoryId");
            AddForeignKey("dbo.Posts", "SubCategory_SubCategoryId", "dbo.SubCategories", "SubCategoryId");
            DropColumn("dbo.Comments", "Post_PostId");
            DropTable("dbo.SubCategoryPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubCategoryPosts",
                c => new
                    {
                        SubCategory_SubCategoryId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategory_SubCategoryId, t.Post_PostId });
            
            AddColumn("dbo.Comments", "Post_PostId", c => c.Int());
            DropForeignKey("dbo.Posts", "SubCategory_SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Posts", new[] { "SubCategory_SubCategoryId" });
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Posts", "ImageName", c => c.String());
            AlterColumn("dbo.Comments", "Text", c => c.String());
            AlterColumn("dbo.Comments", "Title", c => c.String());
            DropColumn("dbo.Posts", "SubCategory_SubCategoryId");
            CreateIndex("dbo.SubCategoryPosts", "Post_PostId");
            CreateIndex("dbo.SubCategoryPosts", "SubCategory_SubCategoryId");
            CreateIndex("dbo.Comments", "Post_PostId");
            AddForeignKey("dbo.SubCategoryPosts", "Post_PostId", "dbo.Posts", "PostId", cascadeDelete: true);
            AddForeignKey("dbo.SubCategoryPosts", "SubCategory_SubCategoryId", "dbo.SubCategories", "SubCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId");
        }
    }
}
