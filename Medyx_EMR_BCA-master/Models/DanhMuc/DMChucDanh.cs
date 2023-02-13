using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMChucDanhVM
    {
        public String MaCD { get; set; }
        public String TenCD { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class DMChucDanh
    {
        public String MaCD { get; set; }
        public String TenCD { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
    }
}
