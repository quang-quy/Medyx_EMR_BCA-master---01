using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models.DanhMuc
{
    public class DM_TinhVM
    {
        public String MaTinh { get; set; }
        public String MaQU { get; set; }
        public String MaVungLT { get; set; }
        public String TenTinh { get; set; }
        public String MaBHYT { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String Matat { get; set; }
        public Int32 TotalRows { get; set; }

    }
    public class DM_Tinh
    {
        public String MaTinh { get; set; }
        public String MaQU { get; set; }
        public String MaVungLT { get; set; }
        public String TenTinh { get; set; }
        public String MaBHYT { get; set; }
        public String MaMay { get; set; }
        public Boolean Huy { get; set; }
        public DateTime? NgaySD { get; set; }
        public String NguoiSD { get; set; }
        public String Matat { get; set; }
    }
}

