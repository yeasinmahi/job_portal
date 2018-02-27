namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        IconClass = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        IconClass = c.String(maxLength: 20),
                        Order = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        SubMenuId = c.Int(),
                        ControllerName = c.String(nullable: false, maxLength: 20),
                        ActionName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        MenuItemId = c.Int(nullable: false),
                        CanAdd = c.Boolean(nullable: false),
                        CanEdit = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        Sl = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        IconClass = c.String(maxLength: 20),
                        Order = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Sl)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomUserId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.SubMenus", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.RolePermissions", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.RolePermissions", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.SubMenus", new[] { "MenuId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.RolePermissions", new[] { "MenuItemId" });
            DropIndex("dbo.RolePermissions", new[] { "RoleId" });
            DropIndex("dbo.MenuItems", new[] { "MenuId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.SubMenus");
            DropTable("dbo.Role");
            DropTable("dbo.RolePermissions");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Menus");
            DropTable("dbo.UserRole");
        }
    }
}
