namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIDIntoVotes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserVotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserVotes", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.UserVotes", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserVotes", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.UserVotes", "ApplicationUser_Id1");
            AddForeignKey("dbo.UserVotes", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVotes", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.UserVotes", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.UserVotes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.UserVotes", "ApplicationUser_Id1");
            CreateIndex("dbo.UserVotes", "ApplicationUser_Id");
            AddForeignKey("dbo.UserVotes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
