namespace DataAccess.Migrations
{
    using DataStructure;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.SportsNewsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.SportsNewsDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(user => user.ID,
                new Users { Username = "Admin", Password = "E1in7wL/u5GNCEMifhfLgAfiLh2QR/CbzJxJKPWswoI=", IsAdmin = true}, // password = "Admin"
                new Users { Username = "pesho", Password = "MVCptP4ePS4HT264T2i2xvqjqnXYffCJbr2cebtaqxE=", IsAdmin = false}); // password = "pesho" 
        }
    }
}
