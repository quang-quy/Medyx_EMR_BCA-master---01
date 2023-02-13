using Medyx_EMR_BCA.ApiAssets.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spire.Doc;
using Spire.Doc.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Medyx_EMR_BCA.ApiAssets.Helpers;
namespace Medyx_EMR_BCA.Controllers.API
{
    public class Sender
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public Sender(string _name, string _message)
        {
            Name = _name;
            Message = _message;
        }
    }
    public class Customer
    {
        public string ContactName { get; set; }
        public string Fax { get; set; }
        public DateTime Date { get; set; }
    }

    public class Test
    {
        public int number { get; set; }
    }

    public class KhamVaoVien
    {
        public string soyte { get; set; }
        public string benhvien { get; set; }
        public string buong { get; set; }
        public string sovaovien { get; set; }
        public string hoten { get; set; }
        public string nghe_nghiep { get; set; }
        public string dantoc { get; set; }
        public string ngoaikieu { get; set; }
        public string sonha { get; set; }
        public string thon { get; set; }
        public string xaphuong { get; set; }
        public string huyen { get; set; }
        public string thanhpho { get; set; }
        public string noilamviec { get; set; }
        public string giatribhytdn { get; set; }
        public string lienhe { get; set; }
        public string sodienthoai { get; set; }
        public string kbgiophut { get; set; }
        public string kbngaythang { get; set; }
        public string cdnoigt { get; set; }
        public string lydovaovien { get; set; }
        public string quatrinhbenhly { get; set; }
        public string tiensubanthan { get; set; }
        public string tiensugiadinh { get; set; }
        public string toanthan { get; set; }
        public int? mach { get; set; }
        public decimal? nhietdo { get; set; }
        public string huyetap { get; set; }
        public int? nhiptho { get; set; }
        public string cannang { get; set; }
        public string cacbophan { get; set; }
        public string tomtatlamsan { get; set; }
        public string chandoanvv { get; set; }
        public string daxuly { get; set; }
        public string khoa { get; set; }
        public string chuy { get; set; }
        public string bsdieutri { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public PrintController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        //public PrintController(IRepository<Account> repository)
        //{
        //    this.repository = repository;
        //}
        [HttpGet]
        public void Index()
        {
            Document document = new Document(_hostingEnvironment.WebRootPath + "/Template/Phieu-kham-benh-vao-vien-chung-template.doc", FileFormat.Auto);


            var db = new MedyxDbContext();
            var phieukhamvv = db.BenhAnKhamVaoVien.Where(
                x => x.Idba == Convert.ToDecimal(1)
            ).Include(x => x.DmBsKham)
              .Include(x => x.ThongTinBn).ThenInclude(x => x.DmngheNghiep)
              .Include(x => x.ThongTinBn).ThenInclude(x => x.DmphuongXa)
              .Include(x => x.ThongTinBn).ThenInclude(x => x.DmquanHuyen)
              .Include(x => x.ThongTinBn).ThenInclude(x => x.Dmtinh)
              .Include(x => x.ThongTinBn).ThenInclude(x => x.DmquocGia)
              .Include(x => x.ThongTinBn).ThenInclude(x => x.DmdanToc)
              .Include(x => x.BenhAn)
              .Include(x => x.DmChanDoanKkb)
            .FirstOrDefault();
            string[] GroupNames = document.MailMerge.GetMergeGroupNames();
            List<string> fields = new List<string>() { "gt_nu", "gt_nam" };
            List<string> values = new List<string>() {
                Convert.ToBoolean(phieukhamvv.ThongTinBn.GioiTinh) ? null: "x",
                Convert.ToBoolean(phieukhamvv.ThongTinBn.GioiTinh) ? "x" : null
            };

            List<KhamVaoVien> khamVaoViens = new List<KhamVaoVien>()
            {
                new KhamVaoVien()
                {
                    soyte = phieukhamvv.BenhAn.MaYt,
                    benhvien = phieukhamvv.BenhAn.TenBv,
                    buong = phieukhamvv.BenhAn.Buong,
                    sovaovien = phieukhamvv.BenhAn.SoVaoVien,
                    hoten = phieukhamvv.ThongTinBn.HoTen,
                    nghe_nghiep = phieukhamvv.ThongTinBn.DmngheNghiep.TenNn,
                    dantoc = phieukhamvv.ThongTinBn.DmdanToc.TenDanToc,
                    ngoaikieu = phieukhamvv.ThongTinBn.DmquocGia.TenQg,
                    sonha = phieukhamvv.ThongTinBn.SoNha,
                    thon = phieukhamvv.ThongTinBn.Thon,
                    xaphuong = phieukhamvv.ThongTinBn.DmphuongXa.TenPxa,
                    huyen = phieukhamvv.ThongTinBn.DmquanHuyen.TenQh,
                    thanhpho = phieukhamvv.ThongTinBn.Dmtinh.TenTinh,
                    noilamviec = phieukhamvv.ThongTinBn.NoiLamViec,
                    giatribhytdn = PrintHelper.DateText(phieukhamvv.ThongTinBn.Gtbhytdn.Value),
                    lienhe = phieukhamvv.ThongTinBn.LienHe,
                    sodienthoai = phieukhamvv.ThongTinBn.SoDienThoai,
                    kbgiophut = PrintHelper.TimeText(phieukhamvv.BenhAn.NgayVv),
                    kbngaythang = PrintHelper.DateText(phieukhamvv.BenhAn.NgayVv),
                    cdnoigt = phieukhamvv.MaBenhNoiChuyenDen,
                    lydovaovien = phieukhamvv.LyDoVv,
                    quatrinhbenhly = phieukhamvv.QuaTrinhBenhLy,
                    tiensubanthan = phieukhamvv.TienSuBanThan,
                    tiensugiadinh = phieukhamvv.TienSuGiaDinh,
                    toanthan = phieukhamvv.KhamToanThan,
                    mach = phieukhamvv.Mach,
                    nhietdo = phieukhamvv.NhietDo,
                    nhiptho = phieukhamvv.NhipTho,
                    huyetap = phieukhamvv.HuyetAp,
                    cannang = "",
                    cacbophan = phieukhamvv.CacBoPhan,
                    tomtatlamsan = PrintHelper.RegexStringReplace(phieukhamvv.TomTatKqcls, " "),
                    chandoanvv = phieukhamvv.DmChanDoanKkb.TenBenh,
                    daxuly = phieukhamvv.DaXuLy,
                    khoa = phieukhamvv.MaKhoaVv,
                    chuy = phieukhamvv.ChuY,
                    bsdieutri = phieukhamvv.DmBsKham.HoTen
                }
            };
            MailMergeDataTable table = new MailMergeDataTable("KhamVaoVien", khamVaoViens);


            string birthday = PrintHelper.BirthText(phieukhamvv.ThongTinBn.NgaySinh);
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, birthday, "ngaysinh", 8, ' ');
			PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.Tuoi.ToString(), "tuoi", 2, '0');
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaDanToc, "madantoc", 2, '0');
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaNgheNghiep, "manghenghiep", 2, '0');
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaQuocTich, "maquocgia", 2, '0');
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaHuyen, "mahuyen", 2, '0');
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaPxa, "maxa", 2, '0');
			//PrintHelper.TexboxFieldHanlder(ref fields, ref values, phieukhamvv.ThongTinBn.MaTinh, "matinh", 2, '0');
			PrintHelper.TextboxFieldDoiTuongHanlder(ref fields, ref values, phieukhamvv.DoiTuong);
			PrintHelper.TextboxFieldBHYTHanlder(ref fields, ref values, phieukhamvv.SoTheBhyt);

            document.MailMerge.ExecuteGroup(table);
            document.MailMerge.Execute(fields.ToArray(), values.ToArray());
            document.SaveToFile("Storage/demo.doc", FileFormat.Doc);
        }
    }
}
