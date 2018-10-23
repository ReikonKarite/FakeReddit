namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIDForeignKey1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Posts", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.Posts", "ApplicationUser_Id1");
            AddForeignKey("dbo.Posts", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Posts", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserID", c => c.String());
            DropForeignKey("dbo.Posts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.Posts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Posts", "ApplicationUser_Id1");
            CreateIndex("dbo.Posts", "ApplicationUser_Id");
            AddForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
