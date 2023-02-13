using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmdichVu
    {
        public string MaDv { get; set; }
        public string TenDv { get; set; }
        public string MaChungloai { get; set; }
        public string MaLh { get; set; }
        public string MaPlpttt { get; set; }
        public string TenTat { get; set; }
        public string MaByt { get; set; }
        public string TenByt { get; set; }
        public string MaNhomdv { get; set; }
        public string MaXn { get; set; }
        public string ChisocaoNu { get; set; }
        public string ChisocaoNam { get; set; }
        public string ChisothapNu { get; set; }
        public string ChisothapNam { get; set; }
        public string DonViDo { get; set; }
        public string Ghichu { get; set; }
        public string MaMay { get; set; }
        public DateTime? NgayHuy { get; set; }
        public string NguoiHuy { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public DateTime? NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public bool? Huy { get; set; }
        public virtual ICollection<BenhanTtvltl> BenhanTtvltls { get; set; }
        public virtual ICollection<BenhAnTtvltlThuchien> BenhAnTtvltlThuchien { get; set; }
        public virtual ICollection<BenhanCls> BenhanClss { get; set; }
        public virtual ICollection<DmdichVuCs> DmdichVuCss { get; set; }
    }
}
