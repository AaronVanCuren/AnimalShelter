namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adoption",
                c => new
                    {
                        AdoptionId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdoptionId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        AnimalId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Animal", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.AnimalId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Species = c.Int(nullable: false),
                        Breed = c.String(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        Fixed = c.Boolean(nullable: false),
                        Age = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AdoptionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsHouseTrained = c.Boolean(nullable: false),
                        IsDeclawed = c.Boolean(nullable: false),
                        IsEdible = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Vaccine",
                c => new
                    {
                        VaccineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CommonName = c.String(nullable: false),
                        VaccinationSchedule = c.String(nullable: false),
                        Animal_AnimalId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VaccineId)
                .ForeignKey("dbo.Animal", t => t.Animal_AnimalId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.Animal_AnimalId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.UserRating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        AdoptingProcessScore = c.Double(nullable: false),
                        FriendlinessScore = c.Double(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.Int(nullable: false),
                        FullName = c.String(),
                        CompanyName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Vaccine", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.UserRating", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Post", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Animal", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Adoption", "PostId", "dbo.Post");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "AnimalId", "dbo.Animal");
            DropForeignKey("dbo.Vaccine", "Animal_AnimalId", "dbo.Animal");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserRating", new[] { "UserId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Vaccine", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Vaccine", new[] { "Animal_AnimalId" });
            DropIndex("dbo.Animal", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Post", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Post", new[] { "AnimalId" });
            DropIndex("dbo.Adoption", new[] { "PostId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UserRating");
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
            DropTable("dbo.Vaccine");
            DropTable("dbo.Animal");
            DropTable("dbo.Post");
            DropTable("dbo.Adoption");
        }
    }
}
