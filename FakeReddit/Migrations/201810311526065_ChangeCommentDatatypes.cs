namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCommentDatatypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Title", c => c.String());
            AlterColumn("dbo.Comments", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Content", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Title", c => c.Int(nullable: false));
        }
    }
}
