namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "User", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "User");
        }
    }
}
