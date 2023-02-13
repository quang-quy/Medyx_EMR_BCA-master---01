namespace Medyx_EMR_BCA.ApiAssets.Dto.Print
{
	public class SoDoPhieuChamSocPrint : IHuyetApChamSoc, INgayThangChamSoc, INhipThoChamSoc, IYtaChamSoc
	{
        public string MaKhoa { get; set; }
        public string SoYTe { get; set; }
        public string BenhVien { get; set; }
        public string MaBn { get; set; }
        public string HoTen { get; set; }
        public string Tuoi { get; set; }
        public string Giuong { get; set; }
        public string Buong { get; set; }
        public string Khoa {get; set;}
        public string NgayVV { get; set; }
        public string ChanDoan { get; set; }
        public string ChanKem { get; set; }
        public decimal?[] NhietDo { get; set; } = new decimal?[18];
        public int?[] Mach { get; set; } = new int?[18];
        public string SoDo { get; set; }
		public string HuyetAp_0 { get; set; }
		public string HuyetAp_1 { get; set; }
		public string HuyetAp_2 { get; set; }
		public string HuyetAp_3 { get; set; }
		public string HuyetAp_4 { get; set; }
		public string HuyetAp_5 { get; set; }
		public string HuyetAp_6 { get; set; }
		public string HuyetAp_7 { get; set; }
		public string HuyetAp_8 { get; set; }
		public string HuyetAp_9 { get; set; }
		public string HuyetAp_10 { get; set; }
		public string HuyetAp_11 { get; set; }
		public string HuyetAp_12 { get; set; }
		public string HuyetAp_13 { get; set; }
		public string HuyetAp_14 { get; set; }
		public string HuyetAp_15 { get; set; }
		public string HuyetAp_16 { get; set; }
		public string HuyetAp_17 { get; set; }
		public string NgayThang_0 { get; set; }
		public string NgayThang_1 { get; set; }
		public string NgayThang_2 { get; set; }
		public string NgayThang_3 { get; set; }
		public string NgayThang_4 { get; set; }
		public string NgayThang_5 { get; set; }
		public string NgayThang_6 { get; set; }
		public string NgayThang_7 { get; set; }
		public string NgayThang_8 { get; set; }
		public string NgayThang_9 { get; set; }
		public string NgayThang_10 { get; set; }
		public string NgayThang_11 { get; set; }
		public string NgayThang_12 { get; set; }
		public string NgayThang_13 { get; set; }
		public string NgayThang_14 { get; set; }
		public string NgayThang_15 { get; set; }
		public string NgayThang_16 { get; set; }
		public string NgayThang_17 { get; set; }
		public string NhipTho_0 { get; set; }
		public string NhipTho_1 { get; set; }
		public string NhipTho_2 { get; set; }
		public string NhipTho_3 { get; set; }
		public string NhipTho_4 { get; set; }
		public string NhipTho_5 { get; set; }
		public string NhipTho_6 { get; set; }
		public string NhipTho_7 { get; set; }
		public string NhipTho_8 { get; set; }
		public string NhipTho_9 { get; set; }
		public string NhipTho_10 { get; set; }
		public string NhipTho_11 { get; set; }
		public string NhipTho_12 { get; set; }
		public string NhipTho_13 { get; set; }
		public string NhipTho_14 { get; set; }
		public string NhipTho_15 { get; set; }
		public string NhipTho_16 { get; set; }
		public string NhipTho_17 { get; set; }
		public string Yta_0 { get; set; }
		public string Yta_1 { get; set; }
		public string Yta_2 { get; set; }
		public string Yta_3 { get; set; }
		public string Yta_4 { get; set; }
		public string Yta_5 { get; set; }
		public string Yta_6 { get; set; }
		public string Yta_7 { get; set; }
		public string Yta_8 { get; set; }
		public string Yta_9 { get; set; }
		public string Yta_10 { get; set; }
		public string Yta_11 { get; set; }
		public string Yta_12 { get; set; }
		public string Yta_13 { get; set; }
		public string Yta_14 { get; set; }
		public string Yta_15 { get; set; }
		public string Yta_16 { get; set; }
		public string Yta_17 { get; set; }
	}
	public interface INgayThangChamSoc{
        string NgayThang_0 { get; set; }
        string NgayThang_1 { get; set; }
        string NgayThang_2 { get; set; }
        string NgayThang_3 { get; set; }
        string NgayThang_4 { get; set; }
        string NgayThang_5 { get; set; }
        string NgayThang_6 { get; set; }
        string NgayThang_7 { get; set; }
        string NgayThang_8 { get; set; }
        string NgayThang_9 { get; set; }
        string NgayThang_10 { get; set; }
        string NgayThang_11 { get; set; }
        string NgayThang_12 { get; set; }
        string NgayThang_13 { get; set; }
        string NgayThang_14 { get; set; }
        string NgayThang_15 { get; set; }
        string NgayThang_16 { get; set; }
        string NgayThang_17 { get; set; }
    }
    public interface IHuyetApChamSoc{
        string HuyetAp_0 { get; set; }
        string HuyetAp_1 { get; set; }
        string HuyetAp_2 { get; set; }
        string HuyetAp_3 { get; set; }
        string HuyetAp_4 { get; set; }
        string HuyetAp_5 { get; set; }
        string HuyetAp_6 { get; set; }
        string HuyetAp_7 { get; set; }
        string HuyetAp_8 { get; set; }
        string HuyetAp_9 { get; set; }
        string HuyetAp_10 { get; set; }
        string HuyetAp_11 { get; set; }
        string HuyetAp_12 { get; set; }
        string HuyetAp_13 { get; set; }
        string HuyetAp_14 { get; set; }
        string HuyetAp_15 { get; set; }
        string HuyetAp_16 { get; set; }
        string HuyetAp_17 { get; set; }
    }
    public interface INhipThoChamSoc{
        string NhipTho_0 { get; set; }
        string NhipTho_1 { get; set; }
        string NhipTho_2 { get; set; }
        string NhipTho_3 { get; set; }
        string NhipTho_4 { get; set; }
        string NhipTho_5 { get; set; }
        string NhipTho_6 { get; set; }
        string NhipTho_7 { get; set; }
        string NhipTho_8 { get; set; }
        string NhipTho_9 { get; set; }
        string NhipTho_10 { get; set; }
        string NhipTho_11 { get; set; }
        string NhipTho_12 { get; set; }
        string NhipTho_13 { get; set; }
        string NhipTho_14 { get; set; }
        string NhipTho_15 { get; set; }
        string NhipTho_16 { get; set; }
        string NhipTho_17 { get; set; }
    }
    public interface IYtaChamSoc{
        string Yta_0 { get; set; }
        string Yta_1 { get; set; }
        string Yta_2 { get; set; }
        string Yta_3 { get; set; }
        string Yta_4 { get; set; }
        string Yta_5 { get; set; }
        string Yta_6 { get; set; }
        string Yta_7 { get; set; }
        string Yta_8 { get; set; }
        string Yta_9 { get; set; }
        string Yta_10 { get; set; }
        string Yta_11 { get; set; }
        string Yta_12 { get; set; }
        string Yta_13 { get; set; }
        string Yta_14 { get; set; }
        string Yta_15 { get; set; }
        string Yta_16 { get; set; }
        string Yta_17 { get; set; }
    }
}