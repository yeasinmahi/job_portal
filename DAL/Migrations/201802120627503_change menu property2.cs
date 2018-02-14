namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemenuproperty2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.MenuItems", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.MenuItems", "IconClass", c => c.String(maxLength: 20));
            AlterColumn("dbo.MenuItems", "ControllerName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.MenuItems", "ActionName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SubMenus", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.SubMenus", "IconClass", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubMenus", "IconClass", c => c.String());
            AlterColumn("dbo.SubMenus", "Name", c => c.String());
            AlterColumn("dbo.MenuItems", "ActionName", c => c.String(nullable: false));
            AlterColumn("dbo.MenuItems", "ControllerName", c => c.String(nullable: false));
            AlterColumn("dbo.MenuItems", "IconClass", c => c.String());
            AlterColumn("dbo.MenuItems", "Name", c => c.String());
            AlterColumn("dbo.Menus", "Name", c => c.String(nullable: false));
        }
    }
}
