namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnimalShelter.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            // May not be needed. This was probably added because of migrations I had to add for my databases. Delete line below if it causes issues.
            ContextKey = "AnimalShelter.Data.ApplicationDbContext";
        }

        protected override void Seed(AnimalShelter.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
