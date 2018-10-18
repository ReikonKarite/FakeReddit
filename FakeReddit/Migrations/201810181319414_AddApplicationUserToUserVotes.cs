namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserToUserVotes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserVotes", "UserID", "dbo.Users");
            DropIndex("dbo.UserVotes", new[] { "UserID" });
            AddColumn("dbo.UserVotes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserVotes", "ApplicationUser_Id");
            AddForeignKey("dbo.UserVotes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UserVotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserVotes", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserVotes", "ApplicationUser_Id");
            CreateIndex("dbo.UserVotes", "UserID");
            AddForeignKey("dbo.UserVotes", "UserID", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
