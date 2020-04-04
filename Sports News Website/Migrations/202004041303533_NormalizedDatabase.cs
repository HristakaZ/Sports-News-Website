namespace Sports_News_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormalizedDatabase : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Generic_Model");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Generic_Model",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
