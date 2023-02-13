using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMQuocGiaVM
    {
        public String MaQG { get; set; }
        public String TenQG { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMQuocGia
    {
        public String MaQG { get; set; }
        public String TenQG { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
}
