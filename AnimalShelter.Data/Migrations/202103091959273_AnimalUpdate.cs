namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animal", "IsEdible", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Animal", "IsDeclawed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Animal", "IsHouseTrained", c => c.Boolean(nullable: false));
            DropColumn("dbo.Animal", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animal", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Animal", "IsHouseTrained", c => c.Boolean());
            AlterColumn("dbo.Animal", "IsDeclawed", c => c.Boolean());
            AlterColumn("dbo.Animal", "IsEdible", c => c.Boolean());
        }
    }
}
