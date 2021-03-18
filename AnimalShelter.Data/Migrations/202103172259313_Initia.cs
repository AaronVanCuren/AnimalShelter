namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initia : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserRating", name: "UserId", newName: "Id");
            RenameIndex(table: "dbo.UserRating", name: "IX_UserId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserRating", name: "IX_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.UserRating", name: "Id", newName: "UserId");
        }
    }
}
