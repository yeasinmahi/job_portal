using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Models
{
    public class Menu
    {
        [Key]
        public int Sl { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [DisplayName("Icon Class")]
        public string IconClass { get; set; }
        [Range(0, 99)]
        public int Order { get; set; }
    }
    public class SubMenu
    {
        [Key]
        public int Sl { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [DisplayName("Icon Class")]
        [MaxLength(20)]
        public string IconClass { get; set; }
        [DefaultValue(0)]
        [Range(0, 99)]
        public int Order { get; set; }
        [Required]
        [DisplayName("Menu ID")]
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
    }

    public class MenuItem 
    {
        [Key]
        public int Sl { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [DisplayName("Icon Class")]
        [MaxLength(20)]
        public string IconClass { get; set; }
        [DefaultValue(0)]
        [Range(0,99)]
        public int Order { get; set; }
        [Required]
        [DisplayName("Menu ID")]
        public int MenuId { get; set; }
        [Required]
        [DisplayName("Sub-Menu ID")]
        public int SubMenuId { get; set; }
        [Required]
        [MaxLength(20)]
        public string ControllerName { get; set; }
        [Required]
        [MaxLength(20)]
        public string ActionName { get; set; }

        [ForeignKey("SubMenuId")]
        public virtual SubMenu SubMenu { get; set; }
    }

    public class RolePermission
    {
        [Key]
        public int Sl { get; set; }
        [Required]
        public string RoleId { get; set; }
        [Required]
        [DisplayName("Menu ID")]
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
