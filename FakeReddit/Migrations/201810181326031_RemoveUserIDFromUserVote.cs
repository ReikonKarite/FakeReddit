namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserIDFromUserVote : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserVotes", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserVotes", "UserID", c => c.Int(nullable: false));
        }
    }
}
