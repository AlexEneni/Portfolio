namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDbBlogPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPostModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        date = c.DateTime(nullable: false),
                        textFileUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogPostModels");
        }
    }
}
