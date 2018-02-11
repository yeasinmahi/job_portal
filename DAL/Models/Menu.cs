using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class Menu
    {
        [Key]
        public int Sl { get; set; }
        public string Name { get; set; }
        public string IconClass { get; set; }
        public int Order { get; set; }
    }
    public class SubMenu
    {
        [Key]
        public int Sl { get; set; }
        public string Name { get; set; }
        public string IconClass { get; set; }
        public int Order { get; set; }
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
    }

    public class MenuItem 
    {
        [Key]
        public int Sl { get; set; }
        public string Name { get; set; }
        public string IconClass { get; set; }
        public int Order { get; set; }
        public int MenuId { get; set; }
        public int SubMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        [ForeignKey("SubMenuId")]
        public virtual SubMenu SubMenu { get; set; }
    }

    public class RolePermission
    {
        [Key]
        public int Sl { get; set; }
        public string RoleId { get; set; }
        public int MenuItemId { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }
        [ForeignKey("RoleId")]
        public virtual IdentityRole IdentityRole { get; set; }
    }
}
