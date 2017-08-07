namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToGaleryPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GaleryPostModels", "date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GaleryPostModels", "descUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GaleryPostModels", "descUrl", c => c.String(maxLength: 255));
            DropColumn("dbo.GaleryPostModels", "date");
        }
    }
}
