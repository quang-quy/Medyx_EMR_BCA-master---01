using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.ApiAssets.Dto
{
    public sealed class BenhAnKhamYhctDto : BenhAnKhamYhct
    {
        public new DmbenhTatYhctDto DmBenhDanhTheoYHCT { get; set; }
    }
}
