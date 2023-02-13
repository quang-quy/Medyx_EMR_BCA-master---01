using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMChucVuVM
    {
        public String MaCV { get; set; }
        public String TenCV { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String GhiChu { get; set; }
        public Int32 TotalRows { get; set; }

    }
    public class DMChucVu
    {
        public String MaCV { get; set; }
        public String TenCV { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String GhiChu { get; set; }
    }
}
