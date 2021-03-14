namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adoption",
                c => new
                    {
                        AdoptionId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        PostId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdoptionId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Profile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        AnimalId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Animal", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.AnimalId)
                .Index(t => t.CompanyId);
            
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
                        HasShots = c.Boolean(nullable: false),
                        Age = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AdoptionPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsHouseTrained = c.Boolean(nullable: false),
                        IsDeclawed = c.Boolean(nullable: false),
                        IsEdible = c.Boolean(nullable: false),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Company", t => t.Company_CompanyId)
                .Index(t => t.Company_CompanyId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Author = c.Guid(nullable: false),
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
                        Author = c.Guid(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
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
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Adoption", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.Adoption", "PostId", "dbo.Post");
            DropForeignKey("dbo.CompanyRating", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Post", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Animal", "Company_CompanyId", "dbo.Company");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "AnimalId", "dbo.Animal");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CompanyRating", new[] { "CompanyId" });
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Animal", new[] { "Company_CompanyId" });
            DropIndex("dbo.Post", new[] { "CompanyId" });
            DropIndex("dbo.Post", new[] { "AnimalId" });
            DropIndex("dbo.Adoption", new[] { "ProfileId" });
            DropIndex("dbo.Adoption", new[] { "PostId" });
            DropTable("dbo.Vaccine");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Profile");
            DropTable("dbo.CompanyRating");
            DropTable("dbo.Company");
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
            DropTable("dbo.Animal");
            DropTable("dbo.Post");
            DropTable("dbo.Adoption");
        }
    }
}
