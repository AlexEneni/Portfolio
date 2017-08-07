namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReUploadBlogPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPostModels", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogPostModels", "Title");
        }
    }
}
