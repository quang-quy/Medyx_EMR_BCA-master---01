using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class ApplicationRolesMenu
    {
        public long ApplicationRolesMenuId { get; set; }
        public string ApplicationRolesId { get; set; }
        public string MenuId { get; set; }
        public string Description { get; set; }
        public string TokenKey { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public bool? Huy { get; set; }
        public string NguoiHuy { get; set; }
        public DateTime? NgayHuy { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
