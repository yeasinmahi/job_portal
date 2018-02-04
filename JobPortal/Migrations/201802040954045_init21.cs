namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init21 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.User", name: "SL", newName: "Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.User", name: "Id", newName: "SL");
        }
    }
}
