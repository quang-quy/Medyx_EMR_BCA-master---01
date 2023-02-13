using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class Menu
    {
        public Menu()
        {
            ApplicationRolesMenu = new HashSet<ApplicationRolesMenu>();
        }

        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public int? Level { get; set; }
        public string MenuParent { get; set; }
        public long? ApplicationActionId { get; set; }

        public virtual ApplicationAction ApplicationAction { get; set; }
        public virtual ICollection<ApplicationRolesMenu> ApplicationRolesMenu { get; set; }

        public virtual Menu Parent { get; set; }
        public virtual ICollection<Menu> Children { get; set; }
    }
}
