namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIDForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "UserID");
        }
    }
}
