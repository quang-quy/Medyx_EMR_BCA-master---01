using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnClsKqcsDto : BenhanClsKqcs
    {
        public new DmnhanVienDto NguoiDuyetKq { get; set; }
        public new DmnhanVienDto Ktv { get; set; }
        public DmkhoaDto KhoaThucHien { get; set; }
    }
    public sealed class BenhAnClsKqcsV2Dto : BenhanClsKqcs
    {
        public new decimal? Idba { get; set; }
        public new int? Stt { get; set; }
        public new int? Sttdv { get; set; }
        public new DmnhanVienDto NguoiDuyetKq { get; set; }
        public new DmnhanVienDto Ktv { get; set; }
        public DmkhoaDto KhoaThucHien { get; set; }
        public new DmnhanVienDto NguoiLap { get; set; }
        public new DmnhanVienDto NguoiHuy { get; set; }
        public DmnhanVienDto NguoiSD { get; set; }
    }
}
