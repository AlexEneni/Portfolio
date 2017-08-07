namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 30),
                        text = c.String(nullable: false, maxLength: 255),
                        eMail = c.String(nullable: false),
                        dateOfSend = c.DateTime(nullable: false),
                        wasDisplayed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
