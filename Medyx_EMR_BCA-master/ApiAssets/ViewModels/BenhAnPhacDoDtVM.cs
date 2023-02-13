using System;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnPhacDoDtVM
    {
        [Required(ErrorMessage = "Stt khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }
        public string MaBenh { get; set; }
        public string TenBenh { get; set; }
        public string GiaiDoan { get; set; }
        [CompareWithNgayVv("Idba", ErrorMessage = "Ngày áp dụng phác đồ là bắt buộc và phải lớn hơn hoặc bằng ngày giờ vào viện {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày áp dụng phác đồ là bắt buộc và phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        public DateTime? NgayAdphacDo { get; set; }
        public byte? GioiTinh { get; set; }
        public byte? DoTuoiTu { get; set; }
        public byte? DoTuoiDen { get; set; }
        public string VungApDung { get; set; }
        public string MoTa { get; set; }
        public string XuTri { get; set; }
        public string TruocPhacDo { get; set; }
        public string SauPhacDo { get; set; }
        public bool? Huy { get; set; }
    }

    public class BenhAnPhacDoDtCreateVM : BenhAnPhacDoDtVM
    {
        [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
        public decimal Idba { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }
}