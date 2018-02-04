namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.User", name: "Id", newName: "SL");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.User", name: "SL", newName: "Id");
        }
    }
}
