using System.Collections.Generic;
namespace Medyx_EMR_BCA.ApiAssets.Models
{
    public partial class DmbenhTatYhct
    {
        public string Sttchuong { get; set; }
        public string MaChuong { get; set; }
        public string TenChuong { get; set; }
        public int? Stt { get; set; }
        public string MaBenh { get; set; }
        public string TenBenh { get; set; }
        public string MaBenhIcd { get; set; }
        public string TenBenhIcd { get; set; }
        public string TenBenhBhyt { get; set; }
        public virtual ICollection<BenhAn> BenhNoiChuyenDenYHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhKKBYHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhChinhVVYHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhKemVV1YHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhKemVV2YHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhKemVV3YHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhChinhRVYHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhKemRV1YHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhKemRV2YHCTs { get; set; }
        public virtual ICollection<BenhAn> BenhKemRV3YHCTs { get; set; }
        public virtual ICollection<BenhAnKhamYhct> BenhAnKhamYhcts { get; set; }
    }
}
