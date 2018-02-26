using System;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Others.Enum;

namespace DAL.Controller
{
    public class StartupData
    {
        private static readonly ApplicationDbContext Context = ApplicationDbContext.Create();

        public static void AddstartupData()
        {
            if (AddRoles())
            {
                AddUsers();
                AddMenus();
                AddSubMenus();
                AddMenuItems();
            }

        }

        private static bool AddRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Context));
            if (!roleManager.RoleExists(Enums.ToFriendlyString(Enums.DefaultRole.SystemAdmin)))
            {
                roleManager.Create(new IdentityRole(Enums.ToFriendlyString(Enums.DefaultRole.SystemAdmin)));
                roleManager.Create(new IdentityRole(Enums.ToFriendlyString(Enums.DefaultRole.SuperAdmin)));
                roleManager.Create(new IdentityRole(Enums.ToFriendlyString(Enums.DefaultRole.Admin)));
                return true;
            }
            return false;
        }

        private static void AddUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
            ApplicationUser applicationUser = new ApplicationUser
            {
                Email = "yeasinmahi72@gmail.com",
                UserName = "futuristic",
                EmailConfirmed = true,
                PhoneNumber = "008801676272718",
                CustomUserId = 1,
                PhoneNumberConfirmed = true
            };
            IdentityResult result = userManager.Create(applicationUser, "FTL@jp");
            if (result.Succeeded)
            {
                userManager.AddToRole(applicationUser.Id, Enums.ToFriendlyString(Enums.DefaultRole.SystemAdmin));
            }
            ApplicationUser superAdmin = new ApplicationUser
            {
                Email = "yeasinmahi72@gmail.com",
                UserName = "superadmin",
                EmailConfirmed = true,
                PhoneNumber = "008801676272718",
                CustomUserId = 2,
                PhoneNumberConfirmed = true
            };
            result = userManager.Create(superAdmin, "FTL@jp");
            if (result.Succeeded)
            {
                userManager.AddToRole(superAdmin.Id, Enums.ToFriendlyString(Enums.DefaultRole.SuperAdmin));
            }
        }

        private static void AddMenus()
        {
            Context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ([Menus], RESEED, {0})", 1));
            Menu menu = new Menu
            {
                Sl = 1,
                Name = "Role Management",
                IconClass = "fa fa-role",
                Order = 1
            };
            DataController<Menu>.Insert(menu);
            menu = new Menu
            {
                Sl = 2,
                Name = "Menu Management",
                IconClass = "fa fa-user",
                Order = 2
            };
            DataController<Menu>.Insert(menu);
            //Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Menus] OFF");
        }

        private static void AddSubMenus()
        {
            Context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ([SubMenus], RESEED, {0})", 1));
            SubMenu subMenu = new SubMenu
            {
                Sl = 1,
                Name = "Menu",
                IconClass = "fa fa-circle",
                Order = 1,
                MenuId = 2
            };
            DataController<SubMenu>.Insert(subMenu);
            subMenu = new SubMenu
            {
                Sl = 2,
                Name = "Sub Menu",
                IconClass = "fa fa-circle",
                Order = 2,
                MenuId = 2
            };
            DataController<SubMenu>.Insert(subMenu);
            subMenu = new SubMenu
            {
                Sl = 3,
                Name = "Menu Item",
                IconClass = "fa fa-circle",
                Order = 3,
                MenuId = 2
            };
            DataController<SubMenu>.Insert(subMenu);
        }

        private static void AddMenuItems()
        {
            Context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ([MenuItems], RESEED, {0})", 1));
            MenuItem menuItem = new MenuItem
            {
                Sl = 1,
                Name = "Add",
                ActionName = "Create",
                ControllerName = "Menus",
                IconClass = "fa fa-circle",
                Order = 1,
                SubMenuId = 1,
                MenuId = 2
            };
            DataController<MenuItem>.Insert(menuItem);
            menuItem = new MenuItem
            {
                Sl = 2,
                Name = "List",
                ActionName = "Index",
                ControllerName = "Menus",
                IconClass = "fa fa-circle",
                Order = 2,
                SubMenuId = 1,
                MenuId = 2
            };
            DataController<MenuItem>.Insert(menuItem);
            menuItem = new MenuItem
            {
                Sl = 3,
                Name = "Add",
                ActionName = "Create",
                ControllerName = "SubMenus",
                IconClass = "fa fa-circle",
                Order = 1,
                SubMenuId = 2,
                MenuId = 2
            };
            DataController<MenuItem>.Insert(menuItem);
            menuItem = new MenuItem
            {
                Sl = 4,
                Name = "List",
                ActionName = "Index",
                ControllerName = "SubMenus",
                IconClass = "fa fa-circle",
                Order = 2,
                SubMenuId = 2,
                MenuId = 2
            };
            DataController<MenuItem>.Insert(menuItem);
            menuItem = new MenuItem
            {
                Sl = 5,
                Name = "Add",
                ActionName = "Create",
                ControllerName = "MenuItems",
                IconClass = "fa fa-circle",
                Order = 1,
                SubMenuId = 3,
                MenuId = 2
            };
            DataController<MenuItem>.Insert(menuItem);
            menuItem = new MenuItem
            {
                Sl = 6,
                Name = "List",
                ActionName = "Index",
                ControllerName = "MenuItems",
                IconClass = "fa fa-circle",
                Order = 2,
                SubMenuId = 3,
                MenuId = 2
            };
            DataController<MenuItem>.Insert(menuItem);
        }
    }
}