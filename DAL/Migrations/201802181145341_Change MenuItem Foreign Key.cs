namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMenuItemForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "SubMenuId", "dbo.SubMenus");
            DropIndex("dbo.MenuItems", new[] { "SubMenuId" });
            AlterColumn("dbo.MenuItems", "SubMenuId", c => c.Int());
            CreateIndex("dbo.MenuItems", "MenuId");
            AddForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus", "Sl", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus");
            DropIndex("dbo.MenuItems", new[] { "MenuId" });
            AlterColumn("dbo.MenuItems", "SubMenuId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "SubMenuId");
            AddForeignKey("dbo.MenuItems", "SubMenuId", "dbo.SubMenus", "Sl", cascadeDelete: true);
        }
    }
}
