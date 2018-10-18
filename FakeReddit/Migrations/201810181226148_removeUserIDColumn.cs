namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserIDColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "UserID");
        }
        
        public override void Down()
        {
            
        }
    }
}
