namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingmenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Menus", "SubMenuId", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "MenuId" });
            DropIndex("dbo.Menus", new[] { "SubMenuId" });
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IconClass = c.String(),
                        Order = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        SubMenuId = c.Int(nullable: false),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.SubMenus", t => t.SubMenuId, cascadeDelete: true)
                .Index(t => t.SubMenuId);
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IconClass = c.String(),
                        Order = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            DropColumn("dbo.Menus", "MenuId");
            DropColumn("dbo.Menus", "SubMenuId");
            DropColumn("dbo.Menus", "ControllerName");
            DropColumn("dbo.Menus", "ActionName");
            DropColumn("dbo.Menus", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Menus", "ActionName", c => c.String());
            AddColumn("dbo.Menus", "ControllerName", c => c.String());
            AddColumn("dbo.Menus", "SubMenuId", c => c.Int());
            AddColumn("dbo.Menus", "MenuId", c => c.Int());
            DropForeignKey("dbo.MenuItems", "SubMenuId", "dbo.SubMenus");
            DropForeignKey("dbo.SubMenus", "MenuId", "dbo.Menus");
            DropIndex("dbo.SubMenus", new[] { "MenuId" });
            DropIndex("dbo.MenuItems", new[] { "SubMenuId" });
            DropTable("dbo.SubMenus");
            DropTable("dbo.MenuItems");
            CreateIndex("dbo.Menus", "SubMenuId");
            CreateIndex("dbo.Menus", "MenuId");
            AddForeignKey("dbo.Menus", "SubMenuId", "dbo.Menus", "Sl");
            AddForeignKey("dbo.Menus", "MenuId", "dbo.Menus", "Sl");
        }
    }
}
