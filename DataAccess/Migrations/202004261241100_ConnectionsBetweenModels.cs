namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectionsBetweenModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athletes", "Sport_ID", c => c.Int());
            AddColumn("dbo.Comments", "News_ID", c => c.Int());
            AddColumn("dbo.Comments", "User_ID", c => c.Int());
            AddColumn("dbo.News", "User_ID", c => c.Int());
            CreateIndex("dbo.Athletes", "Sport_ID");
            CreateIndex("dbo.Comments", "News_ID");
            CreateIndex("dbo.Comments", "User_ID");
            CreateIndex("dbo.News", "User_ID");
            AddForeignKey("dbo.Athletes", "Sport_ID", "dbo.Sports", "ID");
            AddForeignKey("dbo.Comments", "News_ID", "dbo.News", "ID");
            AddForeignKey("dbo.Comments", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.News", "User_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "News_ID", "dbo.News");
            DropForeignKey("dbo.Athletes", "Sport_ID", "dbo.Sports");
            DropIndex("dbo.News", new[] { "User_ID" });
            DropIndex("dbo.Comments", new[] { "User_ID" });
            DropIndex("dbo.Comments", new[] { "News_ID" });
            DropIndex("dbo.Athletes", new[] { "Sport_ID" });
            DropColumn("dbo.News", "User_ID");
            DropColumn("dbo.Comments", "User_ID");
            DropColumn("dbo.Comments", "News_ID");
            DropColumn("dbo.Athletes", "Sport_ID");
        }
    }
}
