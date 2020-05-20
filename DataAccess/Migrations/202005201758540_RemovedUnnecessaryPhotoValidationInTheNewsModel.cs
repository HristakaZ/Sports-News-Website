namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUnnecessaryPhotoValidationInTheNewsModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Photo", c => c.String(nullable: false));
        }
    }
}
