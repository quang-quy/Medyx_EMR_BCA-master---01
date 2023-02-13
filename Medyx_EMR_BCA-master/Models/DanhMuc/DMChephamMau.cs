using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DMChephamMau
    {
        public string MaCPMau { get; set; }
        public string TenCPMau { get; set; }
        public string TenDVT { get; set; }
        public string TenTat{ get; set; }
        public string MaBYT { get; set; }
        public string TenBYT { get; set; }
        public string MaMay { get; set; }
        public bool Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public string NguoiSD { get; set; }
    }
    public class DMChephamMauVM
    {
        public string MaCPMau { get; set; }
        public string TenCPMau { get; set; }
        public string TenDVT { get; set; }
        public string TenTat { get; set; }
        public string MaBYT { get; set; }
        public string TenBYT { get; set; }
        public string MaMay { get; set; }
        public bool Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public string NguoiSD { get; set; }
        public Int32 TotalRows { get; set; }
    }
}
