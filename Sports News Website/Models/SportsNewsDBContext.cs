namespace Sports_News_Website.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SportsNewsDBContext : DbContext
    {
        // Your context has been configured to use a 'SportsNewsDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Sports_News_Website.Models.SportsNewsDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SportsNewsDBContext' 
        // connection string in the application configuration file.
        public SportsNewsDBContext()
            : base("name=SportsNewsDBContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Athletes> Athletes { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}