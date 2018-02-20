using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("JPConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!


            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }
        public DbSet<Menu> Menu { get; set; } 
        public DbSet<SubMenu> SubMenu { get; set; } 
        public DbSet<MenuItem> MenuItem { get; set; } 
        public DbSet<RolePermission> RolePermission { get; set; } 
    }
}
