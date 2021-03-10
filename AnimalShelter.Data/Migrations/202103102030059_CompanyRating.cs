namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyRating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        AdoptingProcessScore = c.Double(nullable: false),
                        FriendlinessScore = c.Double(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Vaccine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CommonName = c.String(nullable: false),
                        VaccinationSchedule = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyRating", "CompanyId", "dbo.Company");
            DropIndex("dbo.CompanyRating", new[] { "CompanyId" });
            DropTable("dbo.Vaccine");
            DropTable("dbo.CompanyRating");
        }
    }
}
