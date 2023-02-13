using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMActionVM
    {
        public String MaAction { get; set; }
        public String TenAction { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String ButtonName { get; set; }
        public Int32 ApplicationActionID { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMAction
    {
        public String MaAction { get; set; }
        public String TenAction { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String ButtonName { get; set; }
        public Int32 ApplicationActionID { get; set; }
    }
}
