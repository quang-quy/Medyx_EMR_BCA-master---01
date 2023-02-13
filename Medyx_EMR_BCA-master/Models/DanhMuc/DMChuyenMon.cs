using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMChuyenMon
    {
        public string MaChuyenMon { get; set; }
        public string TenChuyenMon { get; set; }
        public string MaMay { get; set; }
        public byte? Cap { get; set; }
        public string Loai { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySD { get; set; }
        public string NguoiSD { get; set; }
        public string GhiChu { get; set; }
    }
    public class DMChuyenMonVm
    {
        public Int32 Ordernumber { get; set; }
        public String MaChuyenMon { get; set; }
        public String TenChuyenMon { get; set; }
        public String MaMay { get; set; }
        public Byte Cap { get; set; }
        public String Loai { get; set; }
        public Boolean Huy { get; set; }
        public DateTime NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String GhiChu { get; set; }
        public Int32 TotalRows { get; set; }
    }
}
