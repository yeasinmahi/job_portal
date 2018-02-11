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
            if (AddRole())
            {
                AddUser();
            }
            
        }
        private static bool AddRole()
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

        private static void AddUser()
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

    }
}
