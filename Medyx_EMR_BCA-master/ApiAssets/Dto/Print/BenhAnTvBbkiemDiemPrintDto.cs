using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto.Print
{
    public class BenhAnTvBbkiemDiemPrintDto:BenhAnTvBbkiemDiem
    {
        public new DmnhanVienDto DmChuToa { get; set; }
        public new DmnhanVienDto DmThuKy { get; set; }
        public new BenhAnKhoaDieuTriDto BenhAnKhoaDieuTri { get; set; }
    }
}