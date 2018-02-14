namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemenuproperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolePermissions", "RoleId", "dbo.Role");
            DropIndex("dbo.RolePermissions", new[] { "RoleId" });
            AlterColumn("dbo.Menus", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MenuItems", "ControllerName", c => c.String(nullable: false));
            AlterColumn("dbo.MenuItems", "ActionName", c => c.String(nullable: false));
            AlterColumn("dbo.RolePermissions", "RoleId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.RolePermissions", "RoleId");
            AddForeignKey("dbo.RolePermissions", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolePermissions", "RoleId", "dbo.Role");
            DropIndex("dbo.RolePermissions", new[] { "RoleId" });
            AlterColumn("dbo.RolePermissions", "RoleId", c => c.String(maxLength: 128));
            AlterColumn("dbo.MenuItems", "ActionName", c => c.String());
            AlterColumn("dbo.MenuItems", "ControllerName", c => c.String());
            AlterColumn("dbo.Menus", "Name", c => c.String());
            CreateIndex("dbo.RolePermissions", "RoleId");
            AddForeignKey("dbo.RolePermissions", "RoleId", "dbo.Role", "Id");
        }
    }
}
