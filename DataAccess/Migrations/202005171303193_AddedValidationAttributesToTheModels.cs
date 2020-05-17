namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidationAttributesToTheModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Athletes", "Sport_ID", "dbo.Sports");
            DropIndex("dbo.Athletes", new[] { "Sport_ID" });
            AlterColumn("dbo.Athletes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Athletes", "Sport_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.News", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Photo", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Athletes", "Sport_ID");
            AddForeignKey("dbo.Athletes", "Sport_ID", "dbo.Sports", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "Sport_ID", "dbo.Sports");
            DropIndex("dbo.Athletes", new[] { "Sport_ID" });
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 20));
            AlterColumn("dbo.News", "Photo", c => c.String());
            AlterColumn("dbo.News", "Content", c => c.String());
            AlterColumn("dbo.News", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Sports", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Athletes", "Sport_ID", c => c.Int());
            AlterColumn("dbo.Athletes", "Name", c => c.String());
            CreateIndex("dbo.Athletes", "Sport_ID");
            AddForeignKey("dbo.Athletes", "Sport_ID", "dbo.Sports", "ID");
        }
    }
}
