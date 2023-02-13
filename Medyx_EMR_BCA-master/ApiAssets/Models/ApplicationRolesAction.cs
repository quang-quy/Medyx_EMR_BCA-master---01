using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class ApplicationRolesAction
    {
        public long ApplicationRolesActionId { get; set; }
        public string Account { get; set; }
        public long ApplicationActionId { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }
        public string TokenKey { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public bool? Huy { get; set; }
        public string NguoiHuy { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string ActionDetailsName { get; set; }

        public virtual ApplicationAction ApplicationAction { get; set; } = new ApplicationAction();
    }
}
