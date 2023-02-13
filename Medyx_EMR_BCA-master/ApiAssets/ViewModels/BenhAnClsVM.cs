using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;
using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnClsVM
    {
        [BindRequired]
        public decimal Idba { get; set; }
        [Required(ErrorMessage = "Số thứ tự khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }

        [FromForm(Name = "Files[]")]
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
        [BindRequired]
        public byte LoaiTaiLieu { get; set; }
        [Required(ErrorMessage = "Số phiếu là bắt buộc.")]
        public string SoPhieu { get; set; }
        public byte? Capcuu { get; set; }
        public string KyThuat { get; set; }
        public string MoTa { get; set; }
        [Required(ErrorMessage = "Kết luận là bắt buộc.")]
        public string KetLuan { get; set; }
        public string BsChuyenKhoa { get; set; }
        public string LinkPacsLis { get; set; }
        [Required(ErrorMessage = "Khoa phòng thực hiện là bắt buộc.")]
        public string MaKhoaThucHien { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày tiếp nhận phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày tiếp nhận phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime(null, "NgayKq", ErrorMessage = "Ngày tiếp nhận phải nhỏ hơn hoặc bằng ngày thực hiện {2}.")]
        public DateTime? NgayTiepNhan { get; set; }
        [CompareWithNgayVaoKhoa("Idba", "Sttkhoa", ErrorMessage = "Ngày thực hiện phải lớn hơn hoặc bằng ngày vào khoa {1}.")]
        [CompareWithNgayRv("Idba", ErrorMessage = "Ngày thực hiện phải nhỏ hơn hoặc bằng ngày giờ ra viện {1}.")]
        [RangeDateTime("NgayTiepNhan", null, ErrorMessage = "Ngày thực hiện phải lớn hơn hoặc bằng ngày tiếp nhận {1}.")]
        public DateTime? NgayKq { get; set; }
    }

    public class BenhAnClsWithFileCreateVM : BenhAnClsVM
    {
        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }

    // Su dung trong to dieu tri
    public class BenhAnClsCreateVM : BenhAnClsUpdateVM
    {
        [BindRequired]
        public decimal Idba { get; set; }
        public string MaGoi { get; set; }
        [Required(ErrorMessage = "Số thứ tự khoa là bắt buộc.")]
        public int? Sttkhoa { get; set; }

        [Required(ErrorMessage = "Ngày y lệnh là bắt buộc.")]
        public DateTime? NgayYlenh { get; set; }

        //No need in body
        public int Stt { get; set; }
        public string Idhis { get; set; }
        public string MaBa { get; set; }
        public string MaBn { get; set; }
    }

    // Su dung trong to dieu tri
    public class BenhAnClsUpdateVM
    {
        public string DoiTuong { get; set; }
        [RequiredIf("MaGoi", null, ErrorMessage = "Mã dịch vụ là bắt buộc.")]
        public string MaDv { get; set; }
        public string ViTri { get; set; }
        public byte? Capcuu { get; set; }
        public string Bschidinh { get; set; }
        public bool? Huy { get; set; }
    }
}