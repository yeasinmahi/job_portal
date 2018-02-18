namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentvirtualidentityroleinmenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolePermissions", "RoleId", "dbo.Role");
            DropIndex("dbo.RolePermissions", new[] { "RoleId" });
            AlterColumn("dbo.RolePermissions", "RoleId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RolePermissions", "RoleId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.RolePermissions", "RoleId");
            AddForeignKey("dbo.RolePermissions", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
    }
}
