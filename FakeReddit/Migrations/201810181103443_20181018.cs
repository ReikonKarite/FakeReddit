namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20181018 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserID" });
            AddColumn("dbo.Posts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "UserID", c => c.String());
            CreateIndex("dbo.Posts", "ApplicationUser_Id");
            AddForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Posts", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "ApplicationUser_Id");
            CreateIndex("dbo.Posts", "UserID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
