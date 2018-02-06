namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingcustomuserid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "CustomUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "CustomUserId");
        }
    }
}
