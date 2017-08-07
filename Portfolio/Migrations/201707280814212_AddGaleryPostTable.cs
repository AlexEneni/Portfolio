namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGaleryPostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GaleryPostModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 55),
                        imageUrl = c.String(),
                        descUrl = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GaleryPostModels");
        }
    }
}
