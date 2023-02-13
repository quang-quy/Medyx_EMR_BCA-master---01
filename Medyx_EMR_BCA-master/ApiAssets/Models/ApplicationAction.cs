using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class ApplicationAction
    {
        public ApplicationAction()
        {
            ApplicationRolesAction = new HashSet<ApplicationRolesAction>();
            Menu = new HashSet<Menu>();
        }

        public long ApplicationActionId { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public string TokenKey { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySua { get; set; }
        public string NguoiSua { get; set; }
        public bool? Huy { get; set; }
        public string NguoiHuy { get; set; }
        public string NgayHuy { get; set; }

        public virtual ICollection<ApplicationRolesAction> ApplicationRolesAction { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
