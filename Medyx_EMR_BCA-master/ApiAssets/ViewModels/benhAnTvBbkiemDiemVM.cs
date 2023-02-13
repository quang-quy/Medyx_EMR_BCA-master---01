using System;
using System.ComponentModel.DataAnnotations;
using Medyx_EMR_BCA.ApiAssets.AttributeCustom;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
  public class BenhAnTvBbkiemDiemVM
  {
    [Required(ErrorMessage = "Số phiếu là bắt buộc.")]
    public string SoPhieu { get; set; }
    [RangeDateTime("NgayTuVong", null, ErrorMessage = "Ngày làm biên bản phải lớn hơn hoặc bằng ngày tử vong {1}.")]
    public DateTime? ThoiGianKiemDiem { get; set; }
    public string NoiHop { get; set; }
    [RangeDateTime(null, "ThoiGianKiemDiem", ErrorMessage = "Ngày tử vong phải nhỏ hơn hoặc bằng ngày làm biên bản {2}.")]
    public DateTime? NgayTuVong { get; set; }
    public string NguyenNhanTv { get; set; }
    public string TomTatQtbenh { get; set; }
    [Required(ErrorMessage = "Tình trạng vào viện là bắt buộc.")]
    public string TinhTrangVv { get; set; }
    public string ChanDoan { get; set; }
    public string TomTatDienBien { get; set; }
    public string TiepDonBn { get; set; }
    public string ThamKham { get; set; }
    public string DieuTri { get; set; }
    public string ChamSoc { get; set; }
    public string QuanHeVoiGdbn { get; set; }
    public string YkienBoSung { get; set; }
    public string KetLuan { get; set; }
    public string ChuToa { get; set; }
    public string ThuKy { get; set; }
    public bool? Huy { get; set; }
  }

  public class BenhAnTvBbkiemDiemCreateVM : BenhAnTvBbkiemDiemVM
  {
    [Required(ErrorMessage = "ID bệnh án là bắt buộc.")]
    public decimal Idba { get; set; }

    //No need in body
    public string MaBa { get; set; }
    public string MaBn { get; set; }
    public string MaKhoa { get; set; }
    public int? Sttkhoa { get; set; }

  }
}