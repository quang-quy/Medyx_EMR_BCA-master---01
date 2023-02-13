using Microsoft.AspNetCore.Http;

namespace Medyx_EMR_BCA.ApiAssets.ViewModels
{
    public class BenhAnClsFilePrintUploadVM : BenhAnClsFilePrintVM
    {
        // [FromForm(Name = "Files[]")]
        // public List<IFormFile> Files { get; set; } = new List<IFormFile>();
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }
        public IFormFile Image5 { get; set; }
        public IFormFile Image6 { get; set; }
    }
}