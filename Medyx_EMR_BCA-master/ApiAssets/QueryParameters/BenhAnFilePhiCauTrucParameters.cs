using System;

namespace Medyx_EMR_BCA.ApiAssets.QueryParameters
{
    public class BenhAnFilePhiCauTrucParameters : QueryStringParameters
    {
        public BenhAnFilePhiCauTrucParameters()
        {
        }
        public decimal? Idba { get; set; }
        public byte? LoaiTaiLieu { get; set; }
        public int? Sttdv { get; set; }
        public byte? Loai { get; set; }
    }
}
