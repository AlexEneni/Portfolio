namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessTitleAddCol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "title", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "title");
        }
    }
}
