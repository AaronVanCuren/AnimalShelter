namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdoptDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adoption", "AdoptionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adoption", "AdoptionDate");
        }
    }
}
