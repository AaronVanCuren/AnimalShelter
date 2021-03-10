namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animal", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Animal", "Breed", c => c.String(nullable: false));
            AlterColumn("dbo.Animal", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animal", "Description", c => c.String());
            AlterColumn("dbo.Animal", "Breed", c => c.String());
            AlterColumn("dbo.Animal", "Name", c => c.String());
        }
    }
}
