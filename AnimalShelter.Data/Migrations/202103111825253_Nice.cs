namespace AnimalShelter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nice : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adoption", "ProfileId", "dbo.Profile");
            DropForeignKey("dbo.Adoption", "PostId", "dbo.Post");
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Adoption", new[] { "ProfileId" });
            DropIndex("dbo.Adoption", new[] { "PostId" });
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
            DropTable("dbo.Adoption");
        }
    }
}
