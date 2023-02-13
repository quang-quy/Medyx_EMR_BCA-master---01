using System;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class Account
    {
        public string MaNv { get; set; }
        public string Account1 { get; set; }
        public string Password { get; set; }
        public string MaKhoaLs { get; set; }
        public string MaKhoaCls { get; set; }
        public string MaKho { get; set; }
        public bool AllMaKho { get; set; }
        public bool AllMaKhoaCls { get; set; }
        public bool AllMaKhoaLs { get; set; }
        public string QuyenDtuong { get; set; }
        public bool AllQuyenDtuong { get; set; }
        public string MaMay { get; set; }
        public bool? Huy { get; set; }
        public DateTime NgaySd { get; set; }
        public string NguoiSd { get; set; }
        public bool? Qadmin { get; set; }
        public bool? Qsgia { get; set; }
        public string Manv1 { get; set; }
        public string Acc1 { get; set; }
        public string AccountHd { get; set; }
        public string PasswordHd { get; set; }
        public string MaLtdt { get; set; }
        public string PassLtdt { get; set; }
        public string ApplicationRolesId { get; set; }
    }
}
