namespace FakeReddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshiptoComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ApplicationUser_Id", c => c.String());
            AddColumn("dbo.Comments", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ApplicationUser_Id1");
            AddForeignKey("dbo.Comments", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.Comments", "ApplicationUser_Id1");
            DropColumn("dbo.Comments", "ApplicationUser_Id");
        }
    }
}
