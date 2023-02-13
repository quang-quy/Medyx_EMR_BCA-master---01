using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class HTRaVienVM
    {
        public String MaHTRaVien { get; set; }
        public String TenHTRaVien { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String GhiChu { get; set; }
        public String mabyte { get; set; }
        public Int32 TotalRows { get; set; }

    }
    public class HTRaVien
    {
        public String MaHTRaVien { get; set; }
        public String TenHTRaVien { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String GhiChu { get; set; }
        public String mabyte { get; set; }
    }
}
