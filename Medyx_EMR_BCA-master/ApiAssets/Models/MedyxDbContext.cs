using Medyx.ApiAssets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Medyx_EMR_BCA.ApiAssets.Models
{
	public partial class MedyxDbContext : DbContext
	{
		public MedyxDbContext()
		{
		}

		public MedyxDbContext(DbContextOptions<MedyxDbContext> options)
		  : base(options)
		{
		}
		public virtual DbSet<Account> Account { get; set; }
		public virtual DbSet<ApplicationAction> ApplicationAction { get; set; }
		public virtual DbSet<ApplicationRolesAction> ApplicationRolesAction { get; set; }
		public virtual DbSet<ApplicationRolesMenu> ApplicationRolesMenu { get; set; }
		public virtual DbSet<BenhAn> BenhAn { get; set; }
		public virtual DbSet<BenhAnClsKq> BenhAnClsKq { get; set; }
		public virtual DbSet<BenhAnFilePhiCauTruc> BenhAnFilePhiCauTruc { get; set; }
		public virtual DbSet<BenhAnGiayChuyenTuyen> BenhAnGiayChuyenTuyen { get; set; }
		public virtual DbSet<BenhAnHoiChan> BenhAnHoiChan { get; set; }
		public virtual DbSet<BenhAnKhamBenhYhct> BenhAnKhamBenhYhct { get; set; }
		public virtual DbSet<BenhAnKhamBenhYhhd> BenhAnKhamBenhYhhd { get; set; }
		public virtual DbSet<BenhAnKhamSangLocDd> BenhAnKhamSangLocDd { get; set; }
		public virtual DbSet<BenhAnKhamVaoVien> BenhAnKhamVaoVien { get; set; }
		public virtual DbSet<BenhAnKhamYhct> BenhAnKhamYhct { get; set; }
		public virtual DbSet<BenhAnKhamYhhd> BenhAnKhamYhhd { get; set; }
		public virtual DbSet<BenhAnKhoaDieuTri> BenhAnKhoaDieuTri { get; set; }
		public virtual DbSet<BenhAnPhieuChamSoc> BenhAnPhieuChamSoc { get; set; }
		public virtual DbSet<BenhAnPhieuSangLocDd> BenhAnPhieuSangLocDd { get; set; }
		public virtual DbSet<BenhAnPhacDoDt> BenhAnPhacDoDt { get; set; }
		public virtual DbSet<BenhAnTaiBienPttt> BenhAnTaiBienPttt { get; set; }
		public virtual DbSet<BenhAnTheoDoiTruyenMau> BenhAnTheoDoiTruyenMau { get; set; }
		public virtual DbSet<BenhAnTheodoiTruyenMauC> BenhAnTheodoiTruyenMauC { get; set; }
		public virtual DbSet<BenhAnThuocThuPhanUng> BenhAnThuocThuPhanUng { get; set; }
		public virtual DbSet<BenhAnTienSuBenh> BenhAnTienSuBenh { get; set; }
		public virtual DbSet<BenhAnToDieuTri> BenhAnToDieuTri { get; set; }
		public virtual DbSet<BenhAnTongKet15NgayDt> BenhAnTongKet15NgayDt { get; set; }
		public virtual DbSet<BenhAnTongKetBenhAn> BenhAnTongKetBenhAn { get; set; }
		public virtual DbSet<BenhAnTtvltlThuchien> BenhAnTtvltlThuchien { get; set; }
		public virtual DbSet<BenhAnTvBbkiemDiem> BenhAnTvBbkiemDiem { get; set; }
		public virtual DbSet<BenhAnTvBbkiemDiemTv> BenhAnTvBbkiemDiemTv { get; set; }
		public virtual DbSet<BenhAnTvGiayBaoTu> BenhAnTvGiayBaoTu { get; set; }
		public virtual DbSet<BenhAnTvPhieuCdnguyenNhan> BenhAnTvPhieuCdnguyenNhan { get; set; }
		public virtual DbSet<BenhanCls> BenhanCls { get; set; }
		public virtual DbSet<BenhanClsKqcs> BenhanClsKqcs { get; set; }
		public virtual DbSet<BenhanCpm> BenhanCpm { get; set; }
		public virtual DbSet<BenhanPhauThuat> BenhanPhauThuat { get; set; }
		public virtual DbSet<BenhAnPhauThuatDuyetMo> BenhAnPhauThuatDuyetMo { get; set; }
		public virtual DbSet<BenhanPhauThuatPhieuKhamGayMeTruocMo> BenhanPhauThuatPhieuKhamGayMeTruocMo { get; set; }
		public virtual DbSet<BenhanPhauThuatPhieuPttt> BenhanPhauThuatPhieuPttt { get; set; }
		public virtual DbSet<BenhanTheodoiTruyenDich> BenhanTheodoiTruyenDich { get; set; }
		public virtual DbSet<BenhanThuocTayY> BenhanThuocTayY { get; set; }
		public virtual DbSet<BenhanThuocYhct> BenhanThuocYhct { get; set; }
		public virtual DbSet<BenhanThuocYhctC> BenhanThuocYhctC { get; set; }
		public virtual DbSet<BenhanTiensubenhBenhphoihop> BenhanTiensubenhBenhphoihop { get; set; }
		public virtual DbSet<BenhanTtvltl> BenhanTtvltl { get; set; }
		public virtual DbSet<BenhanTtvltlDotDieuTri> BenhanTtvltlDotDieuTri { get; set; }
		public virtual DbSet<BienBanKiemDiemTuVong> BienBanKiemDiemTuVong { get; set; }
		public virtual DbSet<ChiDinhCpm> ChiDinhCpm { get; set; }
		public virtual DbSet<ChiDinhPt> ChiDinhPt { get; set; }
		public virtual DbSet<ChiDinhThuocTayY> ChiDinhThuocTayY { get; set; }
		public virtual DbSet<ChiDinhThuocYhct> ChiDinhThuocYhct { get; set; }
		public virtual DbSet<ChiDinhVltl> ChiDinhVltl { get; set; }
		public virtual DbSet<DmbaChuyenVien> DmbaChuyenVien { get; set; }
		public virtual DbSet<DmbaCombods> DmbaCombods { get; set; }
		public virtual DbSet<DmbaHtraVien> DmbaHtraVien { get; set; }
		public virtual DbSet<DmbaHuongDt> DmbaHuongDt { get; set; }
		public virtual DbSet<DmbaKqdtri> DmbaKqdtri { get; set; }
		public virtual DbSet<DmbaKqgpb> DmbaKqgpb { get; set; }
		public virtual DbSet<DmbaLdchuyenVien> DmbaLdchuyenVien { get; set; }
		public virtual DbSet<DmbaLdtvong> DmbaLdtvong { get; set; }
		public virtual DbSet<DmbaLoaiBa> DmbaLoaiBa { get; set; }
		public virtual DbSet<DmbaLoaiTaiLieu> DmbaLoaiTaiLieu { get; set; }
		public virtual DbSet<DmbaNoiGt> DmbaNoiGt { get; set; }
		public virtual DbSet<DmbaNoiKham> DmbaNoiKham { get; set; }
		public virtual DbSet<DmbaTgtvong> DmbaTgtvong { get; set; }
		public virtual DbSet<DmbenhTat> DmbenhTat { get; set; }
		public virtual DbSet<DmbenhTatYhct> DmbenhTatYhct { get; set; }
		public virtual DbSet<DmchephamMau> DmchephamMau { get; set; }
		public virtual DbSet<DmchucDanh> DmchucDanh { get; set; }
		public virtual DbSet<DmchucVu> DmchucVu { get; set; }
		public virtual DbSet<DmchuyenKhoa> DmchuyenKhoa { get; set; }
		public virtual DbSet<DmchuyenMon> DmchuyenMon { get; set; }
		public virtual DbSet<DmdanToc> DmdanToc { get; set; }
		public virtual DbSet<DmdichVu> DmdichVu { get; set; }
		public virtual DbSet<DmdichVuChungloai> DmdichVuChungloai { get; set; }
		public virtual DbSet<DmdichVuCs> DmdichVuCs { get; set; }
		public virtual DbSet<DmdichVuLoaiHinh> DmdichVuLoaiHinh { get; set; }
		public virtual DbSet<DmdichVuNhom> DmdichVuNhom { get; set; }
		public virtual DbSet<DmdichvuNhomInChiDinh> DmdichvuNhomInChiDinh { get; set; }
		public virtual DbSet<DmdichvuPhanLoaiPttt> DmdichvuPhanLoaiPttt { get; set; }
		public virtual DbSet<DmdoiTuong> DmdoiTuong { get; set; }
		public virtual DbSet<DmhuongDt> DmhuongDt { get; set; }
		public virtual DbSet<Dmkhoa> Dmkhoa { get; set; }
		public virtual DbSet<DmkhoaB> DmkhoaB { get; set; }
		public virtual DbSet<DmkhoaBuong> DmkhoaBuong { get; set; }
		public virtual DbSet<DmkhoaGiuong> DmkhoaGiuong { get; set; }
		public virtual DbSet<DmloaiBa> DmloaiBa { get; set; }
		public virtual DbSet<DmloaiHd> DmloaiHd { get; set; }
		public virtual DbSet<DmngheNghiep> DmngheNghiep { get; set; }
		public virtual DbSet<DmnhanVien> DmnhanVien { get; set; }
		public virtual DbSet<Dmnhom> Dmnhom { get; set; }
		public virtual DbSet<DmphauThuat> DmphauThuat { get; set; }
		public virtual DbSet<DmphuongXa> DmphuongXa { get; set; }
		public virtual DbSet<DmquanHuyen> DmquanHuyen { get; set; }
		public virtual DbSet<DmquocGia> DmquocGia { get; set; }
		public virtual DbSet<Dmthuoc> Dmthuoc { get; set; }
		public virtual DbSet<DmthuocChungloai> DmthuocChungloai { get; set; }
		public virtual DbSet<DmthuocDangBaoChe> DmthuocDangBaoChe { get; set; }
		public virtual DbSet<DmthuocDonvitinh> DmthuocDonvitinh { get; set; }
		public virtual DbSet<DmthuocDuongDung> DmthuocDuongDung { get; set; }
		public virtual DbSet<DmthuocNhaSx> DmthuocNhaSx { get; set; }
		public virtual DbSet<DmthuocNhom> DmthuocNhom { get; set; }
		public virtual DbSet<DmthuocPhanLoai> DmthuocPhanLoai { get; set; }
		public virtual DbSet<Dmtinh> Dmtinh { get; set; }
		public virtual DbSet<Dmvtyt> Dmvtyt { get; set; }
		public virtual DbSet<DmvtytDonvitinh> DmvtytDonvitinh { get; set; }
		public virtual DbSet<DmvtytNhom> DmvtytNhom { get; set; }
		public virtual DbSet<DotDieuTri> DotDieuTri { get; set; }
		public virtual DbSet<FilePhiCauTruc> FilePhiCauTruc { get; set; }
		public virtual DbSet<GiayChuyenTuyen> GiayChuyenTuyen { get; set; }
		public virtual DbSet<GiayCnphauThuat> GiayCnphauThuat { get; set; }
		public virtual DbSet<KetQuaXetNghiem> KetQuaXetNghiem { get; set; }
		public virtual DbSet<Menu> Menu { get; set; }
		public virtual DbSet<PhacDo> PhacDo { get; set; }
		public virtual DbSet<PhieuChamSoc> PhieuChamSoc { get; set; }
		public virtual DbSet<PhieuChanDoanNntuVong> PhieuChanDoanNntuVong { get; set; }
		public virtual DbSet<PhieuChupCht> PhieuChupCht { get; set; }
		public virtual DbSet<PhieuChupXquang> PhieuChupXquang { get; set; }
		public virtual DbSet<PhieuDienNao> PhieuDienNao { get; set; }
		public virtual DbSet<PhieuDienTim> PhieuDienTim { get; set; }
		public virtual DbSet<PhieuDoLoangXuong> PhieuDoLoangXuong { get; set; }
		public virtual DbSet<PhieuHoiChan> PhieuHoiChan { get; set; }
		public virtual DbSet<PhieuKhamGayMeTruocMo> PhieuKhamGayMeTruocMo { get; set; }
		public virtual DbSet<PhieuKhamVaoVien> PhieuKhamVaoVien { get; set; }
		public virtual DbSet<Pttt> Pttt { get; set; }
		public virtual DbSet<Roles> Roles { get; set; }
		public virtual DbSet<TaiBienPttt> TaiBienPttt { get; set; }
		public virtual DbSet<ThanhVienHc> ThanhVienHc { get; set; }
		public virtual DbSet<ThongTinBn> ThongTinBn { get; set; }
		public virtual DbSet<ThuPhanUngThuoc> ThuPhanUngThuoc { get; set; }
		public virtual DbSet<ThucHienVltl> ThucHienVltl { get; set; }
		public virtual DbSet<TokenApi> TokenApi { get; set; }
		public virtual DbSet<TongKet15Ngay> TongKet15Ngay { get; set; }
		public virtual DbSet<TraceLog> TraceLog { get; set; }
		public virtual DbSet<TraceLogKieuTacDong> TraceLogKieuTacDong { get; set; }
		public virtual DbSet<TraceLogTableName> TraceLogTableName { get; set; }
		public virtual DbSet<TruyenDich> TruyenDich { get; set; }
		public virtual DbSet<DmdichvuGoi> DmdichvuGoi { get; set; }
		public virtual DbSet<DmdichvuGoiC> DmdichvuGoiC { get; set; }
		public virtual DbSet<DmthuocBaiThuoc> DmthuocBaiThuoc { get; set; }
		public virtual DbSet<DmthuocBaiThuocC> DmthuocBaiThuocC { get; set; }

		// Unable to generate entity type for table 'dbo.DMDichVu_BYT'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.DMAction'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuKhamChuyenKhoaB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuChupCLVTB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuSieuAmB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuNoiSoiB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuXetNghiemB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.KetQuaCLSB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.BenhAn_ChamSocB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.ChucNangSongB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuLuongGiaHDCNB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuKhamChiDinhPHCNB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuThucHienPHCNB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.PhieuCongKhaiDVKCBNTB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.ChiDinhVTB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.GiayRaVienB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.GiayKCBTheoYCB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.GiayCNThuongTichB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.DMBA_ComboDS'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.BenhAn_ChanDoanYHHDB'. Please see the warning messages.
		// Unable to generate entity type for table 'dbo.BenhAn_ChanDoanYHCTB'. Please see the warning messages.
		private ILoggerFactory GetLoggerFactory()
		{
			IServiceCollection serviceCollection = new ServiceCollection();
			serviceCollection.AddLogging(builder =>
				   builder.AddConsole()
						  .AddFilter(DbLoggerCategory.Database.Command.Name,
									 LogLevel.Information));
			return serviceCollection.BuildServiceProvider()
					.GetService<ILoggerFactory>();
		}

		/*public static readonly ILoggerFactory loggerFactory = new LoggerFactory(
         	new[] { new ConsoleLoggerProvider((_, __) => true, true) }
         );*/

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
				optionsBuilder
				//.UseLoggerFactory(GetLoggerFactory())  //tie-up DbContext with LoggerFactory object
				//.EnableSensitiveDataLogging()
				.UseSqlServer(connectionString, v => { v.UseRelationalNulls(); });
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

			modelBuilder.Entity<Account>(entity =>
			{
				entity.HasKey(e => new { e.MaNv, e.Account1 });

				entity.Property(e => e.MaNv)
					.HasColumnName("MaNV")
					.HasMaxLength(6);

				entity.Property(e => e.Account1)
					.HasColumnName("Account")
					.HasMaxLength(100);

				entity.Property(e => e.Acc1)
					.HasColumnName("acc1")
					.HasMaxLength(50);

				entity.Property(e => e.AccountHd)
					.HasColumnName("accountHD")
					.HasMaxLength(50);

				entity.Property(e => e.AllMaKhoaCls).HasColumnName("AllMaKhoaCLS");

				entity.Property(e => e.AllMaKhoaLs).HasColumnName("AllMaKhoaLS");

				entity.Property(e => e.AllQuyenDtuong).HasColumnName("AllQuyenDTuong");

				entity.Property(e => e.ApplicationRolesId).HasMaxLength(128);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaKho).HasMaxLength(1000);

				entity.Property(e => e.MaKhoaCls)
					.HasColumnName("MaKhoaCLS")
					.HasMaxLength(1000);

				entity.Property(e => e.MaKhoaLs)
					.HasColumnName("MaKhoaLS")
					.HasMaxLength(1000);

				entity.Property(e => e.MaLtdt)
					  .HasColumnName("MaLTDT")
					  .HasMaxLength(50);

				entity.Property(e => e.MaMay)
					  .IsRequired()
					  .HasMaxLength(20);

				entity.Property(e => e.Manv1)
					  .HasColumnName("manv1")
					  .HasMaxLength(50);

				entity.Property(e => e.NgaySd)
					  .HasColumnName("NgaySD")
					  .HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					  .IsRequired()
					  .HasColumnName("NguoiSD")
					  .HasMaxLength(6);

				entity.Property(e => e.PassLtdt)
					  .HasColumnName("PassLTDT")
					  .HasMaxLength(50);

				entity.Property(e => e.Password).HasMaxLength(100);

				entity.Property(e => e.PasswordHd)
					  .HasColumnName("passwordHD")
					  .HasMaxLength(50);

				entity.Property(e => e.Qadmin).HasDefaultValueSql("((0))");

				entity.Property(e => e.Qsgia).HasDefaultValueSql("((0))");

				entity.Property(e => e.QuyenDtuong)
					  .HasColumnName("QuyenDTuong")
					  .HasMaxLength(400);
			});

			modelBuilder.Entity<ApplicationAction>(entity =>
			{
				entity.Property(e => e.ActionName)
					.IsRequired()
					.HasMaxLength(256)
					.IsUnicode(false);

				entity.Property(e => e.Description).HasMaxLength(256);

				entity.Property(e => e.NgayHuy).HasMaxLength(6);

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySua).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(6);

				entity.Property(e => e.NguoiLap).HasMaxLength(6);

				entity.Property(e => e.NguoiSua).HasMaxLength(6);

				entity.Property(e => e.TokenKey).HasMaxLength(20);
			});

			modelBuilder.Entity<ApplicationRolesAction>(entity =>
			{
				entity.Property(e => e.Account)
					.IsRequired()
					.HasMaxLength(128);

				entity.Property(e => e.ActionDetailsName).HasMaxLength(500);

				entity.Property(e => e.Description).HasMaxLength(500);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(6);

				entity.Property(e => e.NguoiLap).HasMaxLength(6);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TokenKey).HasMaxLength(20);

				entity.HasOne(d => d.ApplicationAction)
					.WithMany(p => p.ApplicationRolesAction)
					.HasForeignKey(d => d.ApplicationActionId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_ApplicationRolesAction_ApplicationAction");
			});

			modelBuilder.Entity<ApplicationRolesMenu>(entity =>
			{
				entity.Property(e => e.ApplicationRolesId)
					.IsRequired()
					.HasMaxLength(128);

				entity.Property(e => e.Description).HasMaxLength(500);

				entity.Property(e => e.MenuId).HasMaxLength(128);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(6);

				entity.Property(e => e.NguoiLap).HasMaxLength(6);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TokenKey).HasMaxLength(20);

				entity.HasOne(d => d.Menu)
					.WithMany(p => p.ApplicationRolesMenu)
					.HasForeignKey(d => d.MenuId)
					.HasConstraintName("FK_ApplicationRolesMenu_Menu");
			});

			modelBuilder.Entity<BenhAn>(entity =>
			{
				entity.HasKey(e => e.Idba);

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BienChungYhct)
					.HasColumnName("BienChungYHCT")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.BienChungYhhd)
					.HasColumnName("BienChungYHHD")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.Buong).HasMaxLength(50);

				entity.Property(e => e.ChuyenVien).HasMaxLength(50);

				entity.Property(e => e.GiaiPhauBenh).HasMaxLength(50);

				entity.Property(e => e.GiamDoc).HasMaxLength(50);

				entity.Property(e => e.Giuong).HasMaxLength(50);

				entity.Property(e => e.HtraVien)
					.HasColumnName("HTRaVien")
					.HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Kqdt)
					.HasColumnName("KQDT")
					.HasMaxLength(50);

				entity.Property(e => e.LoaiBa).HasColumnName("LoaiBA");

				entity.Property(e => e.LoiDan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhChinhRv)
					.HasColumnName("MaBenhChinhRV")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhChinhRvyhct)
					.HasColumnName("MaBenhChinhRVYHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhChinhVv)
					.HasColumnName("MaBenhChinhVV")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhChinhVvyhct)
					.HasColumnName("MaBenhChinhVVYHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhGptuThi)
					.HasColumnName("MaBenhGPTuThi")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemRv1)
					.HasColumnName("MaBenhKemRV1")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemRv1yhct)
					.HasColumnName("MaBenhKemRV1YHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemRv2)
					.HasColumnName("MaBenhKemRV2")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemRv2yhct)
					.HasColumnName("MaBenhKemRV2YHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemRv3)
					.HasColumnName("MaBenhKemRV3")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemRv3yhct)
					.HasColumnName("MaBenhKemRV3YHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVv1)
					.HasColumnName("MaBenhKemVV1")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVv1yhct)
					.HasColumnName("MaBenhKemVV1YHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVv2)
					.HasColumnName("MaBenhKemVV2")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVv2yhct)
					.HasColumnName("MaBenhKemVV2YHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVv3)
					.HasColumnName("MaBenhKemVV3")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVv3yhct)
					.HasColumnName("MaBenhKemVV3YHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKkbyhct)
					.HasColumnName("MaBenhKKBYHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKkbyhhd)
					.HasColumnName("MaBenhKKBYHHD")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhNoiChuyenDenYhct)
					.HasColumnName("MaBenhNoiChuyenDenYHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhNoiChuyenDenYhhd)
					.HasColumnName("MaBenhNoiChuyenDenYHHD")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaBv)
					.IsRequired()
					.HasColumnName("MaBV")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoaVv)
					.IsRequired()
					.HasColumnName("MaKhoaVV")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaYt)
					.IsRequired()
					.HasColumnName("MaYT")
					.HasMaxLength(50);

				entity.Property(e => e.NgayBatDauNghiViecHuongBhxh)
					.HasColumnName("NgayBatDauNghiViecHuongBHXH")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayCapGiayCnnvhuongBhxh)
					.HasColumnName("NgayCapGiayCNNVHuongBHXH")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKetThucNghiViecHuongBhxh)
					.HasColumnName("NgayKetThucNghiViecHuongBHXH")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgayLuuTru).HasColumnType("datetime");

				entity.Property(e => e.NgayRv)
					.HasColumnName("NgayRV")
					.HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTruongKhoaKy).HasColumnType("datetime");

				entity.Property(e => e.NgayTuVong).HasColumnType("datetime");

				entity.Property(e => e.NgayVv)
					.HasColumnName("NgayVV")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayXacNhanKetThucHs)
					.HasColumnName("NgayXacNhanKetThucHS")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiLuuTru).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiXacnhanKetThucHs)
					.HasColumnName("NguoiXacnhanKetThucHS")
					.HasMaxLength(50);

				entity.Property(e => e.NguyenNhanTuVong).HasMaxLength(500);

				entity.Property(e => e.MaBvChuyenDen)
					.HasColumnName("MaBVChuyenDen")
					.HasMaxLength(50);

				entity.Property(e => e.NoiGt)
					.HasColumnName("NoiGT")
					.HasMaxLength(50);

				entity.Property(e => e.PhauThuatYhct)
					.HasColumnName("PhauThuatYHCT")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.PhauThuatYhhd)
					.HasColumnName("PhauThuatYHHD")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.SoLuuTru).HasMaxLength(50);

				entity.Property(e => e.SoVaoVien)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.TaiBienYhct)
					.HasColumnName("TaiBienYHCT")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.TaiBienYhhd)
					.HasColumnName("TaiBienYHHD")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.TenBenhChinhRv)
					.HasColumnName("TenBenhChinhRV")
					.HasMaxLength(500);

				entity.Property(e => e.TenBenhChinhRvyhct)
					.HasColumnName("TenBenhChinhRVYHCT")
					.HasMaxLength(500);

				entity.Property(e => e.TenBenhChinhVv)
					.HasColumnName("TenBenhChinhVV")
					.HasMaxLength(500);

				entity.Property(e => e.TenBenhChinhVvyhct)
					.HasColumnName("TenBenhChinhVVYHCT")
					.HasMaxLength(500);

				entity.Property(e => e.TenBv)
					.IsRequired()
					.HasColumnName("TenBV")
					.HasMaxLength(250);

				entity.Property(e => e.TenDvcq)
					.IsRequired()
					.HasColumnName("TenDVCQ")
					.HasMaxLength(250);

				entity.Property(e => e.ThuThuatYhct)
					.HasColumnName("ThuThuatYHCT")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.ThuThuatYhhd)
					.HasColumnName("ThuThuatYHHD")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.TinhTrangTuVong).HasMaxLength(50);

				entity.Property(e => e.TongSoNgayDt)
					.HasColumnName("TongSoNgayDT")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.TrucTiepVao).HasMaxLength(50);

				entity.Property(e => e.TruongKhoa).HasMaxLength(50);

				entity.Property(e => e.Vvlan)
					.HasColumnName("VVLan")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.XacNhanKetThucHs)
					.HasColumnName("XacNhanKetThucHS")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.XacNhanLuuTru).HasDefaultValueSql("((0))");

				entity.HasOne(ba => ba.ThongTinBn)
					.WithMany(bn => bn.BenhAns)
					.HasForeignKey(fk => new { fk.MaBn, fk.Idba })
					.HasPrincipalKey(pk => new { pk.MaBn, pk.Idba });

				entity.HasOne(ba => ba.DmbaLoaiBa)
					.WithMany(lba => lba.BenhAns)
					.HasForeignKey(fk => fk.LoaiBa)
					.HasPrincipalKey(pk => pk.MaLoaiBa);

				entity.HasOne(ba => ba.Dmkhoa)
					.WithMany(k => k.BenhAns)
					.HasForeignKey(fk => fk.MaKhoaVv)
					.HasPrincipalKey(pk => pk.MaKhoa);

				entity.HasOne(ba => ba.DmkhoaBuong)
				   .WithMany(kb => kb.BenhAns)
				   .HasForeignKey(fk => new { fk.Buong, fk.MaKhoaVv })
				   .HasPrincipalKey(pk => new { pk.MaBuong, pk.MaKhoa });

				entity.HasOne(ba => ba.DmkhoaGiuong)
					.WithMany(kg => kg.BenhAns)
					.HasForeignKey(fk => new { fk.Giuong, fk.Buong, fk.MaKhoaVv })
					.HasPrincipalKey(pk => new { pk.MaGiuong, pk.MaBuong, pk.MaKhoa });

				entity.HasOne(ba => ba.DmbaNoiKham)
					.WithMany(dm => dm.BenhAns)
					.HasForeignKey(fk => fk.TrucTiepVao)
					.HasPrincipalKey(pk => pk.MaNoiKham);

				entity.HasOne(ba => ba.DmbaNoiGt)
					.WithMany(dm => dm.BenhAns)
					.HasForeignKey(fk => fk.NoiGt)
					.HasPrincipalKey(pk => pk.MaNoiGt);

				entity.HasOne(ba => ba.DmbaChuyenVien)
					.WithMany(dm => dm.BenhAns)
					.HasForeignKey(fk => fk.ChuyenVien)
					.HasPrincipalKey(pk => pk.MaChuyenvien);

				entity.HasOne(ba => ba.DmbenhVien)
					.WithMany(dm => dm.BenhAns)
					.HasForeignKey(fk => fk.MaBvChuyenDen)
					.HasPrincipalKey(pk => pk.MaBv);

				entity.HasOne(ba => ba.DmbaHtraVien)
					.WithMany(dm => dm.BenhAns)
					.HasForeignKey(fk => fk.HtraVien)
					.HasPrincipalKey(pk => pk.MaHtraVien);

				entity.HasOne(ba => ba.DmBenhTatNoiChuyenDen)
					.WithMany(dm => dm.BenhAnNoiChuyenDens)
					.HasForeignKey(fk => fk.MaBenhNoiChuyenDenYhhd)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKKBYHHD)
					.WithMany(dm => dm.BenhAnKKBYHHDs)
					.HasForeignKey(fk => fk.MaBenhKkbyhhd)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhChinhVV)
					.WithMany(dm => dm.BenhAnBenhChinhVVs)
					.HasForeignKey(fk => fk.MaBenhChinhVv)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemVV1)
					.WithMany(dm => dm.BenhAnBenhKemVV1s)
					.HasForeignKey(fk => fk.MaBenhKemVv1)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemVV2)
					.WithMany(dm => dm.BenhAnBenhKemVV2s)
					.HasForeignKey(fk => fk.MaBenhKemVv2)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemVV3)
					.WithMany(dm => dm.BenhAnBenhKemVV3s)
					.HasForeignKey(fk => fk.MaBenhKemVv3)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhChinhRV)
					.WithMany(dm => dm.BenhBenhChinhRVs)
					.HasForeignKey(fk => fk.TenBenhChinhRv)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemRV1)
					.WithMany(dm => dm.BenhAnBenhKemRV1s)
					.HasForeignKey(fk => fk.MaBenhKemRv1)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemRV2)
					.WithMany(dm => dm.BenhAnBenhKemRV2s)
					.HasForeignKey(fk => fk.MaBenhKemRv2)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemRV3)
					.WithMany(dm => dm.BenhAnBenhKemRV3s)
					.HasForeignKey(fk => fk.MaBenhKemRv3)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhNoiChuyenDenYHCT)
					.WithMany(dm => dm.BenhNoiChuyenDenYHCTs)
					.HasForeignKey(fk => fk.MaBenhNoiChuyenDenYhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKKBYHCT)
					.WithMany(dm => dm.BenhKKBYHCTs)
					.HasForeignKey(fk => fk.MaBenhKkbyhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhChinhVVYHCT)
					.WithMany(dm => dm.BenhChinhVVYHCTs)
					.HasForeignKey(fk => fk.MaBenhChinhVvyhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemVV1YHCT)
					.WithMany(dm => dm.BenhKemVV1YHCTs)
					.HasForeignKey(fk => fk.MaBenhKemVv1yhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemVV2YHCT)
					.WithMany(dm => dm.BenhKemVV2YHCTs)
					.HasForeignKey(fk => fk.MaBenhKemVv2yhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemVV3YHCT)
					.WithMany(dm => dm.BenhKemVV3YHCTs)
					.HasForeignKey(fk => fk.MaBenhKemVv3yhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhChinhRVYHCT)
					.WithMany(dm => dm.BenhChinhRVYHCTs)
					.HasForeignKey(fk => fk.MaBenhChinhRvyhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemRV1YHCT)
					.WithMany(dm => dm.BenhKemRV1YHCTs)
					.HasForeignKey(fk => fk.MaBenhKemRv1yhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemRV2YHCT)
					.WithMany(dm => dm.BenhKemRV2YHCTs)
					.HasForeignKey(fk => fk.MaBenhKemRv2yhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBenhKemRV3YHCT)
					.WithMany(dm => dm.BenhKemRV3YHCTs)
					.HasForeignKey(fk => fk.MaBenhKemRv3yhct)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmbaLdtvong)
					.WithMany(dm => dm.BenhAns)
					.HasForeignKey(fk => fk.TinhTrangTuVong)
					.HasPrincipalKey(pk => pk.MaLdtvong);

				entity.HasOne(ba => ba.DmBenhGPTuThi)
					.WithMany(dm => dm.BenhGPTuThis)
					.HasForeignKey(fk => fk.MaBenhGptuThi)
					.HasPrincipalKey(pk => pk.MaBenh);

				entity.HasOne(ba => ba.DmBsDieutri)
					.WithMany(dm => dm.BenhAnBsDieuTris)
					.HasForeignKey(fk => fk.BsdieuTri)
					.HasPrincipalKey(pk => pk.MaNv);

				entity.HasOne(ba => ba.DmGiamdoc)
					.WithMany(dm => dm.BenhAnGiamdocs)
					.HasForeignKey(fk => fk.GiamDoc)
					.HasPrincipalKey(pk => pk.MaNv);

				entity.HasOne(ba => ba.DmTruongKhoa)
					.WithMany(dm => dm.BenhAnTruongKhoas)
					.HasForeignKey(fk => fk.TruongKhoa)
					.HasPrincipalKey(pk => pk.MaNv);

				entity.HasOne(ba => ba.DmNguoiLap)
					.WithMany(dm => dm.BenhAnNguoiLaps)
					.HasForeignKey(fk => fk.NguoiLap)
					.HasPrincipalKey(pk => pk.MaNv);

				entity.HasOne(ba => ba.DmNguoiHuy)
					.WithMany(dm => dm.BenhAnNguoiHuys)
					.HasForeignKey(fk => fk.NguoiHuy)
					.HasPrincipalKey(pk => pk.MaNv);

				entity.HasMany(b => b.BenhAnPhieuChamSocs)
					.WithOne(d => d.BenhAn)
					.HasForeignKey(fk => fk.Idba)
					.HasPrincipalKey(pk => pk.Idba);

				entity.HasMany(b => b.BenhAnKhoaDieuTris)
					.WithOne(d => d.BenhAn)
					.HasForeignKey(fk => fk.Idba)
					.HasPrincipalKey(pk => pk.Idba);

				entity.HasOne(b => b.BenhAnTvBbkiemDiem)
					.WithOne(d => d.BenhAn)
					.HasForeignKey<BenhAnTvBbkiemDiem>(fk => fk.Idba)
					.HasPrincipalKey<BenhAn>(pk => pk.Idba);

				entity.HasOne(b => b.BenhAnTvPhieuCdnguyenNhan)
					.WithOne(d => d.BenhAn)
					.HasForeignKey<BenhAnTvPhieuCdnguyenNhan>(fk => fk.Idba)
					.HasPrincipalKey<BenhAn>(pk => pk.Idba);

				entity.HasMany(b => b.BenhAnTvBbkiemDiemTvs)
					.WithOne(d => d.BenhAn)
					.HasForeignKey(fk => fk.Idba)
					.HasPrincipalKey(pk => pk.Idba);
			});

			modelBuilder.Entity<BenhAnClsKq>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt })
				   .HasName("PK_PhieuChupCHT_1");

				entity.ToTable("BenhAn_CLS_KQ");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BschuyenKhoa)
					.HasColumnName("BSChuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.CoDiVatKimLoai).HasMaxLength(250);

				entity.Property(e => e.DiUng).HasMaxLength(250);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.IdpacsLis)
					.HasColumnName("IDPACS_LIS")
					.HasMaxLength(50);

				entity.Property(e => e.KetLuan).HasMaxLength(500);

				entity.Property(e => e.KqcdhadaCo)
					.HasColumnName("KQCDHADaCo")
					.HasMaxLength(250);

				entity.Property(e => e.KyThuat).HasMaxLength(250);

				entity.Property(e => e.LinkPacsLis)
					.HasColumnName("LinkPACS_LIS")
					.HasMaxLength(250);

				entity.Property(e => e.LoiDan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoaThucHien).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaMayThucHien).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKq)
					.HasColumnName("NgayKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTiepNhan).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoPhieu)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Sttdv).HasColumnName("STTDV");

				entity.Property(e => e.TinhTrangNguoiBenh).HasMaxLength(250);

				entity.Property(e => e.ViTri).HasMaxLength(250);

				entity.HasOne(b => b.DmBschuyenKhoa)
					.WithMany(d => d.BenhAnClsKqs)
					.HasForeignKey(b => b.BschuyenKhoa)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhAnClsKqHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnClsKqNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnClsKqSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhAnFilePhiCauTruc>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_FilePhiCauTruc");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sttdv).HasColumnName("STTDV");

				entity.Property(e => e.TaiLiieuDinhKem).HasMaxLength(500);

				entity.Property(e => e.Loai);

				entity.HasOne(b => b.DmNguoiSD)
				  .WithMany(d => d.BenhAnFilePhiCauTrucNguoiSDs)
				  .HasForeignKey(b => b.NguoiSd)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
					.WithMany(d => d.BenhAnFilePhiCauTrucNguoiLaps)
					.HasForeignKey(b => b.NguoiLap)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
				  .WithMany(d => d.BenhAnFilePhiCauTrucNguoiHuys)
				  .HasForeignKey(b => b.NguoiHuy)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmbaLoaiTaiLieu)
				  .WithMany(d => d.BenhAnFilePhiCauTrucs)
				  .HasForeignKey(b => b.LoaiTaiLieu)
				  .HasPrincipalKey(d => d.MaLoaiTaiLieu);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
				  .WithMany(d => d.BenhAnFilePhiCauTrucs)
				  .HasForeignKey(b => new { b.Idba, b.Sttdv })
				  .HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.BenhanCls)
				  .WithMany(d => d.BenhAnFilePhiCauTrucs)
				  .HasForeignKey(b => new { b.Idba, b.Sttdv })
				  .HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.BenhanTtvltl)
				  .WithMany(d => d.BenhAnFilePhiCauTrucs)
				  .HasForeignKey(b => new { b.Idba, b.Sttdv })
				  .HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.BenhanPhauThuat)
				  .WithMany(d => d.BenhAnFilePhiCauTrucs)
				  .HasForeignKey(b => new { b.Idba, b.Sttdv })
				  .HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.BenhanCpm)
				  .WithMany(d => d.BenhAnFilePhiCauTrucs)
				  .HasForeignKey(b => new { b.Idba, b.Sttdv })
				  .HasPrincipalKey(d => new { d.Idba, d.Stt });
			});

			modelBuilder.Entity<BenhAnGiayChuyenTuyen>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("BenhAn_GiayChuyenTuyen");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.ChanDoan).HasMaxLength(50);

				entity.Property(e => e.DauHieuLamSang).HasMaxLength(500);

				entity.Property(e => e.DiaChi).HasMaxLength(500);

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.Kqxn).HasColumnName("KQXN");

				entity.Property(e => e.LanhDao).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa1).HasMaxLength(50);

				entity.Property(e => e.MaKhoa1Dn)
					.HasColumnName("MaKhoa1_DN")
					.HasColumnType("datetime");

				entity.Property(e => e.MaKhoa1Tn)
					.HasColumnName("MaKhoa1_TN")
					.HasColumnType("datetime");

				entity.Property(e => e.MaKhoa1TuyenKhoa)
					.HasColumnName("MaKhoa1_TuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa2).HasMaxLength(50);

				entity.Property(e => e.MaKhoa2Dn)
					.HasColumnName("MaKhoa2_DN")
					.HasColumnType("datetime");

				entity.Property(e => e.MaKhoa2Tn)
					.HasColumnName("MaKhoa2_TN")
					.HasColumnType("datetime");

				entity.Property(e => e.MaKhoa2TuyenKhoa)
					.HasColumnName("MaKhoa2_TuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNoiChuyenDen).HasMaxLength(50);

				entity.Property(e => e.NgayChuyen).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHoTong).HasMaxLength(300);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.PhuongTien).HasMaxLength(150);

				entity.Property(e => e.SoPhieu).HasMaxLength(50);

				entity.Property(e => e.SoSoChuyenTuyen).HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TinhTrangBn)
					.HasColumnName("TinhTrangBN")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<BenhAnHoiChan>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_HoiChan");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.ChuToa).HasMaxLength(50);

				entity.Property(e => e.HuongDt)
					.HasColumnName("HuongDT")
					.HasMaxLength(500);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.KetLuan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHoiChan).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TenBienBanHoiChan).HasMaxLength(250);

				entity.Property(e => e.ThanhVien).HasMaxLength(500);

				entity.Property(e => e.ThuKy).HasMaxLength(50);

				entity.Property(e => e.TomTatDienBienBenh).HasMaxLength(500);

				entity.HasOne(b => b.DmChuToa)
				  .WithMany(d => d.BenhAnHoiChanChuToas)
				  .HasForeignKey(b => b.ChuToa)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmThuKy)
				  .WithMany(d => d.BenhAnHoiChanThuKys)
				  .HasForeignKey(b => b.ThuKy)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				  .WithMany(d => d.BenhAnHoiChanNguoiSDs)
				  .HasForeignKey(b => b.NguoiSd)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
					.WithMany(d => d.BenhAnHoiChanNguoiLaps)
					.HasForeignKey(b => b.NguoiLap)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
				  .WithMany(d => d.BenhAnHoiChanNguoiHuys)
				  .HasForeignKey(b => b.NguoiHuy)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
				  .WithMany(d => d.BenhAnHoiChans)
				  .HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
				  .HasPrincipalKey(pk => new { pk.Idba, pk.Stt });
			});

			modelBuilder.Entity<BenhAnKhamBenhYhct>(entity =>
			{
				entity.HasKey(e => e.Idba);

				entity.ToTable("BenhAn_KhamBenhYHCT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BatCuong).HasMaxLength(250);

				entity.Property(e => e.BhbatCuong)
					.HasColumnName("BHBatCuong")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhAn)
					.HasColumnName("BHBenhAn")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhBung)
					.HasColumnName("BHBenhBung")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhBungXucChan)
					.HasColumnName("BHBenhBungXucChan")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhChanTay)
					.HasColumnName("BHBenhChanTay")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhCoXuongKhop)
					.HasColumnName("BHBenhCoXuongKhop")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhDaiTien)
					.HasColumnName("BHBenhDaiTien")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhDauMatCo)
					.HasColumnName("BHBenhDauMatCo")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhDoiHa)
					.HasColumnName("BHBenhDoiHa")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhHanNhiet)
					.HasColumnName("BHBenhHanNhiet")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhLung)
					.HasColumnName("BHBenhLung")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhMoHoi)
					.HasColumnName("BHBenhMoHoi")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhNgu)
					.HasColumnName("BHBenhNgu")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhNguc)
					.HasColumnName("BHBenhNguc")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhSdssnam)
					.HasColumnName("BHBenhSDSSNam")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhSdssnu)
					.HasColumnName("BHBenhSDSSnu")
					.HasMaxLength(50);

				entity.Property(e => e.BhbenhTieuTien)
					.HasColumnName("BHBenhTieuTien")
					.HasMaxLength(50);

				entity.Property(e => e.BienChungLuanTri).HasMaxLength(250);

				entity.Property(e => e.ChatLuoi).HasMaxLength(50);

				entity.Property(e => e.ChatThaiBhbenh)
					.HasColumnName("ChatThaiBHBenh")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhAn)
					.HasColumnName("CoBHBenhAn")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhBung)
					.HasColumnName("CoBHBenhBung")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhBungXucChan)
					.HasColumnName("CoBHBenhBungXucChan")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhChanTay)
					.HasColumnName("CoBHBenhChanTay")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhCoXuongKhop)
					.HasColumnName("CoBHBenhCoXuongKhop")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhDoiHa)
					.HasColumnName("CoBHBenhDoiHa")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhDtt)
					.HasColumnName("CoBHBenhDTT")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhHanNhiet)
					.HasColumnName("CoBHBenhHanNhiet")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhKinhNguyet)
					.HasColumnName("CoBHBenhKinhNguyet")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhLung)
					.HasColumnName("CoBHBenhLung")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhMoiHoi)
					.HasColumnName("CoBHBenhMoiHoi")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhNgu)
					.HasColumnName("CoBHBenhNgu")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhNguc)
					.HasColumnName("CoBHBenhNguc")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhSdss)
					.HasColumnName("CoBHBenhSDSS")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhUong)
					.HasColumnName("CoBHBenhUong")
					.HasMaxLength(50);

				entity.Property(e => e.CoBhbenhXucChan)
					.HasColumnName("CoBHBenhXucChan")
					.HasMaxLength(50);

				entity.Property(e => e.CoHo).HasMaxLength(50);

				entity.Property(e => e.CoVai).HasMaxLength(50);

				entity.Property(e => e.DaXucChan).HasMaxLength(50);

				entity.Property(e => e.DauDau).HasMaxLength(50);

				entity.Property(e => e.DinhViBenhTheo).HasMaxLength(50);

				entity.Property(e => e.DtdonThuanYhct).HasColumnName("DTDonThuanYHCT");

				entity.Property(e => e.DuongChiTay).HasMaxLength(50);

				entity.Property(e => e.HinhDangChiTay).HasMaxLength(50);

				entity.Property(e => e.HinhThaiLuoi).HasMaxLength(50);

				entity.Property(e => e.HinhThaiVongChan).HasMaxLength(50);

				entity.Property(e => e.HoaMat).HasMaxLength(50);

				entity.Property(e => e.HoiTho).HasMaxLength(50);

				entity.Property(e => e.Hong).HasMaxLength(50);

				entity.Property(e => e.KinhMach).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhDanhTheoYhct)
					.HasColumnName("MaBenhDanhTheoYHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaTongKhanPhai).HasMaxLength(50);

				entity.Property(e => e.MaTongKhanTrai).HasMaxLength(50);

				entity.Property(e => e.MachChan).HasMaxLength(50);

				entity.Property(e => e.MachPhai).HasMaxLength(250);

				entity.Property(e => e.MachTrai).HasMaxLength(250);

				entity.Property(e => e.Mat).HasMaxLength(50);

				entity.Property(e => e.MauSacChiTay).HasMaxLength(50);

				entity.Property(e => e.MoHoi).HasMaxLength(50);

				entity.Property(e => e.MoTaKhacThietChan).HasMaxLength(250);

				entity.Property(e => e.MoTaKhacVaanChan).HasMaxLength(250);

				entity.Property(e => e.MoTaKhacVanChan).HasMaxLength(250);

				entity.Property(e => e.MoTaKhacVongChan).HasMaxLength(250);

				entity.Property(e => e.MoTaXucChan).HasMaxLength(250);

				entity.Property(e => e.Mui).HasMaxLength(50);

				entity.Property(e => e.MuiCoThe).HasMaxLength(50);

				entity.Property(e => e.Nac).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguyenNhanChanDoan).HasMaxLength(50);

				entity.Property(e => e.O).HasMaxLength(50);

				entity.Property(e => e.PhuongDuoc).HasMaxLength(500);

				entity.Property(e => e.PhuongHuyet).HasMaxLength(500);

				entity.Property(e => e.PpdtkhongDungThuoc)
					.HasColumnName("PPDTKhongDungThuoc")
					.HasMaxLength(500);

				entity.Property(e => e.Ppdtyhct)
					.HasColumnName("PPDTYHCT")
					.HasMaxLength(500);

				entity.Property(e => e.Ppkhac)
					.HasColumnName("PPKhac")
					.HasMaxLength(500);

				entity.Property(e => e.QuanPhai).HasMaxLength(50);

				entity.Property(e => e.QuanTrai).HasMaxLength(50);

				entity.Property(e => e.ReuLuoi).HasMaxLength(50);

				entity.Property(e => e.RoiLoanKinhNguyet).HasMaxLength(50);

				entity.Property(e => e.SacVongChan).HasMaxLength(50);

				entity.Property(e => e.Tai).HasMaxLength(50);

				entity.Property(e => e.TangPhu).HasMaxLength(50);

				entity.Property(e => e.ThanVongChan).HasMaxLength(50);

				entity.Property(e => e.ThichUong).HasMaxLength(50);

				entity.Property(e => e.ThonPhai).HasMaxLength(50);

				entity.Property(e => e.ThonTrai).HasMaxLength(50);

				entity.Property(e => e.ThongKinh).HasMaxLength(50);

				entity.Property(e => e.Thop).HasMaxLength(50);

				entity.Property(e => e.TiengNoi).HasMaxLength(50);

				entity.Property(e => e.TinhChatChiTay).HasMaxLength(50);

				entity.Property(e => e.TinhTrangHo).HasMaxLength(50);

				entity.Property(e => e.TomTatTuChan).HasMaxLength(250);

				entity.Property(e => e.TongKhanPhai).HasMaxLength(50);

				entity.Property(e => e.TongKhanTrai).HasMaxLength(50);

				entity.Property(e => e.TrachVongChan).HasMaxLength(50);

				entity.Property(e => e.XichPhai).HasMaxLength(50);

				entity.Property(e => e.XichTrai).HasMaxLength(50);

				entity.Property(e => e.XoaBopBamHuyet).HasMaxLength(500);

				entity.Property(e => e.YeuToXuatHienBenh).HasMaxLength(50);
			});

			modelBuilder.Entity<BenhAnKhamBenhYhhd>(entity =>
			{
				entity.HasKey(e => e.Idba);

				entity.ToTable("BenhAn_KhamBenhYHHD");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Bmi)
					.HasColumnName("BMI")
					.HasColumnType("numeric(10, 3)");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.CanLamSang).HasMaxLength(250);

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CdchamSoc)
					.HasColumnName("CDChamSoc")
					.HasMaxLength(50);

				entity.Property(e => e.CddinhDuong)
					.HasColumnName("CDDinhDuong")
					.HasMaxLength(50);

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.ChuyenKhoaKhac).HasMaxLength(250);

				entity.Property(e => e.CoXuongKhop).HasMaxLength(250);

				entity.Property(e => e.DtketHopYhhd).HasColumnName("DTKetHopYHHD");

				entity.Property(e => e.HoHap).HasMaxLength(250);

				entity.Property(e => e.HuongDtyhhd)
					.HasColumnName("HuongDTYHHD")
					.HasMaxLength(500);

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.KhamToanThan).HasMaxLength(500);

				entity.Property(e => e.Kqcdha)
					.HasColumnName("KQCDHA")
					.HasMaxLength(500);

				entity.Property(e => e.Kqdt)
					.HasColumnName("KQDT")
					.HasMaxLength(500);

				entity.Property(e => e.Kqxnmau)
					.HasColumnName("KQXNMau")
					.HasMaxLength(500);

				entity.Property(e => e.KqxnnuocTieu)
					.HasColumnName("KQXNNuocTieu")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaCdbenhPhanBiet)
					.HasColumnName("MaCDBenhPhanBiet")
					.HasMaxLength(500);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.Mat).HasMaxLength(250);

				entity.Property(e => e.NgayHenKhamLai).HasColumnType("datetime");

				entity.Property(e => e.NgayHenXnlai)
					.HasColumnName("NgayHenXNLai")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKyDt)
					.HasColumnName("NgayKyDT")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhietDo).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.NoiTietDd)
					.HasColumnName("NoiTietDD")
					.HasMaxLength(250);

				entity.Property(e => e.Ppdtyhhd)
					.HasColumnName("PPDTYHHD")
					.HasMaxLength(500);

				entity.Property(e => e.RangHamMat).HasMaxLength(250);

				entity.Property(e => e.SpO2).HasMaxLength(50);

				entity.Property(e => e.TaiMuiHong).HasMaxLength(250);

				entity.Property(e => e.ThanKinh).HasMaxLength(250);

				entity.Property(e => e.TienLuong).HasMaxLength(500);

				entity.Property(e => e.TietNieu).HasMaxLength(250);

				entity.Property(e => e.TieuHoa).HasMaxLength(250);

				entity.Property(e => e.TinhTrangDau).HasMaxLength(250);

				entity.Property(e => e.TomTatBenhAn).HasMaxLength(500);

				entity.Property(e => e.TuanHoan).HasMaxLength(250);

				entity.Property(e => e.VongDau).HasMaxLength(50);
			});

			modelBuilder.Entity<BenhAnKhamSangLocDd>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt, e.Sttkhoa })
				   .HasName("PK_BenhAn_PhieuSangLocDD_1");

				entity.ToTable("BenhAn_KhamSangLocDD");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.Bmi)
					.HasColumnName("BMI")
					.HasColumnType("numeric(10, 3)");

				entity.Property(e => e.Bsdieutri)
					.HasColumnName("BSDieutri")
					.HasMaxLength(50);

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CanThiepDd)
					.HasColumnName("CanThiepDD")
					.HasMaxLength(500);

				entity.Property(e => e.ChiSoMst).HasColumnName("ChiSoMST");

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.DanhGiaTheoMst)
					.HasColumnName("DanhGiaTheoMST")
					.HasMaxLength(250);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayDg)
					.HasColumnName("NgayDG")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiDg)
					.HasColumnName("NguoiDG")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoPhieu)
					.IsRequired()
					.HasMaxLength(50);

				entity.HasOne(b => b.DmNguoiDg)
					.WithMany(d => d.BenhAnKhamSangLocDdNguoiDgs)
					.HasForeignKey(b => b.NguoiDg)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsdieuTri)
					.WithMany(d => d.BenhAnKhamSangLocDdBsdieuTris)
					.HasForeignKey(b => b.Bsdieutri)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				.WithMany(d => d.BenhAnKhamSangLocDdNguoiSDs)
				.HasForeignKey(b => b.NguoiSd)
				.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
					  .WithMany(d => d.BenhAnKhamSangLocDdNguoiLaps)
					  .HasForeignKey(b => b.NguoiLap)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhAnKhamSangLocDdNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhAnKhamSangLocDds)
					.HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
					.HasPrincipalKey(pk => new { pk.Idba, pk.Stt });
			});

			modelBuilder.Entity<BenhAnKhamVaoVien>(entity =>
		   {
			   entity.HasKey(e => e.Idba)
					.HasName("PK_PhieuKhamVaoVien1");

			   entity.ToTable("BenhAn_KhamVaoVien");

			   entity.Property(e => e.Idba)
				   .HasColumnName("IDBA")
				   .HasColumnType("numeric(38, 0)");

			   entity.Property(e => e.Bskham)
				   .HasColumnName("BSKham")
				   .HasMaxLength(50);

			   entity.Property(e => e.CacBoPhan).HasMaxLength(500);

			   entity.Property(e => e.ChanDoanKkb)
				   .HasColumnName("ChanDoanKKB")
				   .HasMaxLength(500);

			   entity.Property(e => e.ChuY).HasMaxLength(250);

			   entity.Property(e => e.DaXuLy).HasMaxLength(50);

			   entity.Property(e => e.DoiTuong).HasMaxLength(50);

			   entity.Property(e => e.Gtbhytdn)
				   .HasColumnName("GTBHYTDN")
				   .HasColumnType("datetime");

			   entity.Property(e => e.Gtbhyttn)
				   .HasColumnName("GTBHYTTN")
				   .HasColumnType("datetime");

			   entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

			   entity.Property(e => e.HuyetAp).HasMaxLength(50);

			   entity.Property(e => e.KhamToanThan).HasMaxLength(500);

			   entity.Property(e => e.LyDoVv)
				   .HasColumnName("LyDoVV")
				   .HasMaxLength(250);

			   entity.Property(e => e.MaBa)
				   .HasColumnName("MaBA")
				   .HasMaxLength(50);

			   entity.Property(e => e.MaBenhNoiChuyenDen).HasMaxLength(50);

			   entity.Property(e => e.MaBn)
				   .HasColumnName("MaBN")
				   .HasMaxLength(50);

			   entity.Property(e => e.MaKhoaKham).HasMaxLength(50);

			   entity.Property(e => e.MaKhoaVv)
				   .HasColumnName("MaKhoaVV")
				   .HasMaxLength(50);

			   entity.Property(e => e.MaMay).HasMaxLength(20);

			   entity.Property(e => e.NgayHuy).HasColumnType("datetime");

			   entity.Property(e => e.NgayKham).HasColumnType("datetime");

			   entity.Property(e => e.NgayKy).HasColumnType("datetime");

			   entity.Property(e => e.NgayLap).HasColumnType("datetime");

			   entity.Property(e => e.NgaySd)
				   .HasColumnName("NgaySD")
				   .HasColumnType("datetime");

			   entity.Property(e => e.NguoiHuy).HasMaxLength(50);

			   entity.Property(e => e.NguoiLap).HasMaxLength(50);

			   entity.Property(e => e.NguoiSd)
				   .HasColumnName("NguoiSD")
				   .HasMaxLength(50);

			   entity.Property(e => e.NhietDo).HasColumnType("numeric(5, 2)");

			   entity.Property(e => e.QuaTrinhBenhLy).HasMaxLength(1000);

			   entity.Property(e => e.SoTheBhyt)
				   .HasColumnName("SoTheBHYT")
				   .HasMaxLength(15);

			   entity.Property(e => e.TienSuBanThan).HasMaxLength(500);

			   entity.Property(e => e.TienSuGiaDinh).HasMaxLength(500);

			   entity.Property(e => e.TomTatKqcls)
				   .HasColumnName("TomTatKQCLS")
				   .HasMaxLength(1000);

			   entity.HasOne(ba => ba.Dmkhoa)
				   .WithMany(k => k.BenhAnKhamVaoViens)
				   .HasForeignKey(fk => fk.MaKhoaVv)
				   .HasPrincipalKey(pk => pk.MaKhoa);

			   entity.HasOne(ba => ba.DmBsKham)
					.WithMany(dm => dm.BenhAnKhamVaoVienBsKhams)
					.HasForeignKey(fk => fk.Bskham)
					.HasPrincipalKey(pk => pk.MaNv);

			   entity.HasOne(b => b.ThongTinBn)
					.WithMany(d => d.BenhAnKhamVaoViens)
					.HasForeignKey(b => b.MaBn)
					.HasPrincipalKey(d => d.MaBn);

			   entity.HasOne(b => b.BenhAn)
					.WithMany(d => d.BenhAnKhamVaoViens)
					.HasForeignKey(b => b.MaBa)
					.HasPrincipalKey(d => d.MaBa);

			   entity.HasOne(bn => bn.DmDoiTuong)
					.WithMany(d => d.BenhAnKhamVaoViens)
					.HasForeignKey(fk => fk.DoiTuong)
					.HasPrincipalKey(pk => pk.MaDt);

			   entity.HasOne(bn => bn.DmChanDoanKkb)
					.WithMany(d => d.ChanDoanKkbs)
					.HasForeignKey(fk => fk.ChanDoanKkb)
					.HasPrincipalKey(pk => pk.MaBenh);

			   entity.HasOne(bn => bn.DmBenhNoiChuyenDen)
					.WithMany(d => d.BenhNoiChuyenDens)
					.HasForeignKey(fk => fk.MaBenhNoiChuyenDen)
					.HasPrincipalKey(pk => pk.MaBenh);

               entity.HasOne(ba => ba.DmKhoaKham)
				   .WithMany(kb => kb.BenhAnKhamVaoVienKhoaKhams)
				   .HasForeignKey(fk => fk.MaKhoaKham)
				   .HasPrincipalKey(pk => pk.MaKhoa );
           });

			modelBuilder.Entity<BenhAnKhamYhct>(entity =>
			{
				entity.HasKey(e => e.Idba)
									.HasName("PK_BenhAn_KhamBenhYHCT1");

				entity.ToTable("BenhAn_KhamYHCT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.An).HasMaxLength(150);

				entity.Property(e => e.Bhan).HasColumnName("BHAn");

				entity.Property(e => e.BhbatCuong)
					.HasColumnName("BHBatCuong")
					.HasMaxLength(200);

				entity.Property(e => e.Bhbung).HasColumnName("BHBung");

				entity.Property(e => e.BhbungXucChan).HasColumnName("BHBungXucChan");

				entity.Property(e => e.BhchanTay).HasColumnName("BHChanTay");

				entity.Property(e => e.BhcoXuongKhop).HasColumnName("BHCoXuongKhop");

				entity.Property(e => e.BhdaiTieuTien).HasColumnName("BHDaiTieuTien");

				entity.Property(e => e.BhdauMatCo).HasColumnName("BHDauMatCo");

				entity.Property(e => e.BhdoiHa).HasColumnName("BHDoiHa");

				entity.Property(e => e.BhhanNhiet).HasColumnName("BHHanNhiet");

				entity.Property(e => e.Bhkn).HasColumnName("BHKN");

				entity.Property(e => e.Bhlung).HasColumnName("BHLung");

				entity.Property(e => e.BhmoHoi).HasColumnName("BHMoHoi");

				entity.Property(e => e.Bhngu).HasColumnName("BHNgu");

				entity.Property(e => e.Bhnguc).HasColumnName("BHNguc");

				entity.Property(e => e.Bhuong).HasColumnName("BHUong");

				entity.Property(e => e.BhxucChan).HasColumnName("BHXucChan");

				entity.Property(e => e.Bung).HasMaxLength(150);

				entity.Property(e => e.ChanTay).HasMaxLength(150);

				entity.Property(e => e.ChatLuoi).HasMaxLength(150);

				entity.Property(e => e.CoVai).HasMaxLength(150);

				entity.Property(e => e.DaiTien).HasMaxLength(150);

				entity.Property(e => e.DauDau).HasMaxLength(150);

				entity.Property(e => e.Dkxhbenh).HasColumnName("DKXHBenh");

				entity.Property(e => e.DoiHa).HasMaxLength(150);

				entity.Property(e => e.DtdonThuanYhct).HasColumnName("DTDonThuanYHCT");

				entity.Property(e => e.GiongNoi).HasMaxLength(150);

				entity.Property(e => e.Hannhiet).HasMaxLength(150);

				entity.Property(e => e.HinhThaiLuoi).HasMaxLength(150);

				entity.Property(e => e.HinhThaiVongChan).HasMaxLength(150);

				entity.Property(e => e.Ho).HasMaxLength(150);

				entity.Property(e => e.HoiTho).HasMaxLength(150);

				entity.Property(e => e.Hong).HasMaxLength(150);

				entity.Property(e => e.KieuChatThai).HasMaxLength(150);

				entity.Property(e => e.KieuMui).HasMaxLength(150);

				entity.Property(e => e.KinhMach).HasMaxLength(150);

				entity.Property(e => e.Lung).HasMaxLength(150);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhDanhTheoYhct)
					.HasColumnName("MaBenhDanhTheoYHCT")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MachChan).HasMaxLength(150);

				entity.Property(e => e.MachPhai).HasMaxLength(150);

				entity.Property(e => e.MachTrai).HasMaxLength(150);

				entity.Property(e => e.Mat).HasMaxLength(150);

				entity.Property(e => e.MoHoi).HasMaxLength(150);

				entity.Property(e => e.MtthietChan).HasColumnName("MTThietChan");

				entity.Property(e => e.MtvaanChan).HasColumnName("MTVaanChan");

				entity.Property(e => e.Mui).HasMaxLength(150);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.Ngu).HasMaxLength(150);

				entity.Property(e => e.Nguc).HasMaxLength(150);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguyenNhan).HasMaxLength(200);

				entity.Property(e => e.OamThanh).HasColumnName("OAmThanh");

				entity.Property(e => e.PpdtkhongDungThuoc).HasColumnName("PPDTKhongDungThuoc");

				entity.Property(e => e.Ppdtyhct).HasColumnName("PPDTYHCT");

				entity.Property(e => e.Ppkhac).HasColumnName("PPKhac");

				entity.Property(e => e.ReuLuoi).HasMaxLength(150);

				entity.Property(e => e.Rlkinhnguyet)
					.HasColumnName("RLKinhnguyet")
					.HasMaxLength(150);

				entity.Property(e => e.RlknsinhDuc).HasColumnName("RLKNSinhDuc");

				entity.Property(e => e.Rlnam)
					.HasColumnName("RLNam")
					.HasMaxLength(150);

				entity.Property(e => e.Rlnu)
					.HasColumnName("RLNu")
					.HasMaxLength(150);

				entity.Property(e => e.SacVongChan).HasMaxLength(150);

				entity.Property(e => e.Tai).HasMaxLength(150);

				entity.Property(e => e.TangPhu).HasMaxLength(150);

				entity.Property(e => e.ThanVongChan).HasMaxLength(150);

				entity.Property(e => e.ThongKinh).HasMaxLength(150);

				entity.Property(e => e.TieuTien).HasMaxLength(150);

				entity.Property(e => e.TongKhanPhai).HasMaxLength(150);

				entity.Property(e => e.TongKhanTrai).HasMaxLength(150);

				entity.Property(e => e.TrachVongChan).HasMaxLength(150);

				entity.Property(e => e.Uong).HasMaxLength(150);

				entity.Property(e => e.ViKhanPhaiQuan).HasMaxLength(150);

				entity.Property(e => e.ViKhanPhaiThon).HasMaxLength(150);

				entity.Property(e => e.ViKhanPhaiXich).HasMaxLength(150);

				entity.Property(e => e.ViKhanTraiQuan).HasMaxLength(150);

				entity.Property(e => e.ViKhanTraiThon).HasMaxLength(150);

				entity.Property(e => e.ViKhanTraiXich).HasMaxLength(150);

				entity.Property(e => e.XucChanBung)
					.HasColumnName("XucChan_bung")
					.HasMaxLength(150);

				entity.Property(e => e.XucChanCoXuongKhop)
					.HasColumnName("XucChan_CoXuongKhop")
					.HasMaxLength(150);

				entity.Property(e => e.XucChanDa)
					.HasColumnName("XucChan_da")
					.HasMaxLength(150);

				entity.Property(e => e.XucChanMoHoi)
					.HasColumnName("XucChan_MoHoi")
					.HasMaxLength(150);

				entity.HasOne(b => b.DmBenhDanhTheoYHCT)
					.WithMany(d => d.BenhAnKhamYhcts)
					.HasForeignKey(b => b.MaBenhDanhTheoYhct)
					.HasPrincipalKey(d => d.MaBenh);
			});

			modelBuilder.Entity<BenhAnKhamYhhd>(entity =>
			{
				entity.HasKey(e => e.Idba)
				   .HasName("PK_BenhAn_KhamBenhYHHD1");

				entity.ToTable("BenhAn_KhamYHHD");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BenhSu).HasMaxLength(500);

				entity.Property(e => e.Bmi)
					.HasColumnName("BMI")
					.HasColumnType("numeric(10, 3)");

				entity.Property(e => e.Bskham)
					.HasColumnName("BSKham")
					.HasMaxLength(50);

				entity.Property(e => e.CanLamSang).HasMaxLength(500);

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CdchamSoc)
					.HasColumnName("CDChamSoc")
					.HasMaxLength(50);

				entity.Property(e => e.CddinhDuong)
					.HasColumnName("CDDinhDuong")
					.HasMaxLength(50);

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.DtketHopYhhd).HasColumnName("DTKetHopYHHD");

				entity.Property(e => e.HoHap).HasMaxLength(300);

				entity.Property(e => e.HuongDtyhhd)
					.HasColumnName("HuongDTYHHD")
					.HasMaxLength(500);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.Kqcdha)
					.HasColumnName("KQCDHA")
					.HasMaxLength(500);

				entity.Property(e => e.Kqdt)
					.HasColumnName("KQDT")
					.HasMaxLength(500);

				entity.Property(e => e.Kqxnmau)
					.HasColumnName("KQXNMau")
					.HasMaxLength(500);

				entity.Property(e => e.KqxnnuocTieu)
					.HasColumnName("KQXNNuocTieu")
					.HasMaxLength(500);

				entity.Property(e => e.LyDoVv)
					.HasColumnName("LyDoVV")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.Mat).HasMaxLength(300);

				entity.Property(e => e.NgayHenKhamLai).HasColumnType("datetime");

				entity.Property(e => e.NgayHenXnlai)
					.HasColumnName("NgayHenXNLai")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKham).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhietDo).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.NoiTietDd)
					.HasColumnName("NoiTietDD")
					.HasMaxLength(300);

				entity.Property(e => e.Ppdtyhhd)
					.HasColumnName("PPDTYHHD")
					.HasMaxLength(1000);

				entity.Property(e => e.RangHamMat).HasMaxLength(300);

				entity.Property(e => e.SpO2).HasMaxLength(50);

				entity.Property(e => e.TaiMuiHong).HasMaxLength(300);

				entity.Property(e => e.TenBenhPhanBiet).HasMaxLength(500);

				entity.Property(e => e.ThanKinh).HasMaxLength(300);

				entity.Property(e => e.ThanTnieuSduc)
					.HasColumnName("ThanTNieuSDuc")
					.HasMaxLength(300);

				entity.Property(e => e.TienLuong).HasMaxLength(500);

				entity.Property(e => e.TieuHoa).HasMaxLength(300);

				entity.Property(e => e.ToanThan).HasMaxLength(500);

				entity.Property(e => e.TuanHoan).HasMaxLength(300);

				entity.Property(e => e.XuongKhop).HasMaxLength(300);

				entity.HasOne(ba => ba.DmBskham)
					.WithMany(dm => dm.BenhAnKhamYhhdBskhams)
					.HasForeignKey(fk => fk.Bskham)
					.HasPrincipalKey(pk => pk.MaNv);

                entity.HasOne(ba => ba.DmBenhPhanBiet)
					.WithMany(dm => dm.BenhAnKhamYhhds)
					.HasForeignKey(fk => fk.TenBenhPhanBiet)
					.HasPrincipalKey(pk => pk.MaBenh);
            });

			modelBuilder.Entity<BenhAnKhoaDieuTri>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_KhoaDieuTri");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BsdieuTri)
					// .IsRequired()
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.Buong).HasMaxLength(50);

				entity.Property(e => e.Giuong).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhChinhVk)
					.HasColumnName("MaBenhChinhVK")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVk1)
					.HasColumnName("MaBenhKemVK1")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVk2)
					.HasColumnName("MaBenhKemVK2")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenhKemVk3)
					.HasColumnName("MaBenhKemVK3")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayVaoKhoa).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoNgayDt).HasColumnName("SoNgayDT");

				entity.HasOne(b => b.BenhAn)
					.WithMany(d => d.BenhAnKhoaDieuTris)
					.HasForeignKey(b => b.MaBa)
					.HasPrincipalKey(d => d.MaBa);

				entity.HasOne(b => b.ThongTinBn)
					.WithMany(d => d.BenhAnKhoaDieuTris)
					.HasForeignKey(b => b.MaBn)
					.HasPrincipalKey(d => d.MaBn);

				entity.HasOne(b => b.Dmkhoa)
					.WithMany(d => d.BenhAnKhoaDieuTris)
					.HasForeignKey(b => b.MaKhoa)
					.HasPrincipalKey(d => d.MaKhoa);

				entity.HasOne(b => b.DmkhoaBuong)
					.WithMany(d => d.BenhAnKhoaDieuTris)
					.HasForeignKey(b => new { b.Buong, b.MaKhoa })
					.HasPrincipalKey(d => new { d.MaBuong, d.MaKhoa });

				entity.HasOne(b => b.DmkhoaGiuong)
					.WithMany(d => d.BenhAnKhoaDieuTris)
					.HasForeignKey(b => new { b.Giuong, b.Buong, b.MaKhoa })
					.HasPrincipalKey(d => new { d.MaGiuong, d.MaBuong, d.MaKhoa });

				entity.HasOne(b => b.BenhChinh)
					.WithMany(d => d.BenhAnKhoaDieuTris)
					.HasForeignKey(b => b.MaBenhChinhVk)
					.HasPrincipalKey(d => d.MaBenh);

				entity.HasOne(b => b.BenhKem1)
					.WithMany(d => d.BenhAnKhoaDieuTris1)
					.HasForeignKey(b => b.MaBenhKemVk1)
					.HasPrincipalKey(d => d.MaBenh);

				entity.HasOne(b => b.BenhKem2)
					.WithMany(d => d.BenhAnKhoaDieuTris2)
					.HasForeignKey(b => b.MaBenhKemVk2)
					.HasPrincipalKey(d => d.MaBenh);

				entity.HasOne(b => b.BenhKem3)
					.WithMany(d => d.BenhAnKhoaDieuTris3)
					.HasForeignKey(b => b.MaBenhKemVk3)
					.HasPrincipalKey(d => d.MaBenh);

				entity.HasOne(b => b.DmnhanVien)
					 .WithMany(d => d.BenhAnKhoaDieuTris)
					 .HasForeignKey(b => b.BsdieuTri)
					 .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhAnKhoaDieuTriNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnKhoaDieuTriNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnKhoaDieuTriNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

			});

			modelBuilder.Entity<BenhAnPhieuChamSoc>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_PhieuChamSoc");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CapCs).HasColumnName("CapCS");

				entity.Property(e => e.ChanDoan).HasMaxLength(250);

				entity.Property(e => e.ChanDoanChamSoc).HasMaxLength(200);

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.CoXuongKhop).HasMaxLength(50);

				entity.Property(e => e.DaNiemMac).HasMaxLength(50);

				entity.Property(e => e.DaiTien).HasMaxLength(50);

				entity.Property(e => e.DiUngMota)
					.HasColumnName("DiUng_Mota")
					.HasMaxLength(150);

				entity.Property(e => e.DienBien).HasMaxLength(250);

				entity.Property(e => e.DieuDuong).HasMaxLength(50);

				entity.Property(e => e.Gdsk)
					.HasColumnName("GDSK")
					.HasMaxLength(50);

				entity.Property(e => e.GioTruyenDichBd)
					.HasColumnName("GioTruyenDich_BD")
					.HasColumnType("datetime");

				entity.Property(e => e.GioTruyenDichKt)
					.HasColumnName("GioTruyenDich_KT")
					.HasColumnType("datetime");

				entity.Property(e => e.HoHap).HasMaxLength(50);

				entity.Property(e => e.HoHapDanLuu)
					.HasColumnName("HoHap_DanLuu")
					.HasMaxLength(10);

				entity.Property(e => e.HoHapSloxy).HasColumnName("HoHap_SLOXy");

				entity.Property(e => e.HoHapTchatDom)
					.HasColumnName("HoHap_TChatDom")
					.HasMaxLength(10);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.KhiDungTanSo).HasColumnName("KhiDung_TanSo");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa).HasMaxLength(50);

				entity.Property(e => e.MauSacTieuChay).HasMaxLength(150);

				entity.Property(e => e.NgayChamSoc).HasColumnType("datetime");

				entity.Property(e => e.NgayChamSocBd)
					.HasColumnName("NgayChamSoc_BD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayChamSocKt)
					.HasColumnName("NgayChamSoc_KT")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayChamSocLan)
					.HasColumnName("NgayChamSoc_Lan")
					.HasColumnType("numeric(5, 0)");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.Ngu).HasMaxLength(50);

				entity.Property(e => e.NguThoiGian).HasColumnName("Ngu_ThoiGian");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhanDinhKhac).HasMaxLength(500);

				entity.Property(e => e.NhietDo).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.Phu).HasMaxLength(50);

				entity.Property(e => e.PhuTinhChat)
					.HasColumnName("Phu_TinhChat")
					.HasMaxLength(150);

				entity.Property(e => e.PhuVitri)
					.HasColumnName("Phu_Vitri")
					.HasMaxLength(150);

				entity.Property(e => e.SpO2).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TamLyNguoiBenh).HasMaxLength(50);

				entity.Property(e => e.TamThanKinh).HasMaxLength(50);

				entity.Property(e => e.TamThanKinhKhac)
					.HasColumnName("TamThanKinh_Khac")
					.HasMaxLength(150);

				entity.Property(e => e.TestDhmmGio)
					.HasColumnName("TestDHMM_Gio")
					.HasColumnType("datetime");

				entity.Property(e => e.TestDhmmSoLan).HasColumnName("TestDHMM_SoLan");

				entity.Property(e => e.ThayBang).HasMaxLength(50);

				entity.Property(e => e.ThayBangViTriThay)
					.HasColumnName("ThayBang_ViTriThay")
					.HasMaxLength(150);

				entity.Property(e => e.TheTrang).HasMaxLength(50);

				entity.Property(e => e.TheoDoiDhst).HasColumnName("TheoDoiDHST");

				entity.Property(e => e.ThuThuatDy)
					.HasColumnName("ThuThuat_DY")
					.HasMaxLength(50);

				entity.Property(e => e.ThuThuatDyThuoc)
					.HasColumnName("ThuThuat_DY_Thuoc")
					.HasMaxLength(150);

				entity.Property(e => e.ThuThuatDyVltl)
					.HasColumnName("ThuThuat_DY_VLTL")
					.HasMaxLength(150);

				entity.Property(e => e.ThuThuatTayY).HasMaxLength(500);

				entity.Property(e => e.ThucHienYlenh)
					.HasColumnName("ThucHienYLenh")
					.HasMaxLength(500);

				entity.Property(e => e.ThucHienYlenhKhac)
					.HasColumnName("ThucHienYLenhKhac")
					.HasMaxLength(250);

				entity.Property(e => e.Thuoc).HasMaxLength(250);

				entity.Property(e => e.TienSuGiaDinh).HasMaxLength(50);

				entity.Property(e => e.TietNieu).HasMaxLength(50);

				entity.Property(e => e.TieuHoa).HasMaxLength(10);

				entity.Property(e => e.TieuHoaVitriDauBung)
					.HasColumnName("TieuHoa_VitriDauBung")
					.HasMaxLength(150);

				entity.Property(e => e.TieuTien).HasMaxLength(50);

				entity.Property(e => e.TieuTienMauSac)
					.HasColumnName("TieuTien_MauSac")
					.HasMaxLength(50);

				entity.Property(e => e.TieuTienSoLuong).HasColumnName("TieuTien_SoLuong");

				entity.Property(e => e.TuanHoan).HasMaxLength(50);

				entity.Property(e => e.TuanHoanTchatDauNguc)
					.HasColumnName("TuanHoan_TChatDauNguc")
					.HasMaxLength(150);

				entity.Property(e => e.VanDong).HasMaxLength(50);

				entity.Property(e => e.VanDongTchatLiet)
					.HasColumnName("VanDong_TChatLiet")
					.HasMaxLength(150);

				entity.Property(e => e.VeSinhCaNhan).HasMaxLength(50);

				entity.Property(e => e.VeSinhThanThe).HasMaxLength(50);

				entity.Property(e => e.VetThuong).HasMaxLength(50);

				entity.Property(e => e.VetThuongChanDanLuu)
					.HasColumnName("VetThuong_ChanDanLuu")
					.HasMaxLength(150);

				entity.Property(e => e.VetThuongDanLuu)
					.HasColumnName("VetThuong_DanLuu")
					.HasMaxLength(50);

				entity.Property(e => e.VetThuongKhac)
					.HasColumnName("VetThuong_Khac")
					.HasMaxLength(150);

				entity.Property(e => e.VetThuongMotaDanLuu)
					.HasColumnName("VetThuong_MotaDanLuu")
					.HasMaxLength(250);

				entity.Property(e => e.VetThuongViTri)
					.HasColumnName("VetThuong_ViTri")
					.HasMaxLength(150);

				entity.Property(e => e.XuTri).HasMaxLength(250);

				entity.Property(e => e.Ylenh)
					.HasColumnName("YLenh")
					.HasMaxLength(250);

				entity.Property(e => e.Ythuc)
					.HasColumnName("YThuc")
					.HasMaxLength(50);

				entity.HasOne(b => b.DmDieuDuong)
				  .WithMany(d => d.BenhAnPhieuChamSocDieuDuongs)
				  .HasForeignKey(b => b.DieuDuong)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhAnPhieuChamSocNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnPhieuChamSocNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnPhieuChamSocNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);
				entity.HasOne(b => b.Dmkhoa)
						.WithMany(d => d.BenhAnPhieuChamSocs)
						.HasForeignKey(b => b.MaKhoa)
						.HasPrincipalKey(d => d.MaKhoa);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhAnPhieuChamSocs)
					.HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
					.HasPrincipalKey(pk => new { pk.Idba, pk.Stt });
			});

			modelBuilder.Entity<BenhAnPhieuSangLocDd>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.LanDg });

				entity.ToTable("BenhAn_PhieuSangLocDD");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.LanDg).HasColumnName("LanDG");

				entity.Property(e => e.Bmi)
					.HasColumnName("BMI")
					.HasColumnType("numeric(18, 2)");

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CanThiepDd)
					.HasColumnName("CanThiepDD")
					.HasMaxLength(500);

				entity.Property(e => e.ChiSoMst)
					.HasColumnName("ChiSoMST")
					.HasColumnType("numeric(8, 2)");

				entity.Property(e => e.ChiSoNgonMieng).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.ChiSoSutCan).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.DanhGiaTheoMst)
					.HasColumnName("DanhGiaTheoMST")
					.HasMaxLength(250);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayDg)
					.HasColumnName("NgayDG")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiDg)
					.HasColumnName("NguoiDG")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<BenhAnPhacDoDt>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_PhacDoDT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.GiaiDoan).HasMaxLength(500);

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBenh).HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MoTa).HasMaxLength(500);

				entity.Property(e => e.NgayAdphacDo)
					.HasColumnName("NgayADPhacDo")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SauPhacDo).HasMaxLength(500);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TenBenh).HasMaxLength(500);

				entity.Property(e => e.TruocPhacDo).HasMaxLength(500);

				entity.Property(e => e.VungApDung).HasMaxLength(500);

				entity.Property(e => e.XuTri).HasMaxLength(500);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhAnPhacDoDts)
					.HasForeignKey(b => new { b.Idba, b.Sttkhoa })
					.HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhAnPhacDoDtNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnPhacDoDtNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnPhacDoDtNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhAnTaiBienPttt>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_TaiBienPTTT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.CachDung).HasMaxLength(500);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.GhiChu)
					.HasMaxLength(2000);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.KetQua).HasMaxLength(2000);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaPt)
					.HasColumnName("MaPT")
					.HasMaxLength(50);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.MaTt)
					.HasColumnName("MaTT")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTaiBien).HasColumnType("datetime");

				entity.Property(e => e.NgayThucHien).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguyenNhanTaiBien).HasMaxLength(2000);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TinhTrang).HasMaxLength(2000);

				entity.Property(e => e.Xutri).HasMaxLength(2000);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhAnTaiBienPttts)
					.HasForeignKey(b => new { b.Idba, b.Sttkhoa })
					.HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhAnTaiBienPtttNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnTaiBienPtttNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnTaiBienPtttNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhAnTheoDoiTruyenMau>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("BenhAn_TheoDoiTruyenMau");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BstheoDoi)
					.HasColumnName("BSTheoDoi")
					.HasMaxLength(50);

				entity.Property(e => e.DieuDuong).HasMaxLength(50);

				entity.Property(e => e.HanSd)
					.HasColumnName("HanSD")
					.HasColumnType("datetime");

				entity.Property(e => e.HoTenNguoiXn1)
					.HasColumnName("HoTenNguoiXN1")
					.HasMaxLength(150);

				entity.Property(e => e.HoTenNguoiXn2)
					.HasColumnName("HoTenNguoiXN2")
					.HasMaxLength(150);

				entity.Property(e => e.HoTenTruongKhoaXn)
					.HasColumnName("HoTenTruongKhoaXN")
					.HasMaxLength(150);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.KqpuhoaHop)
					.HasColumnName("KQPUHoaHop")
					.HasMaxLength(50);

				entity.Property(e => e.KqpuhoaHop37doOng1)
					.HasColumnName("KQPUHoaHop_37do_Ong1")
					.HasMaxLength(50);

				entity.Property(e => e.KqpuhoaHop37doOng2)
					.HasColumnName("KQPUHoaHop_37do_Ong2")
					.HasMaxLength(50);

				entity.Property(e => e.KqpuhoaHopMuoiOng1)
					.HasColumnName("KQPUHoaHop_Muoi_Ong1")
					.HasMaxLength(50);

				entity.Property(e => e.KqpuhoaHopMuoiOng2)
					.HasColumnName("KQPUHoaHop_Muoi_Ong2")
					.HasMaxLength(50);

				entity.Property(e => e.Kqxncheo)
					.HasColumnName("KQXNCheo")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaCpm)
					.HasColumnName("MaCPM")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaSoCmp)
					.HasColumnName("MaSoCMP")
					.HasMaxLength(50);

				entity.Property(e => e.NgayDieuChe).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayXnhoaHop)
					.HasColumnName("NgayXNHoaHop")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhanXet).HasMaxLength(250);

				entity.Property(e => e.NhomMau).HasMaxLength(50);

				entity.Property(e => e.NhomMauCpm)
					.HasColumnName("NhomMauCPM")
					.HasMaxLength(50);

				entity.Property(e => e.Rh).HasMaxLength(50);

				entity.Property(e => e.Sltruyen)
					.HasColumnName("SLTruyen")
					.HasColumnType("numeric(3, 0)");

				entity.Property(e => e.Sttcpm).HasColumnName("STTCPM");

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TenKqxnkhac)
					.HasColumnName("Ten_KQXNKhac")
					.HasMaxLength(150);

				entity.Property(e => e.TheTich).HasColumnType("numeric(3, 0)");

				entity.Property(e => e.ThoiGianBd)
					.HasColumnName("ThoiGianBD")
					.HasColumnType("datetime");

				entity.Property(e => e.ThoiGianKt)
					.HasColumnName("ThoiGianKT")
					.HasColumnType("datetime");

				entity.HasOne(b => b.BenhanCpm)
					.WithOne(d => d.BenhAnTheoDoiTruyenMau)
					.HasForeignKey<BenhanCpm>(b => new { b.Idba, b.Stt })
					.HasPrincipalKey<BenhAnTheoDoiTruyenMau>(d => new { d.Idba, d.Sttcpm });

				entity.HasOne(b => b.DmDieuDuong)
					.WithMany(d => d.BenhAnTheoDoiTruyenMauDieuDuongs)
					.HasForeignKey(b => b.DieuDuong)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsTheoDoi)
					.WithMany(d => d.BenhAnTheoDoiTruyenMauBsTheoDois)
					.HasForeignKey(b => b.BstheoDoi)
					.HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhAnTheodoiTruyenMauC>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_TheodoiTruyenMau_C");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.DienBienKhac).HasMaxLength(150);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MauSacDa).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhietDo).HasColumnType("numeric(3, 1)");

				entity.Property(e => e.StttruyenMau).HasColumnName("STTTruyenMau");

				entity.Property(e => e.ThoiGian).HasColumnType("datetime");

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhAnTheodoiTruyenMauCNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnTheodoiTruyenMauCNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnTheodoiTruyenMauCNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhAnThuocThuPhanUng>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba })
					.HasName("PK_ThuPhanUngThuoc1");

				entity.ToTable("BenhAn_Thuoc_ThuPhanUng");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.BsdocKq)
					.HasColumnName("BSDocKQ")
					.HasMaxLength(50);

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.KetQua).HasMaxLength(150);

				entity.Property(e => e.MaBa)
			.HasColumnName("MaBA")
			.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

				entity.Property(e => e.NgayDocKq)
					.HasColumnName("NgayDocKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiThu).HasMaxLength(50);

				entity.Property(e => e.PhuongPhapThu).HasMaxLength(500);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TenThuoc).HasMaxLength(500);

				entity.HasOne(b => b.DmNguoiThu)
			.WithMany(d => d.BenhAnThuocThuPhanUngNguoiThus)
			.HasForeignKey(b => b.NguoiThu)
			.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsdocKq)
			.WithMany(d => d.BenhAnThuocThuPhanUngBsdocKqs)
			.HasForeignKey(b => b.BsdocKq)
			.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBschiDinh)
			.WithMany(d => d.BenhAnThuocThuPhanUngBschiDinhs)
			.HasForeignKey(b => b.BschiDinh)
			.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
			  .WithMany(d => d.BenhAnThuocThuPhanUngNguoiLaps)
			  .HasForeignKey(b => b.NguoiLap)
			  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
			.WithMany(d => d.BenhAnThuocThuPhanUngNguoiHuys)
			.HasForeignKey(b => b.NguoiHuy)
			.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
			 .WithMany(d => d.BenhAnThuocThuPhanUngNguoiSDs)
			 .HasForeignKey(b => b.NguoiSd)
			 .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
			.WithMany(d => d.BenhAnThuocThuPhanUngs)
			.HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
			.HasPrincipalKey(pk => new { pk.Idba, pk.Stt });
			});

			modelBuilder.Entity<BenhAnTienSuBenh>(entity =>
			{
				entity.HasKey(e => e.Idba);

				entity.ToTable("BenhAn_TienSuBenh");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BenhDtd).HasColumnName("BenhDTD");

				entity.Property(e => e.BenhPhoiHopBenhLyKhac)
					.HasColumnName("BenhPhoiHop_BenhLyKhac")
					.HasMaxLength(500);

				entity.Property(e => e.BenhPhoiHopDtd).HasColumnName("BenhPhoiHop_DTD");

				entity.Property(e => e.BenhPhoiHopGout).HasColumnName("BenhPhoiHop_Gout");

				entity.Property(e => e.BenhPhoiHopKhopManTinh).HasColumnName("BenhPhoiHop_KhopManTinh");

				entity.Property(e => e.BenhPhoiHopMachVanh).HasColumnName("BenhPhoiHop_MachVanh");

				entity.Property(e => e.BenhPhoiHopNoiTietKhac).HasColumnName("BenhPhoiHop_NoiTietKhac");

				entity.Property(e => e.BenhPhoiHopRlchLipid).HasColumnName("BenhPhoiHop_RLCH Lipid");

				entity.Property(e => e.BenhPhoiHopTangHa).HasColumnName("BenhPhoiHop_TangHA");

				entity.Property(e => e.BenhPhoiHopThan).HasColumnName("BenhPhoiHop_Than");

				entity.Property(e => e.BenhTangHa).HasColumnName("BenhTangHA");

				entity.Property(e => e.ChiSoHamax)
					.HasColumnName("ChiSoHAMax")
					.HasMaxLength(50);

				entity.Property(e => e.DacDiemLienQuanBenh).HasMaxLength(50);

				entity.Property(e => e.DiUng).HasMaxLength(500);

				entity.Property(e => e.DieuTriDtdthuongXuyen)
					.HasColumnName("DieuTriDTDThuongXuyen")
					.HasMaxLength(500);

				entity.Property(e => e.DieuTriTangHathuongXuyen)
					.HasColumnName("DieuTriTangHAThuongXuyen")
					.HasMaxLength(500);

				entity.Property(e => e.DonDaTriLieuDtd)
					.HasColumnName("DonDaTriLieuDTD")
					.HasMaxLength(500);

				entity.Property(e => e.DonDaTriLieuHa)
					.HasColumnName("DonDaTriLieuHA")
					.HasMaxLength(500);

				entity.Property(e => e.Dtdmax)
					.HasColumnName("DTDMax")
					.HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.LoaiThuocDtd)
					.HasColumnName("LoaiThuocDTD")
					.HasMaxLength(500);

				entity.Property(e => e.LuongRuou).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaTienSu).HasMaxLength(50);

				entity.Property(e => e.MoTaTienSu).HasMaxLength(500);

				entity.Property(e => e.NamMacTmHaDtd).HasColumnName("NamMacTM_HA_DTD");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NoiDieuTriDtd)
					.HasColumnName("NoiDieuTriDTD")
					.HasMaxLength(500);

				entity.Property(e => e.NoiDieuTriTangHa)
					.HasColumnName("NoiDieuTriTangHA")
					.HasMaxLength(500);

				entity.Property(e => e.NuMacTmHaDtd).HasColumnName("NuMacTM_HA_DTD");

				entity.Property(e => e.SoBao).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.ThoiDiemPhatHienDtd)
					.HasColumnName("ThoiDiemPhatHienDTD")
					.HasMaxLength(500);

				entity.Property(e => e.ThoiDiemPhatHienTangHa)
					.HasColumnName("ThoiDiemPhatHienTangHA")
					.HasMaxLength(500);

				entity.Property(e => e.ThucHienCdanDtd).HasColumnName("ThucHienCDAnDTD");

				entity.Property(e => e.TienSuBanThan).HasMaxLength(500);

				entity.Property(e => e.TienSuGiaDinh).HasMaxLength(500);

				entity.Property(e => e.UongThuocDtd).HasColumnName("UongThuocDTD");

				entity.Property(e => e.YeuToNguyCoKhac).HasMaxLength(500);
			});

			modelBuilder.Entity<BenhAnToDieuTri>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("BenhAn_ToDieuTri");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Bmi)
					.HasColumnName("BMI")
					.HasColumnType("numeric(10, 3)");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CsduongHuyet)
					.HasColumnName("CSDuongHuyet")
					.HasMaxLength(50);

				entity.Property(e => e.DieuTri).HasMaxLength(500);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.Kqcdha)
					.HasColumnName("KQCDHA")
					.HasMaxLength(500);

				entity.Property(e => e.Kqxnmau)
					.HasColumnName("KQXNMau")
					.HasMaxLength(500);

				entity.Property(e => e.KqxnnuocTieu)
					.HasColumnName("KQXNNuocTieu")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayYlenh).HasColumnName("NgayYLenh").HasColumnType("datetime");

				entity.Property(e => e.NgayHenKhamLai).HasColumnType("datetime");

				entity.Property(e => e.NgayHenXnlai)
					.HasColumnName("NgayHenXNLai")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayYlenh)
					.HasColumnName("NgayYLenh")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TrieuChung).HasMaxLength(500);

				entity.Property(e => e.Ylenh).HasColumnName("YLenh");

				entity.HasOne(b => b.DmnhanVien)
						   .WithMany(d => d.BenhAnToDieuTris)
						   .HasForeignKey(b => b.BsdieuTri)
						   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.Dmkhoa)
						   .WithMany(d => d.BenhAnToDieuTris)
						   .HasForeignKey(b => b.MaKhoa)
						   .HasPrincipalKey(d => d.MaKhoa);

				entity.HasOne(b => b.DmNguoiHuy)
							.WithMany(d => d.BenhAnToDieuTriNguoiHuys)
							.HasForeignKey(b => b.NguoiHuy)
							.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
						 .WithMany(d => d.BenhAnToDieuTriNguoiLaps)
						 .HasForeignKey(b => b.NguoiLap)
						 .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
						 .WithMany(d => d.BenhAnToDieuTriNguoiSDs)
						 .HasForeignKey(b => b.NguoiSd)
						 .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.ThongTinBn)
						  .WithMany(d => d.BenhAnToDieuTris)
						  .HasForeignKey(b => new { b.MaBn, b.Idba })
						  .HasPrincipalKey(d => new { d.MaBn, d.Idba });

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
						  .WithMany(d => d.BenhAnToDieuTris)
						  .HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
						  .HasPrincipalKey(pk => new { pk.Idba, pk.Stt });

				entity.HasMany(b => b.BenhanThuocTayYs)
						 .WithOne(d => d.BenhAnToDieuTri)
						 .HasForeignKey(fk => new { fk.Idba, fk.NgayYlenh })
						 .HasPrincipalKey(pk => new { pk.Idba, pk.NgayYlenh })
						 .IsRequired(false);

				entity.HasOne(b => b.BenhanThuocYhct)
						 .WithOne(d => d.BenhAnToDieuTri)
						 .HasForeignKey<BenhanThuocYhct>(fk => new { fk.Idba, fk.NgayYlenh })
						 .HasPrincipalKey<BenhAnToDieuTri>(pk => new { pk.Idba, pk.NgayYlenh })
						 .IsRequired(false);

				entity.HasMany(b => b.BenhanTtvltls)
						  .WithOne(d => d.BenhAnToDieuTri)
						  .HasForeignKey(fk => new { fk.Idba, fk.NgayYlenh })
						  .HasPrincipalKey(pk => new { pk.Idba, pk.NgayYlenh })
						  .IsRequired(false);

				entity.HasMany(b => b.BenhanClses)
						  .WithOne(d => d.BenhAnToDieuTri)
						  .HasForeignKey(fk => new { fk.Idba, fk.NgayYlenh })
						  .HasPrincipalKey(pk => new { pk.Idba, pk.NgayYlenh })
						  .IsRequired(false);

				entity.HasMany(b => b.BenhanPhauThuats)
						  .WithOne(d => d.BenhAnToDieuTri)
						  .HasForeignKey(fk => new { fk.Idba, fk.NgayYlenh })
						  .HasPrincipalKey(pk => new { pk.Idba, pk.NgayYlenh })
						  .IsRequired(false);

				entity.HasMany(b => b.BenhanCpms)
						  .WithOne(d => d.BenhAnToDieuTri)
						  .HasForeignKey(fk => new { fk.Idba, fk.NgayYlenh })
						  .HasPrincipalKey(pk => new { pk.Idba, pk.NgayYlenh })
						  .IsRequired(false);
			});


			modelBuilder.Entity<BenhAnTongKet15NgayDt>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_TongKet15NgayDT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.DanhGiaKq)
					.HasColumnName("DanhGiaKQ")
					.HasMaxLength(250);

				entity.Property(e => e.DenNgay).HasColumnType("datetime");

				entity.Property(e => e.DienBienLamSang).HasMaxLength(500);

				entity.Property(e => e.HuongDt)
					.HasColumnName("HuongDT")
					.HasMaxLength(520);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKyBsdieuTri)
					.HasColumnName("NgayKyBSDieuTri")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayKyTruongKhoa).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.QuaTrinhDt)
					.HasColumnName("QuaTrinhDT")
					.HasMaxLength(500);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TruongKhoa).HasMaxLength(50);

				entity.Property(e => e.TuNgay).HasColumnType("datetime");

				entity.Property(e => e.XnlamSang)
					.HasColumnName("XNLamSang")
					.HasMaxLength(500);

				entity.HasOne(b => b.DmBsdieuTri)
					.WithMany(d => d.BenhAnTongKet15NgayDtBsdieuTris)
					.HasForeignKey(b => b.BsdieuTri)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmTruongKhoa)
					.WithMany(d => d.BenhAnTongKet15NgayDtTruongKhoas)
					.HasForeignKey(b => b.TruongKhoa)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
					.WithMany(d => d.BenhAnTongKet15NgayDtNguoiSDs)
					.HasForeignKey(b => b.NguoiSd)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
					  .WithMany(d => d.BenhAnTongKet15NgayDtNguoiLaps)
					  .HasForeignKey(b => b.NguoiLap)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhAnTongKet15NgayDtNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhAnTongKet15NgayDts)
					.HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
					.HasPrincipalKey(pk => new { pk.Idba, pk.Stt });
			});

			modelBuilder.Entity<BenhAnTongKetBenhAn>(entity =>
			{
				entity.HasKey(e => e.Idba);

				entity.ToTable("BenhAn_TongKetBenhAn");

				entity.Property(e => e.Idba)
						.HasColumnName("IDBA")
						.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BsdieuTri)
						.HasColumnName("BSDieuTri")
						.HasMaxLength(50);

				entity.Property(e => e.ChucNangKhac).HasMaxLength(250);

				entity.Property(e => e.ChucNangShhangNgay)
						.HasColumnName("ChucNangSHHangNgay")
						.HasMaxLength(250);

				entity.Property(e => e.HuongDt)
						.HasColumnName("HuongDT")
						.HasMaxLength(250);

				entity.Property(e => e.Khac).HasMaxLength(50);

				entity.Property(e => e.Kqdt)
						.HasColumnName("KQDT")
						.HasMaxLength(50);

				entity.Property(e => e.LyDoVv)
						.HasColumnName("LyDoVV")
						.HasMaxLength(500);

				entity.Property(e => e.MaBa)
						.HasColumnName("MaBA")
						.HasMaxLength(50);

				entity.Property(e => e.MaBn)
						.HasColumnName("MaBN")
						.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
						.HasColumnName("NgaySD")
						.HasColumnType("datetime");

				entity.Property(e => e.NguoiGiaoHs)
						.HasColumnName("NguoiGiaoHS")
						.HasMaxLength(50);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiNhanHs)
						.HasColumnName("NguoiNhanHS")
						.HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
						.HasColumnName("NguoiSD")
						.HasMaxLength(50);

				entity.Property(e => e.NhanThuc).HasMaxLength(250);

				entity.Property(e => e.PpdttheoYhct)
						.HasColumnName("PPDTTheoYHCT")
						.HasMaxLength(500);

				entity.Property(e => e.PpdttheoYhhd)
						.HasColumnName("PPDTTheoYHHD")
						.HasMaxLength(500);

				entity.Property(e => e.QuaTrinhBenhLy).HasMaxLength(500);

				entity.Property(e => e.SoToCt).HasColumnName("SoToCT");

				entity.Property(e => e.SoToMri).HasColumnName("SoToMRI");

				entity.Property(e => e.SoToSa).HasColumnName("SoToSA");

				entity.Property(e => e.SoToToanBoHs).HasColumnName("SoToToanBoHS");

				entity.Property(e => e.SoToXn).HasColumnName("SoToXN");

				entity.Property(e => e.SoToXquang).HasColumnName("SoToXQuang");

				entity.Property(e => e.ThamGiaHoatDong).HasMaxLength(250);

				entity.Property(e => e.TinhTrangBnrv)
						.HasColumnName("TinhTrangBNRV")
						.HasMaxLength(250);

				entity.Property(e => e.TomTatKetQuaCls)
						.HasColumnName("TomTatKetQuaCLS")
						.HasMaxLength(500);

				entity.Property(e => e.VanDong).HasMaxLength(250);

				entity.Property(e => e.YeuToMoiTruong).HasMaxLength(250);

				entity.HasOne(ba => ba.DmBsDieutri)
					.WithMany(dm => dm.BenhAnTongKetBsDieuTris)
					.HasForeignKey(fk => fk.BsdieuTri)
					.HasPrincipalKey(pk => pk.MaNv);

				entity.HasOne(ba => ba.DmNguoiGiao)
					.WithMany(dm => dm.BenhAnTongKetNguoiGiaos)
					.HasForeignKey(fk => fk.NguoiGiaoHs)
					.HasPrincipalKey(pk => pk.MaNv);

				entity.HasOne(ba => ba.DmNguoiNhan)
					.WithMany(dm => dm.BenhAnTongKetNguoiNhans)
					.HasForeignKey(fk => fk.NguoiNhanHs)
					.HasPrincipalKey(pk => pk.MaNv);
			});

			modelBuilder.Entity<BenhAnTtvltlThuchien>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba })
					.HasName("PK_BenhAn_VLTL_Thuchien");

				entity.ToTable("BenhAn_TTVLTL_Thuchien");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.GhiChu).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.LieuLuong).HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap)
					.HasColumnType("datetime")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayThucHien).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiThucHien).HasMaxLength(50);

				entity.Property(e => e.SttchiDinh).HasColumnName("STTChiDinh");

				entity.Property(e => e.SttdotDt).HasColumnName("STTDotDT");

				entity.Property(e => e.ThoiGian).HasMaxLength(50);

				entity.HasOne(b => b.BenhanTtvltl)
					  .WithMany(d => d.BenhAnTtvltlThuchiens)
					  .HasForeignKey(b => new { b.Idba, b.SttchiDinh })
					  .HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhAnTtvltlThuchienNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnTtvltlThuchienNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnTtvltlThuchienNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmdichVu)
					.WithMany(d => d.BenhAnTtvltlThuchien)
					.HasForeignKey(b => b.MaDv)
					.HasPrincipalKey(d => d.MaDv);
			});

			modelBuilder.Entity<BenhAnTvBbkiemDiem>(entity =>
			{
				entity.HasKey(e => e.Idba);

				entity.ToTable("BenhAn_TV_BBKiemDiem");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.NoiHop).HasMaxLength(150);

				entity.Property(e => e.NguyenNhanTv).HasColumnName("NguyenNhanTV").HasMaxLength(1500);

				entity.Property(e => e.ChamSoc).HasMaxLength(500);

				entity.Property(e => e.ChanDoan).HasMaxLength(50);

				entity.Property(e => e.ChuToa).HasMaxLength(50);

				entity.Property(e => e.DieuTri).HasMaxLength(500);

				entity.Property(e => e.HopTai).HasMaxLength(500);

				entity.Property(e => e.KetLuan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTuVong).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.QuanHeVoiGdbn)
					.HasColumnName("QuanHeVoiGDBN")
					.HasMaxLength(250);

				entity.Property(e => e.SoPhieu)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Sttkhoa)
					.HasColumnName("STTKhoa");

				entity.Property(e => e.ThamKham).HasMaxLength(500);

				entity.Property(e => e.ThoiGianKiemDiem).HasColumnType("datetime");

				entity.Property(e => e.ThuKy).HasMaxLength(50);

				entity.Property(e => e.TiepDonBn).HasMaxLength(500);

				entity.Property(e => e.TinhTrangVv)
					.HasColumnName("TinhTrangVV")
					.HasMaxLength(500);

				entity.Property(e => e.TomTatDienBien).HasMaxLength(500);

				entity.Property(e => e.TomTatQtbenh)
					.HasColumnName("TomTatQTBenh")
					.HasMaxLength(500);
				entity.Property(e => e.YkienBoSung)
					.HasColumnName("YKienBoSung")
					.HasMaxLength(500);

				entity.HasOne(b => b.DmChuToa)
					  .WithMany(d => d.BenhAnTvBbkiemDiemChuToas)
					  .HasForeignKey(b => b.ChuToa)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmThuKy)
					  .WithMany(d => d.BenhAnTvBbkiemDiemThuKys)
					  .HasForeignKey(b => b.ThuKy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhAnTvBbkiemDiemNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhAnTvBbkiemDiemNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhAnTvBbkiemDiemNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhAnTvBbkiemDiems)
					.HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
					.HasPrincipalKey(pk => new { pk.Idba, pk.Stt });
			});

			modelBuilder.Entity<BenhAnTvBbkiemDiemTv>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_TV_BBKiemDiem_TV");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaNv)
					.HasColumnName("MaNV")
					.HasMaxLength(10);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.VaiTro).HasMaxLength(250);

				entity.HasOne(b => b.DmThanhVien)
				   .WithMany(d => d.BenhAnTvBbkiemDiemTvThanhViens)
				   .HasForeignKey(b => b.MaNv)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
				   .WithMany(d => d.BenhAnTvBbkiemDiemTvNguoiHuys)
				   .HasForeignKey(b => b.NguoiHuy)
				   .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhAnTvGiayBaoTu>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("BenhAn_TV_GiayBaoTu");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayCap).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.QuyenSo).HasMaxLength(50);

				entity.Property(e => e.QuyenSoLanDau).HasMaxLength(50);

				entity.Property(e => e.SoGiayBaoTu).HasMaxLength(50);

				entity.Property(e => e.SoGiayBaoTuLanDau).HasMaxLength(50);
			});

			modelBuilder.Entity<BenhAnTvPhieuCdnguyenNhan>(entity =>
			{
				entity.HasKey(e => e.Idba)
					.HasName("PK_BenhAn_TV_PhieuChanDoanNN");

				entity.ToTable("BenhAn_TV_PhieuCDNguyenNhan");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)")
					.ValueGeneratedNever();

				entity.Property(e => e.CanNang).HasMaxLength(50);

				entity.Property(e => e.ChuSinh).HasMaxLength(500);

				entity.Property(e => e.GioSongSauSinh).HasMaxLength(50);

				entity.Property(e => e.HinhThucTv).HasColumnName("HinhThucTV");

				entity.Property(e => e.Kntt).HasColumnName("KNTT");

				entity.Property(e => e.LyDoPt)
					.HasColumnName("LyDoPT")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaBenhNntv)
					.HasColumnName("MaBenhNNTV")
					.HasMaxLength(50);

				entity.Property(e => e.MangThaiGayTv).HasColumnName("MangThaiGayTV");

				entity.Property(e => e.MoTaNguyenNhanChanThuong).HasMaxLength(500);

				entity.Property(e => e.NgayChanThuong).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgayPhauThuat).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTv)
					.HasColumnName("NgayTV")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiLap).HasMaxLength(6);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.NguyenNhan2).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanA).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanB).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanC).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanChanThuong).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanD).HasMaxLength(500);

				entity.Property(e => e.NoiTuVong)
					.HasMaxLength(50);

				entity.Property(e => e.NoiTv)
					.HasColumnName("NoiTV")
					.HasMaxLength(100);

				entity.Property(e => e.Sdkq).HasColumnName("SDKQ");

				entity.Property(e => e.SoPhieu)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.SoTuanMangThai).HasMaxLength(50);

				entity.Property(e => e.TenNntv)
					.HasColumnName("TenNNTV")
					.HasMaxLength(500);

				entity.Property(e => e.ThoiGian2).HasMaxLength(100);

				entity.Property(e => e.ThoiGianA).HasMaxLength(100);

				entity.Property(e => e.ThoiGianB).HasMaxLength(100);

				entity.Property(e => e.ThoiGianC).HasMaxLength(100);

				entity.Property(e => e.ThoiGianD).HasMaxLength(100);

				entity.Property(e => e.TuoiMe).HasMaxLength(50);

				entity.Property(e => e.Tvcc).HasColumnName("TVCC");

				entity.Property(e => e.NguoiLapPhieu).HasMaxLength(50);

				entity.Property(e => e.Thutruong).HasMaxLength(50);

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.HasOne(b => b.DmbenhTat)
				  .WithMany(d => d.BenhAnTvPhieuCdnguyenNhans)
				  .HasForeignKey(b => b.MaBenhNntv)
				  .HasPrincipalKey(d => d.MaBenh);

				entity.HasOne(b => b.DmNguoiLapPhieu)
				  .WithMany(d => d.BenhAnTvPhieuCdnguyenNhanNguoiLapPhieus)
				  .HasForeignKey(b => b.NguoiLapPhieu)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmThutruong)
				  .WithMany(d => d.BenhAnTvPhieuCdnguyenNhanThutruongs)
				  .HasForeignKey(b => b.Thutruong)
				  .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhanCls>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt })
					.HasName("PK_Benhan_Dichvu");

				entity.ToTable("Benhan_CLS");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Bschidinh)
					.HasColumnName("BSChidinh")
					.HasMaxLength(50);

				entity.Property(e => e.Capcuu).HasDefaultValueSql("((0))");

				entity.Property(e => e.DoiTuong).HasMaxLength(150);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayYlenh)
					.HasColumnName("NgayYLenh")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.ViTri).HasMaxLength(300);

				entity.HasOne(b => b.DmdichVu)
				   .WithMany(d => d.BenhanClss)
				   .HasForeignKey(b => b.MaDv)
				   .HasPrincipalKey(d => d.MaDv);

				entity.HasOne(b => b.DmnhanVien)
				  .WithMany(d => d.BenhanClsBsChiDinhs)
				  .HasForeignKey(b => b.Bschidinh)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanClsNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanClsNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanClsNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);


				entity.HasOne(b => b.DmdichVu)
				  .WithMany(d => d.BenhanClss)
				  .HasForeignKey(b => b.MaDv)
				  .HasPrincipalKey(d => d.MaDv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
				  .WithMany(d => d.BenhanClss)
				  .HasForeignKey(fk => new { fk.Idba, fk.Sttkhoa })
				  .HasPrincipalKey(pk => new { pk.Idba, pk.Stt });

				entity.HasOne(b => b.BenhAnClsKq)
				  .WithMany(d => d.BenhanClss)
				  .HasForeignKey(fk => new { fk.Idba, fk.Stt })
				  .HasPrincipalKey(pk => new { pk.Idba, pk.Sttdv });

				entity.HasMany(b => b.BenhanClsKqcss)
				  .WithOne(d => d.BenhanCls)
				  .HasForeignKey(fk => new { fk.Idba, fk.Sttdv })
				  .HasPrincipalKey(pk => new { pk.Idba, pk.Stt });

				entity.HasOne(b => b.DmdichvuNhomInChiDinh)
				   .WithMany(d => d.BenhanClss)
				   .HasForeignKey(b => b.MaDv)
				   .HasPrincipalKey(d => d.MaDv);
			});

			modelBuilder.Entity<BenhanClsKqcs>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt })
					.HasName("PK_Benhan_XN_KQ");

				entity.ToTable("Benhan_CLS_KQCS");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BatThuong).HasMaxLength(150);

				entity.Property(e => e.ChiSoBinhThuongNam).HasMaxLength(50);

				entity.Property(e => e.ChiSoBinhThuongNhi).HasMaxLength(50);

				entity.Property(e => e.ChiSoBinhThuongNu).HasMaxLength(50);

				entity.Property(e => e.DonViDo).HasMaxLength(250);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.Idlis)
					.IsRequired()
					.HasColumnName("IDLIS")
					.HasMaxLength(50);

				entity.Property(e => e.Kq).HasColumnName("KQ");

				entity.Property(e => e.Ktv)
					.HasColumnName("KTV")
					.HasMaxLength(50);

				entity.Property(e => e.LinkPacsLis)
					.HasColumnName("LinkPACS_LIS")
					.HasMaxLength(250);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaCs)
					.HasColumnName("MaCS")
					.HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoaThucHien).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaMayThucHien).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKyKq)
					.HasColumnName("NgayKyKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTiepNhan).HasColumnType("datetime");

				entity.Property(e => e.NgayTraKq)
					.HasColumnName("NgayTraKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiDuyetKq)
					.HasColumnName("NguoiDuyetKQ")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoPhieu)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Sttdv).HasColumnName("STTDV");

				entity.Property(e => e.TenCs)
					.HasColumnName("TenCS")
					.HasMaxLength(250);

				entity.HasOne(b => b.DmKtv)
					  .WithMany(d => d.BenhanClsKqcsKtvs)
					  .HasForeignKey(b => b.Ktv)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiDuyetKq)
					  .WithMany(d => d.BenhanClsKqcsNguoiDuyetKqs)
					  .HasForeignKey(b => b.NguoiDuyetKq)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanClsKqcsNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanClsKqcsNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanClsKqcsNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmKhoaThucHien)
				   .WithMany(d => d.BenhanClsKqcss)
				   .HasForeignKey(b => b.MaKhoaThucHien)
				   .HasPrincipalKey(d => d.MaKhoa);

				entity.HasOne(b => b.BenhanCls)
					.WithMany(d => d.BenhanClsKqcss)
					.HasForeignKey(b => new { b.Idba, b.Sttdv })
					.HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.DmdichVuCs)
					.WithMany(d => d.BenhanClsKqcses)
					.HasForeignKey(b => b.MaCs)
					.HasPrincipalKey(d => d.MaCs);
			});

			modelBuilder.Entity<BenhanCpm>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt })
					.HasName("PK_ChiDinhCPM_1");

				entity.ToTable("Benhan_CPM");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.DoiTuong).HasMaxLength(150);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaCpm)
					.HasColumnName("MaCPM")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayYlenh)
					.HasColumnName("NgayYLenh")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Nhommau).HasMaxLength(50);

				entity.Property(e => e.Rh).HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.HasOne(b => b.DmchephamMau)
				  .WithMany(d => d.BenhanCpms)
				  .HasForeignKey(b => b.MaCpm)
				  .HasPrincipalKey(d => d.MaCpmau);

				entity.HasOne(b => b.DmnhanVien)
				  .WithMany(d => d.BenhanCpmBsDieuTris)
				  .HasForeignKey(b => b.BschiDinh)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanCpmNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanCpmNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanCpmNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
				   .WithMany(d => d.BenhanCpms)
				   .HasForeignKey(b => new { b.Idba, b.Sttkhoa })
				   .HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.BenhAnTheoDoiTruyenMau)
					.WithOne(d => d.BenhanCpm)
					.HasForeignKey<BenhAnTheoDoiTruyenMau>(b => new { b.Idba, b.Sttcpm })
					.HasPrincipalKey<BenhanCpm>(d => new { d.Idba, d.Stt });
			});

			modelBuilder.Entity<BenhanPhauThuat>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("Benhan_PhauThuat");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Bschidinh)
					.HasColumnName("BSChidinh")
					.HasMaxLength(50);

				entity.Property(e => e.DoiTuong).HasMaxLength(150);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaPt)
					.HasColumnName("MaPT")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayYlenh)
					.HasColumnName("NgayYLenh")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.ViTri).HasMaxLength(50);

				entity.HasOne(b => b.DmphauThuat)
				  .WithMany(d => d.BenhanPhauThuats)
				  .HasForeignKey(b => b.MaPt)
				  .HasPrincipalKey(d => d.MaPt);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
				  .WithMany(d => d.BenhanPhauThuats)
				  .HasForeignKey(b => new { b.Sttkhoa, b.Idba })
				  .HasPrincipalKey(d => new { d.Stt, d.Idba });

				entity.HasOne(b => b.DmBschiDinh)
				  .WithMany(d => d.BenhanPhauThuatBsDieuTris)
				  .HasForeignKey(b => b.Bschidinh)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanPhauThuatNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanPhauThuatNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanPhauThuatNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnPhauThuatDuyetMo)
						 .WithOne(d => d.BenhanPhauThuat)
						 .HasForeignKey<BenhAnPhauThuatDuyetMo>(fk => new { fk.Idba, fk.Sttpt })
						 .HasPrincipalKey<BenhanPhauThuat>(pk => new { pk.Idba, pk.Stt });

				entity.HasOne(b => b.BenhanPhauThuatPhieuKhamGayMeTruocMo)
						  .WithOne(d => d.BenhanPhauThuat)
						  .HasForeignKey<BenhanPhauThuatPhieuKhamGayMeTruocMo>(fk => new { fk.Idba, fk.Sttpt })
						  .HasPrincipalKey<BenhanPhauThuat>(pk => new { pk.Idba, pk.Stt });

				entity.HasOne(b => b.BenhanPhauThuatPhieuPttt)
						  .WithOne(d => d.BenhanPhauThuat)
						  .HasForeignKey<BenhanPhauThuatPhieuPttt>(fk => new { fk.Idba, fk.Sttpt })
						  .HasPrincipalKey<BenhanPhauThuat>(pk => new { pk.Idba, pk.Stt });
			});

			modelBuilder.Entity<BenhAnPhauThuatDuyetMo>(entity =>
						{
							entity.HasKey(e => new { e.Sttpt, e.Idba });

							entity.ToTable("BenhAn_PhauThuat_DuyetMo");

							entity.Property(e => e.Sttpt).HasColumnName("STTPT");

							entity.Property(e => e.Idba)
								.HasColumnName("IDBA")
								.HasColumnType("numeric(38, 0)");

							entity.Property(e => e.Apt)
								.HasColumnName("APT")
								.HasMaxLength(50);

							entity.Property(e => e.Bc)
								.HasColumnName("BC")
								.HasMaxLength(50);

							entity.Property(e => e.BenhSu).HasMaxLength(500);

							entity.Property(e => e.BsgayMe)
								.HasColumnName("BSGayMe")
								.HasMaxLength(50);

							entity.Property(e => e.Bspt)
								.HasColumnName("BSPT")
								.HasMaxLength(50);

							entity.Property(e => e.DuTruMau).HasMaxLength(500);

							entity.Property(e => e.Hc)
								.HasColumnName("HC")
								.HasMaxLength(50);

							entity.Property(e => e.Hct)
								.HasColumnName("HCT")
								.HasMaxLength(50);

							entity.Property(e => e.HuyetAp).HasMaxLength(50);

							entity.Property(e => e.KhoKhan).HasMaxLength(500);

							entity.Property(e => e.KipPhauThuat).HasMaxLength(500);

							entity.Property(e => e.Kqcdha)
								.HasColumnName("KQCDHA")
								.HasMaxLength(500);

							entity.Property(e => e.Kqhhkhac)
								.HasColumnName("KQHHKhac")
								.HasMaxLength(500);

							entity.Property(e => e.Kqsh)
								.HasColumnName("KQSH")
								.HasMaxLength(500);

							entity.Property(e => e.Kqxnkhac)
								.HasColumnName("KQXNKhac")
								.HasMaxLength(500);

							entity.Property(e => e.LanhDaoBv)
								.HasColumnName("LanhDaoBV")
								.HasMaxLength(50);

							entity.Property(e => e.LyDoVv)
								.HasColumnName("LyDoVV")
								.HasMaxLength(500);

							entity.Property(e => e.MaBa)
								.HasColumnName("MaBA")
								.HasMaxLength(50);

							entity.Property(e => e.MaBenh).HasMaxLength(50);

							entity.Property(e => e.MaBn)
								.HasColumnName("MaBN")
								.HasMaxLength(50);

							entity.Property(e => e.MaMay).HasMaxLength(20);

							entity.Property(e => e.MoTaHienTaiKhac).HasMaxLength(500);

							entity.Property(e => e.NgayHuy).HasColumnType("datetime");

							entity.Property(e => e.NgayKyBsgm)
								.HasColumnName("NgayKyBSGM")
								.HasColumnType("datetime");

							entity.Property(e => e.NgayKyBsldkhoa)
								.HasColumnName("NgayKyBSLDKhoa")
								.HasColumnType("datetime");

							entity.Property(e => e.NgayKyBspt)
								.HasColumnName("NgayKyBSPT")
								.HasColumnType("datetime");

							entity.Property(e => e.NgayKyLdbv)
								.HasColumnName("NgayKyLDBV")
								.HasColumnType("datetime");

							entity.Property(e => e.NgayLap).HasColumnType("datetime");

							entity.Property(e => e.NgayPt)
								.HasColumnName("NgayPT")
								.HasColumnType("datetime");

							entity.Property(e => e.NgaySd)
								.HasColumnName("NgaySD")
								.HasColumnType("datetime");

							entity.Property(e => e.NguoiHuy).HasMaxLength(50);

							entity.Property(e => e.NguoiLap).HasMaxLength(50);

							entity.Property(e => e.NguoiSd)
								.HasColumnName("NguoiSD")
								.HasMaxLength(50);

							entity.Property(e => e.NhietDo).HasColumnType("numeric(5, 2)");

							entity.Property(e => e.NhomMau).HasMaxLength(50);

							entity.Property(e => e.PhuongPhapPhauThuat).HasMaxLength(500);

							entity.Property(e => e.PhuongPhapVoCam).HasMaxLength(500);

							entity.Property(e => e.Pt)
								.HasColumnName("PT")
								.HasMaxLength(50);

							entity.Property(e => e.Tc)
								.HasColumnName("TC")
								.HasMaxLength(50);

							entity.Property(e => e.TienSuDiUng).HasMaxLength(500);

							entity.Property(e => e.TienSuKhac).HasMaxLength(500);

							entity.Property(e => e.TienSuNgoaiKhoa).HasMaxLength(500);

							entity.Property(e => e.TienSuNoiKhoa).HasMaxLength(500);

							entity.Property(e => e.TruongKhoa).HasMaxLength(50);

							entity.Property(e => e.VanDeKhac).HasMaxLength(500);

							entity.HasOne(b => b.BenhanPhauThuat)
								.WithOne(d => d.BenhAnPhauThuatDuyetMo)
								.HasForeignKey<BenhanPhauThuat>(b => new { b.Idba, b.Stt })
								.HasPrincipalKey<BenhAnPhauThuatDuyetMo>(d => new { d.Idba, d.Sttpt });

							entity.HasOne(b => b.DmBspt)
							  .WithMany(d => d.BenhAnPhauThuatDuyetMoBspts)
							  .HasForeignKey(b => b.Bspt)
							  .HasPrincipalKey(d => d.MaNv);

							entity.HasOne(b => b.DmBsgayMe)
							  .WithMany(d => d.BenhAnPhauThuatDuyetMoBsgayMes)
							  .HasForeignKey(b => b.BsgayMe)
							  .HasPrincipalKey(d => d.MaNv);

							entity.HasOne(b => b.DmTruongKhoa)
							  .WithMany(d => d.BenhAnPhauThuatDuyetMoTruongKhoas)
							  .HasForeignKey(b => b.TruongKhoa)
							  .HasPrincipalKey(d => d.MaNv);
							entity.HasOne(b => b.DmLanhDaoBv)
							  .WithMany(d => d.BenhAnPhauThuatDuyetMoLanhDaoBvs)
							  .HasForeignKey(b => b.LanhDaoBv)
							  .HasPrincipalKey(d => d.MaNv);

							entity.HasOne(b => b.DmNguoiHuy)
								  .WithMany(d => d.BenhAnPhauThuatDuyetMoNguoiHuys)
								  .HasForeignKey(b => b.NguoiHuy)
								  .HasPrincipalKey(d => d.MaNv);

							entity.HasOne(b => b.DmNguoiLap)
							   .WithMany(d => d.BenhAnPhauThuatDuyetMoNguoiLaps)
							   .HasForeignKey(b => b.NguoiLap)
							   .HasPrincipalKey(d => d.MaNv);

							entity.HasOne(b => b.DmNguoiSD)
							   .WithMany(d => d.BenhAnPhauThuatDuyetMoNguoiSDs)
							   .HasForeignKey(b => b.NguoiSd)
							   .HasPrincipalKey(d => d.MaNv);
						});

			modelBuilder.Entity<BenhanPhauThuatPhieuKhamGayMeTruocMo>(entity =>
			{
				entity.HasKey(e => new { e.Sttpt, e.Idba })
					.HasName("PK_PhauThuat_PhieuKhamGayMeTruocMo1");

				entity.ToTable("Benhan_PhauThuat_PhieuKhamGayMeTruocMo");

				entity.Property(e => e.Sttpt).HasColumnName("STTPT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Asa).HasColumnName("ASA");

				entity.Property(e => e.BsgayMeKham)
					.HasColumnName("BSGayMeKham")
					.HasMaxLength(50);

				entity.Property(e => e.BsgayMeThamLaiTruocMo)
					.HasColumnName("BSGayMeThamLaiTruocMo")
					.HasMaxLength(50);

				entity.Property(e => e.BuaAnCuoiTruocMo).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.ChanDoan).HasMaxLength(250);

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.CotSong).HasMaxLength(250);

				entity.Property(e => e.DiUng).HasMaxLength(250);

				entity.Property(e => e.DieuDuong).HasMaxLength(50);

				entity.Property(e => e.DuKienCachVoCam).HasMaxLength(250);

				entity.Property(e => e.DuKienGiamDauSauMo).HasMaxLength(250);

				entity.Property(e => e.HaMieng).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.HoHap).HasMaxLength(250);

				entity.Property(e => e.HuongXuTri).HasMaxLength(500);

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.KhamLamSang).HasMaxLength(500);

				entity.Property(e => e.KhoangCachCamGiap).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.Mallampati).HasMaxLength(5);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKham).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayThamLaiTruocMo).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhomMau).HasMaxLength(50);

				entity.Property(e => e.Rh)
					.HasColumnName("RH")
					.HasMaxLength(50);

				entity.Property(e => e.ThanKinh).HasMaxLength(250);

				entity.Property(e => e.ThuocDt)
					.HasColumnName("ThuocDT")
					.HasMaxLength(500);

				entity.Property(e => e.TienSuGayMe).HasMaxLength(500);

				entity.Property(e => e.TienSuNgoaiKhoa).HasMaxLength(500);

				entity.Property(e => e.TienSuNoiKhoa).HasMaxLength(500);

				entity.Property(e => e.TuanHoan).HasMaxLength(250);

				entity.Property(e => e.XnbatThuong)
					.HasColumnName("XNBatThuong")
					.HasMaxLength(250);

				entity.Property(e => e.YeuCauBoSung).HasMaxLength(250);

				entity.Property(e => e.YlenhTruocMo)
					.HasColumnName("YLenhTruocMo")
					.HasMaxLength(500);

				entity.HasOne(b => b.BenhanPhauThuat)
					   .WithOne(d => d.BenhanPhauThuatPhieuKhamGayMeTruocMo)
					   .HasForeignKey<BenhanPhauThuat>(b => new { b.Idba, b.Stt })
					   .HasPrincipalKey<BenhanPhauThuatPhieuKhamGayMeTruocMo>(d => new { d.Idba, d.Sttpt });

				entity.HasOne(b => b.DmDieuDuong)
					 .WithMany(d => d.BenhanPhauThuatPhieuKhamGayMeTruocMoDieuDuongs)
					 .HasForeignKey(b => b.DieuDuong)
					 .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsgayMeKham)
					.WithMany(d => d.BenhanPhauThuatPhieuKhamGayMeTruocMoBsgayMeKhams)
					.HasForeignKey(b => b.BsgayMeKham)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsgayMeThamLaiTruocMo)
					.WithMany(d => d.BenhanPhauThuatPhieuKhamGayMeTruocMoBsgayMeThamLaiTruocMos)
					.HasForeignKey(b => b.BsgayMeThamLaiTruocMo)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
						.WithMany(d => d.BenhanPhauThuatPhieuKhamGayMeTruocMoNguoiHuys)
						.HasForeignKey(b => b.NguoiHuy)
						.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
					.WithMany(d => d.BenhanPhauThuatPhieuKhamGayMeTruocMoNguoiLaps)
					.HasForeignKey(b => b.NguoiLap)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
					.WithMany(d => d.BenhanPhauThuatPhieuKhamGayMeTruocMoNguoiSDs)
					.HasForeignKey(b => b.NguoiSd)
					.HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhanPhauThuatPhieuPttt>(entity =>
			{
				entity.HasKey(e => new { e.Sttpt, e.Idba })
					.HasName("PK_PhauThuat_PhieuPTTT");

				entity.ToTable("Benhan_PhauThuat_PhieuPTTT");

				entity.Property(e => e.Sttpt).HasColumnName("STTPT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Bac).HasMaxLength(50);

				entity.Property(e => e.BsgayMe)
					.HasColumnName("BSGayMe")
					.HasMaxLength(50);

				entity.Property(e => e.BsphuMo)
					.HasColumnName("BSPhuMo")
					.HasMaxLength(50);

				entity.Property(e => e.Bspt)
					.HasColumnName("BSPT")
					.HasMaxLength(50);

				entity.Property(e => e.CachThucPt)
					.HasColumnName("CachThucPT")
					.HasMaxLength(250);

				entity.Property(e => e.ChanDoanSauPt)
					.HasColumnName("ChanDoanSauPT")
					.HasMaxLength(50);

				entity.Property(e => e.ChanDoanTruocPt)
					.HasColumnName("ChanDoanTruocPT")
					.HasMaxLength(50);

				entity.Property(e => e.DanLuu).HasMaxLength(50);

				entity.Property(e => e.Khac).HasMaxLength(500);

				entity.Property(e => e.LuocDoPt)
					.HasColumnName("LuocDoPT")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayCatChi).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgayPt)
					.HasColumnName("NgayPT")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayRutChi).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.PhanLoaiPt)
					.HasColumnName("PhanLoaiPT")
					.HasMaxLength(50);

				entity.Property(e => e.PhuongPhap).HasMaxLength(500);

				entity.Property(e => e.PhuongPhapVoCam).HasMaxLength(50);

				entity.Property(e => e.PhuongThucPt)
					.HasColumnName("PhuongThucPT")
					.HasMaxLength(50);

				entity.Property(e => e.TrinhTuPt)
					.HasColumnName("TrinhTuPT")
					.HasMaxLength(500);

				entity.Property(e => e.ViTriPt)
					.HasColumnName("ViTriPT")
					.HasMaxLength(250);

				entity.HasOne(b => b.BenhanPhauThuat)
					  .WithOne(d => d.BenhanPhauThuatPhieuPttt)
					  .HasForeignKey<BenhanPhauThuat>(b => new { b.Idba, b.Stt })
					  .HasPrincipalKey<BenhanPhauThuatPhieuPttt>(d => new { d.Idba, d.Sttpt });

				entity.HasOne(b => b.DmdichvuPhanLoaiPttt)
					  .WithMany(d => d.BenhanPhauThuatPhieuPttts)
					  .HasForeignKey(b => b.PhanLoaiPt)
					  .HasPrincipalKey(d => d.MaPlpttt);

				entity.HasOne(b => b.DmbenhTatChanDoanTruocPt)
					  .WithMany(d => d.BenhanPhauThuatPhieuPtttChanDoanTruocPts)
					  .HasForeignKey(b => b.ChanDoanTruocPt)
					  .HasPrincipalKey(d => d.MaBenh);

				entity.HasOne(b => b.DmbenhTatChanDoanSauPt)
					  .WithMany(d => d.BenhanPhauThuatPhieuPtttChanDoanSauPts)
					  .HasForeignKey(b => b.ChanDoanSauPt)
					  .HasPrincipalKey(d => d.MaBenh);

				entity.HasOne(b => b.DmBspt)
					.WithMany(d => d.BenhanPhauThuatPhieuPtttBspts)
					.HasForeignKey(b => b.Bspt)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsgayMe)
					.WithMany(d => d.BenhanPhauThuatPhieuPtttBsgayMes)
					.HasForeignKey(b => b.BsgayMe)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsphuMo)
					.WithMany(d => d.BenhanPhauThuatPhieuPtttBsphuMos)
					.HasForeignKey(b => b.BsphuMo)
					.HasPrincipalKey(d => d.MaNv);
				entity.HasOne(b => b.DmNguoiHuy)
						.WithMany(d => d.BenhanPhauThuatPhieuPtttNguoiHuys)
						.HasForeignKey(b => b.NguoiHuy)
						.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
					.WithMany(d => d.BenhanPhauThuatPhieuPtttNguoiLaps)
					.HasForeignKey(b => b.NguoiLap)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
					.WithMany(d => d.BenhanPhauThuatPhieuPtttNguoiSDs)
					.HasForeignKey(b => b.NguoiSd)
					.HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhanTheodoiTruyenDich>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("Benhan_TheodoiTruyenDich");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.DieuDuong).HasMaxLength(50);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaDichTruyen).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTheoDoi).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoLo).HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TenDichTruyen).HasMaxLength(250);

				entity.Property(e => e.ThoiGianBatDau).HasColumnType("datetime");

				entity.Property(e => e.ThoiGianKetThuc).HasColumnType("datetime");

				entity.Property(e => e.TocDo).HasMaxLength(50);
				entity.HasOne(b => b.DmBschiDinh)
				   .WithMany(d => d.BenhanTheodoiTruyenDichBschiDinhs)
				   .HasForeignKey(b => b.BschiDinh)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmDieuDuong)
				   .WithMany(d => d.BenhanTheodoiTruyenDichDieuDuongs)
				   .HasForeignKey(b => b.DieuDuong)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanTheodoiTruyenDichNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanTheodoiTruyenDichNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanTheodoiTruyenDichNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
				   .WithMany(d => d.BenhanTheodoiTruyenDiches)
				   .HasForeignKey(b => new { b.Idba, b.Sttkhoa })
				   .HasPrincipalKey(b => new { b.Idba, b.Stt });
			});

			modelBuilder.Entity<BenhanThuocTayY>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt })
					.HasName("PK_ChiDinhThuocTayY_1");

				entity.ToTable("Benhan_ThuocTayY");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.CachDung).HasMaxLength(500);

				entity.Property(e => e.DoiTuong).HasMaxLength(150);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.Lieudung).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayYlenh)
					.HasColumnName("NgayYLenh")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoLuong).HasColumnType("numeric(7, 3)");

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.TenThuoc).HasMaxLength(500);

				entity.HasOne(b => b.DmnhanVien)
				   .WithMany(d => d.BenhanThuocTayYs)
				   .HasForeignKey(b => b.BschiDinh)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanThuocTayYNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanThuocTayYNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanThuocTayYNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.Dmthuoc)
				   .WithMany(d => d.BenhanThuocTayYs)
				   .HasForeignKey(b => b.MaThuoc)
				   .HasPrincipalKey(d => d.MaThuoc);
			});

			modelBuilder.Entity<BenhanThuocYhct>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba })
					.HasName("PK_ChiDinhThuocYHCT_1");

				entity.ToTable("Benhan_ThuocYHCT");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
			  .HasColumnName("BSChiDinh")
			  .HasMaxLength(50);

				entity.Property(e => e.TenBaiThuoc).HasMaxLength(150);

				entity.Property(e => e.CachDung).HasMaxLength(50);

				entity.Property(e => e.CachSacThuoc).HasMaxLength(500);

				entity.Property(e => e.DoiTuong).HasMaxLength(150);

				entity.Property(e => e.DuongDung).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayYlenh)
					.HasColumnName("NgayYLenh")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.HasMany(b => b.BenhanThuocYhctCs)
				   .WithOne(d => d.BenhanThuocYhct)
				   .HasForeignKey(b => new { b.MaBa, b.Sttkhoa, b.Sttthuoc })
				   .HasPrincipalKey(d => new { d.MaBa, d.Sttkhoa, d.Stt });

				entity.HasOne(b => b.DmnhanVien)
					.WithMany(d => d.BenhanThuocYhcts)
					.HasForeignKey(b => b.BschiDinh)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanThuocYhctNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanThuocYhctNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanThuocYhctNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasMany(b => b.BenhanThuocYhctCs)
					.WithOne(d => d.BenhanThuocYhct)
					.HasForeignKey(b => b.MaBa)
					.HasPrincipalKey(d => d.MaBa);
			});

			modelBuilder.Entity<BenhanThuocYhctC>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("Benhan_ThuocYHCT_C");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoLuong).HasColumnType("numeric(7, 3)");

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.Sttthuoc).HasColumnName("STTThuoc");

				entity.HasOne(b => b.BenhanThuocYhct)
				   .WithMany(d => d.BenhanThuocYhctCs)
				   .HasForeignKey(b => new { b.MaBa, b.Sttkhoa, b.Sttthuoc })
				   .HasPrincipalKey(d => new { d.MaBa, d.Sttkhoa, d.Stt });

				entity.HasOne(b => b.Dmthuoc)
				  .WithMany(d => d.BenhanThuocYhctCs)
				  .HasForeignKey(b => b.MaThuoc)
				  .HasPrincipalKey(d => d.MaThuoc);

				entity.HasOne(b => b.DmNguoiHuy)
					  .WithMany(d => d.BenhanThuocYhctCNguoiHuys)
					  .HasForeignKey(b => b.NguoiHuy)
					  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanThuocYhctCNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanThuocYhctCNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<BenhanTiensubenhBenhphoihop>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("Benhan_Tiensubenh_Benhphoihop");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.Maloaibenh)
					.HasColumnName("MALOAIBENH")
					.HasMaxLength(50);

				entity.Property(e => e.Mota).HasMaxLength(250);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");
			});

			modelBuilder.Entity<BenhanTtvltl>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt })
				  .HasName("PK_ChiDinhVLTL_1");

				entity.ToTable("Benhan_TTVLTL");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Bschidinh)
					.HasColumnName("BSChidinh")
					.HasMaxLength(50);

				entity.Property(e => e.DoiTuong).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayYlenh)
					.HasColumnName("NgayYLenh")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.ThoiGian).HasMaxLength(50);

				entity.Property(e => e.ViTri).HasMaxLength(500);

				entity.HasOne(b => b.DmdichVu)
					.WithMany(d => d.BenhanTtvltls)
					.HasForeignKey(b => b.MaDv)
					.HasPrincipalKey(d => d.MaDv);

				entity.HasOne(b => b.DmnhanVien)
					.WithMany(d => d.BenhanTtvltls)
					.HasForeignKey(b => b.Bschidinh)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhanTtvltlNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
					.WithMany(d => d.BenhanTtvltlNguoiLaps)
					.HasForeignKey(b => b.NguoiLap)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
					.WithMany(d => d.BenhanTtvltlNguoiSDs)
					.HasForeignKey(b => b.NguoiSd)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhanTtvltls)
					.HasForeignKey(b => new { b.Idba, b.Sttkhoa })
					.HasPrincipalKey(d => new { d.Idba, d.Stt });
			});

			modelBuilder.Entity<BenhanTtvltlDotDieuTri>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt })
					.HasName("PK_Benhan_VLTL_DotDieuTri");

				entity.ToTable("Benhan_TTVLTL_DotDieuTri");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Idhis)
					.HasColumnName("IDHIS")
					.HasMaxLength(50);

				entity.Property(e => e.KhamBenh).HasMaxLength(500);

				entity.Property(e => e.Kq)
					.HasColumnName("KQ")
					.HasMaxLength(500);

				entity.Property(e => e.LoaiBa).HasColumnName("LoaiBA");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap)
					.HasColumnType("datetime")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Ppdt)
					.HasColumnName("PPDT")
					.HasMaxLength(250);

				entity.Property(e => e.Sttkhoa).HasColumnName("STTKhoa");

				entity.Property(e => e.XuTri).HasMaxLength(500);

				entity.HasOne(b => b.BenhAnKhoaDieuTri)
					.WithMany(d => d.BenhanTtvltlDotDieuTris)
					.HasForeignKey(b => new { b.Idba, b.Sttkhoa })
					.HasPrincipalKey(d => new { d.Idba, d.Stt });

				entity.HasOne(b => b.DmNguoiHuy)
					.WithMany(d => d.BenhanTtvltlDotDieuTriNguoiHuys)
					.HasForeignKey(b => b.NguoiHuy)
					.HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiLap)
				   .WithMany(d => d.BenhanTtvltlDotDieuTriNguoiLaps)
				   .HasForeignKey(b => b.NguoiLap)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.BenhanTtvltlDotDieuTriNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmBsdieuTri)
				   .WithMany(d => d.BenhanTtvltlDotDieuTriBsDieuTris)
				   .HasForeignKey(b => b.BsdieuTri)
				   .HasPrincipalKey(d => d.MaNv);

				entity.HasMany(b => b.BenhAnTtvltlThuchiens)
				   .WithOne(d => d.BenhanTtvltlDotDieuTri)
				   .HasForeignKey(b => new { b.Idba, b.SttdotDt })
				   .HasPrincipalKey(d => new { d.Idba, d.Stt });
			});

			modelBuilder.Entity<BienBanKiemDiemTuVong>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Buong).HasMaxLength(50);

				entity.Property(e => e.ChamSoc).HasMaxLength(500);

				entity.Property(e => e.ChanDoan).HasMaxLength(50);

				entity.Property(e => e.ChuToa).HasMaxLength(50);

				entity.Property(e => e.DieuTri).HasMaxLength(500);

				entity.Property(e => e.HopTai).HasMaxLength(500);

				entity.Property(e => e.KetLuan).HasMaxLength(500);

				entity.Property(e => e.KhoaTuVong).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTuVong).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.QuanHeVoiGdbn)
					.HasColumnName("QuanHeVoiGDBN")
					.HasMaxLength(250);

				entity.Property(e => e.ThamKham).HasMaxLength(500);

				entity.Property(e => e.ThoiGianKiemDiem).HasColumnType("datetime");

				entity.Property(e => e.ThuKy).HasMaxLength(50);

				entity.Property(e => e.TiepDonBn).HasMaxLength(500);

				entity.Property(e => e.TinhTrangVv)
					.HasColumnName("TinhTrangVV")
					.HasMaxLength(500);

				entity.Property(e => e.TomTatDienBien).HasMaxLength(500);

				entity.Property(e => e.TomTatQtbenh)
					.HasColumnName("TomTatQTBenh")
					.HasMaxLength(500);

				entity.Property(e => e.YkienBoSung)
					.HasColumnName("YKienBoSung")
					.HasMaxLength(500);
			});

			modelBuilder.Entity<ChiDinhCpm>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("ChiDinhCPM");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaCpm)
					.HasColumnName("MaCPM")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayCd)
					.HasColumnName("NgayCD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<ChiDinhPt>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.Stt });

				entity.ToTable("ChiDinhPT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.GhiChu).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayThucHien).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<ChiDinhThuocTayY>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.CachDung).HasMaxLength(50);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.DuongDung).HasMaxLength(50);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.HoatChat).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoVaoVien).HasMaxLength(50);
			});

			modelBuilder.Entity<ChiDinhThuocYhct>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("ChiDinhThuocYHCT");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.CachDung).HasMaxLength(50);

				entity.Property(e => e.CachSacThuoc).HasMaxLength(500);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.DuongDung).HasMaxLength(50);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.HoatChat).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoVaoVien).HasMaxLength(50);
			});

			modelBuilder.Entity<ChiDinhVltl>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Sttdv, e.Idba });

				entity.ToTable("ChiDinhVLTL");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Sttdv).HasColumnName("STTDV");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.CachDung).HasMaxLength(50);

				entity.Property(e => e.DienBien).HasMaxLength(500);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.Kq)
					.HasColumnName("KQ")
					.HasMaxLength(500);

				entity.Property(e => e.LanLam).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayThucHien).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.ViTri).HasMaxLength(50);
			});

			modelBuilder.Entity<DmbaChuyenVien>(entity =>
			{
				entity.HasKey(e => e.MaChuyenvien);

				entity.ToTable("DMBA_ChuyenVien");

				entity.Property(e => e.MaChuyenvien)
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByte)
					.HasColumnName("MaBYTe")
					.HasMaxLength(6);

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenChuyenvien)
					.IsRequired()
					.HasMaxLength(150);
			});
			modelBuilder.Entity<DmbaCombods>(entity =>
			{
				entity.HasKey(e => e.Ma);

				entity.ToTable("DMBA_ComboDS");

				entity.Property(e => e.Ma)
					.HasMaxLength(50);

				entity.Property(e => e.Ten).HasMaxLength(500);

				entity.Property(e => e.MaParent).HasMaxLength(50);

				entity.Property(e => e.MaParent).HasMaxLength(500);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.HasMaxLength(20);

				entity.Property(e => e.NgayLap).HasColumnType("datetime");
				entity.Property(e => e.NguoiLap).HasMaxLength(50);
			});

			modelBuilder.Entity<DmbaHtraVien>(entity =>
			{
				entity.HasKey(e => e.MaHtraVien);

				entity.ToTable("DMBA_HTRaVien");

				entity.Property(e => e.MaHtraVien)
					.HasColumnName("MaHTRaVien")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.Mabyte)
					.HasColumnName("mabyte")
					.HasMaxLength(200);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenHtraVien)
					.IsRequired()
					.HasColumnName("TenHTRaVien")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaHuongDt>(entity =>
			{
				entity.HasKey(e => e.MaHdt);

				entity.ToTable("DMBA_HuongDT");

				entity.Property(e => e.MaHdt)
					.HasColumnName("MaHDT")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Loai).HasColumnName("LOAI");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenHdt)
					.IsRequired()
					.HasColumnName("TenHDT")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaKqdtri>(entity =>
			{
				entity.HasKey(e => e.MaKqdt);

				entity.ToTable("DMBA_KQDTri");

				entity.Property(e => e.MaKqdt)
					.HasColumnName("MaKQDT")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.Mabyte)
					.HasColumnName("mabyte")
					.HasMaxLength(200);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenKqdt)
					.IsRequired()
					.HasColumnName("TenKQDT")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaKqgpb>(entity =>
			{
				entity.HasKey(e => e.MaKqdt);

				entity.ToTable("DMBA_KQGPB");

				entity.Property(e => e.MaKqdt)
					.HasColumnName("MaKQDT")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.Mabyte)
					.HasColumnName("mabyte")
					.HasMaxLength(200);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenKqdt)
					.IsRequired()
					.HasColumnName("TenKQDT")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaLdchuyenVien>(entity =>
			{
				entity.HasKey(e => e.MaLdchuyenvien);

				entity.ToTable("DMBA_LDChuyenVien");

				entity.Property(e => e.MaLdchuyenvien)
					.HasColumnName("MaLDChuyenvien")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByte)
					.HasColumnName("MaBYTe")
					.HasMaxLength(6);

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenLdchuyenvien)
					.IsRequired()
					.HasColumnName("TenLDChuyenvien")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaLdtvong>(entity =>
			{
				entity.HasKey(e => e.MaLdtvong);

				entity.ToTable("DMBA_LDTVong");

				entity.Property(e => e.MaLdtvong)
					.HasColumnName("MaLDTVong")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenLdtvong)
					.IsRequired()
					.HasColumnName("TenLDTVong")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaLoaiBa>(entity =>
			{
				entity.HasKey(e => e.MaLoaiBa);

				entity.ToTable("DMBA_LoaiBA");

				entity.Property(e => e.MaLoaiBa)
					.HasColumnName("MaLoaiBA")
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");
				entity.Property(e => e.MaMay).HasMaxLength(50);

				entity.Property(e => e.NgayLap)
					.HasColumnName("NgayLap")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiLap)
					.HasColumnName("NguoiLap")
					.HasMaxLength(50);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy)
					 .HasColumnName("NgayHuy")
					 .HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy)
					.HasColumnName("NguoiHuy")
					.HasMaxLength(50);

				entity.Property(e => e.TenLoaiBa).HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaLoaiTaiLieu>(entity =>
			{
				entity.HasKey(e => e.MaLoaiTaiLieu);

				entity.ToTable("DMBA_LoaiTaiLieu");

				entity.Property(e => e.MaLoaiTaiLieu)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.MaMay).HasMaxLength(50);

				entity.Property(e => e.NgaySd)
				  .HasColumnName("NgaySD")
				  .HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhomTaiLieu).HasMaxLength(500);

				entity.Property(e => e.TableName).HasMaxLength(50);

				entity.Property(e => e.TenLoaiTaiLieu).HasMaxLength(500);

				entity.Property(e => e.MaNhomTaiLieu);

				entity.Property(e => e.OrderBy).HasColumnName("orderBy");
			});

			modelBuilder.Entity<DmbaNoiGt>(entity =>
			{
				entity.HasKey(e => e.MaNoiGt);

				entity.ToTable("DMBA_NoiGT");

				entity.Property(e => e.MaNoiGt)
					.HasColumnName("MaNoiGT")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenNoiGt)
					.IsRequired()
					.HasColumnName("TenNoiGT")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaNoiKham>(entity =>
			{
				entity.HasKey(e => e.MaNoiKham);

				entity.ToTable("DMBA_NoiKham");

				entity.Property(e => e.MaNoiKham)
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenNoiKham)
					.IsRequired()
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmbaTgtvong>(entity =>
			{
				entity.HasKey(e => e.MaTgtvong)
					.HasName("PK_DMBA_TGTVongri");

				entity.ToTable("DMBA_TGTVong");

				entity.Property(e => e.MaTgtvong)
					.HasColumnName("MaTGTVong")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenTgtvong)
					.IsRequired()
					.HasColumnName("TenTGTVong")
					.HasMaxLength(150);
			});
			modelBuilder.Entity<DmbenhTat>(entity =>
			{
				entity.HasKey(e => e.MaBenh)
					.HasName("PK_dmbenhtat");

				entity.ToTable("DMBenhTat");

				entity.Property(e => e.MaBenh)
					.HasMaxLength(255)
					.ValueGeneratedNever();

				entity.Property(e => e.ChapterName).HasMaxLength(500);

				entity.Property(e => e.DiseaseName).HasMaxLength(500);

				entity.Property(e => e.MaBenhKhongdau).HasMaxLength(50);

				entity.Property(e => e.MaChuong).HasMaxLength(255);

				entity.Property(e => e.MaLoai).HasMaxLength(255);

				entity.Property(e => e.MaNhomBcbyt)
					.HasColumnName("MaNhomBCBYT")
					.HasMaxLength(255);

				entity.Property(e => e.MaNhomChinh).HasMaxLength(255);

				entity.Property(e => e.MaNhomCoChiTiet).HasMaxLength(255);

				entity.Property(e => e.MaNhomPhu1).HasMaxLength(255);

				entity.Property(e => e.MaNhomPhu2).HasMaxLength(255);

				entity.Property(e => e.MainGroupName1).HasMaxLength(500);

				entity.Property(e => e.Sttchuong)
					.HasColumnName("STTChuong")
					.HasMaxLength(255);

				entity.Property(e => e.SubGroupName1).HasMaxLength(500);

				entity.Property(e => e.SubGroupName2).HasMaxLength(500);

				entity.Property(e => e.TenBenh).HasMaxLength(500);

				entity.Property(e => e.TenChuong).HasMaxLength(500);

				entity.Property(e => e.TenLoai).HasMaxLength(500);

				entity.Property(e => e.TenNhomChinh).HasMaxLength(500);

				entity.Property(e => e.TenNhomPhu1).HasMaxLength(500);

				entity.Property(e => e.TenNhomPhu2).HasMaxLength(500);

				entity.Property(e => e.TypeName).HasMaxLength(500);
			});
			modelBuilder.Entity<DmbenhTatYhct>(entity =>
			{
				entity.HasKey(e => e.MaBenh)
					.HasName("PK_DMBenhDanh");

				entity.ToTable("DMBenhTatYHCT");

				entity.Property(e => e.MaBenh)
					.HasMaxLength(255)
					.ValueGeneratedNever();

				entity.Property(e => e.MaBenhIcd)
					.HasColumnName("MaBenhICD")
					.HasMaxLength(255);

				entity.Property(e => e.MaChuong).HasMaxLength(255);

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Sttchuong)
					.HasColumnName("STTChuong")
					.HasMaxLength(255);

				entity.Property(e => e.TenBenh).HasMaxLength(500);

				entity.Property(e => e.TenBenhBhyt)
					.HasColumnName("TenBenhBHYT")
					.HasMaxLength(500);

				entity.Property(e => e.TenBenhIcd)
					.HasColumnName("TenBenhICD")
					.HasMaxLength(500);

				entity.Property(e => e.TenChuong).HasMaxLength(500);
			});
			modelBuilder.Entity<DmbenhVien>(entity =>
			{
				entity.HasKey(e => e.MaBv);

				entity.ToTable("DMBenhVien");

				entity.Property(e => e.MaBv)
					.HasColumnName("MaBV")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Diachi).HasMaxLength(300);

				entity.Property(e => e.MaBhxh)
					.HasColumnName("MaBHXH")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.Matinh).HasMaxLength(5);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.Tel).HasMaxLength(30);

				entity.Property(e => e.TenBv)
					.IsRequired()
					.HasColumnName("TenBV")
					.HasMaxLength(250);

				entity.Property(e => e.TenTa)
					.HasColumnName("TenTA")
					.HasMaxLength(250);
			});
			modelBuilder.Entity<DmchephamMau>(entity =>
			{
				entity.HasKey(e => e.MaCpmau);

				entity.ToTable("DMChephamMau");

				entity.Property(e => e.MaCpmau)
					.HasColumnName("MaCPMau")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByt)
					.HasColumnName("MaBYT")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenByt)
					.HasColumnName("TenBYT")
					.HasMaxLength(250);

				entity.Property(e => e.TenCpmau)
					.IsRequired()
					.HasColumnName("TenCPMau")
					.HasMaxLength(250);

				entity.Property(e => e.TenDvt)
					.HasColumnName("TenDVT")
					.HasMaxLength(250);

				entity.Property(e => e.TenTat).HasMaxLength(20);
			});

			modelBuilder.Entity<DmchucDanh>(entity =>
			{
				entity.HasKey(e => e.MaCd);

				entity.ToTable("DMChucDanh");

				entity.Property(e => e.MaCd)
					.HasColumnName("MaCD")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenCd)
					.IsRequired()
					.HasColumnName("TenCD")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmchucVu>(entity =>
			{
				entity.HasKey(e => e.MaCv);

				entity.ToTable("DMChucVu");

				entity.Property(e => e.MaCv)
					.HasColumnName("MaCV")
					.HasMaxLength(3)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenCv)
					.IsRequired()
					.HasColumnName("TenCV")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmchuyenKhoa>(entity =>
			{
				entity.HasKey(e => e.MaCk)
					.HasName("PK_DMChuyenKHOA");

				entity.ToTable("DMChuyenKhoa");

				entity.Property(e => e.MaCk)
					.HasColumnName("MaCK")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByt)
					.HasColumnName("MaBYT")
					.HasMaxLength(6);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenCk)
					.IsRequired()
					.HasColumnName("TenCK")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmchuyenMon>(entity =>
			{
				entity.HasKey(e => e.MaChuyenMon);

				entity.ToTable("DMChuyenMon");

				entity.Property(e => e.MaChuyenMon)
					.HasMaxLength(15)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Loai).HasMaxLength(2);

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenChuyenMon)
					.IsRequired()
					.HasMaxLength(150);
			});
			modelBuilder.Entity<DmdanToc>(entity =>
			{
				entity.HasKey(e => e.MaDanToc);

				entity.ToTable("DMDantoc");

				entity.Property(e => e.MaDanToc)
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.TenDanToc)
				   .HasMaxLength(150);

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.MaQl)
					.HasColumnName("MaQL")
					.HasMaxLength(5);
			});
			modelBuilder.Entity<DmdichVu>(entity =>
			{
				entity.HasKey(e => e.MaDv);

				entity.ToTable("DMDichVu");

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.ChisocaoNam).HasMaxLength(20);

				entity.Property(e => e.ChisocaoNu).HasMaxLength(20);

				entity.Property(e => e.ChisothapNam).HasMaxLength(20);

				entity.Property(e => e.ChisothapNu).HasMaxLength(20);

				entity.Property(e => e.DonViDo).HasMaxLength(30);

				entity.Property(e => e.Ghichu).HasMaxLength(300);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByt)
					.HasColumnName("MaBYT")
					.HasMaxLength(50);

				entity.Property(e => e.MaChungloai)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaLh)
					.HasColumnName("MaLH")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNhomdv)
					.HasColumnName("MaNHOMDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaPlpttt)
					.HasColumnName("MaPLPTTT")
					.HasMaxLength(50);

				entity.Property(e => e.MaXn)
					.HasColumnName("MaXN")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenByt)
					.HasColumnName("TenBYT")
					.HasMaxLength(500);

				entity.Property(e => e.TenDv)
					.IsRequired()
					.HasColumnName("TenDV")
					.HasMaxLength(255);

				entity.Property(e => e.TenTat).HasMaxLength(20);

				entity.HasMany(b => b.DmdichVuCss)
					.WithOne(d => d.DmdichVu)
					.HasForeignKey(b => b.MaDv)
					.HasPrincipalKey(d => d.MaDv);
			});

			modelBuilder.Entity<DmdichvuGoi>(entity =>
				  {
					  entity.HasKey(e => e.MaGoi);

					  entity.ToTable("DMDichvu_Goi");

					  entity.Property(e => e.MaGoi)
				  .HasMaxLength(8)
				  .ValueGeneratedNever();

					  entity.Property(e => e.Ghichu).HasMaxLength(200);

					  entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

					  entity.Property(e => e.Loai).HasColumnName("loai");

					  entity.Property(e => e.MaBs)
				  .HasColumnName("MaBS")
				  .HasMaxLength(150);

					  entity.Property(e => e.MaMay).HasMaxLength(20);

					  entity.Property(e => e.NgayHuy).HasColumnType("datetime");

					  entity.Property(e => e.NgayLap).HasColumnType("datetime");

					  entity.Property(e => e.NgaySd)
				  .HasColumnName("NgaySD")
				  .HasColumnType("datetime");

					  entity.Property(e => e.NguoiHuy).HasMaxLength(6);

					  entity.Property(e => e.NguoiLap).HasMaxLength(6);

					  entity.Property(e => e.NguoiSd)
				  .HasColumnName("NguoiSD")
				  .HasMaxLength(6);

					  entity.Property(e => e.TenGoi)
				  .IsRequired()
				  .HasMaxLength(250);
				  });

			modelBuilder.Entity<DmdichvuGoiC>(entity =>
			{
				entity.HasKey(e => new { e.MaGoi, e.Stt })
					.HasName("PK_DMDichVu_Goi_C");

				entity.ToTable("DMDichvu_Goi_C");

				entity.Property(e => e.MaGoi).HasMaxLength(8);

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Ghichu).HasMaxLength(300);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaDv)
					.IsRequired()
					.HasColumnName("MaDV")
					.HasMaxLength(6);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Soluong)
					.HasColumnType("numeric(8, 2)")
					.HasDefaultValueSql("((1))");
			});

			modelBuilder.Entity<DmdichVuChungloai>(entity =>
			{
				entity.HasKey(e => e.MaChungLoai)
			.HasName("PK_DMCHUNGLOAI");

				entity.ToTable("DMDichVu_CHUNGLOAI");

				entity.Property(e => e.MaChungLoai)
			  .HasMaxLength(50)
			  .HasDefaultValueSql("((0))");

				entity.Property(e => e.Loai).HasColumnName("LOAI");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
			  .HasColumnName("NgaySD")
			  .HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
			  .HasColumnName("NguoiSD")
			  .HasMaxLength(50);

				entity.Property(e => e.TenChungLoai)
			  .IsRequired()
			  .HasMaxLength(250);
			});

			modelBuilder.Entity<DmdichVuCs>(entity =>
			{
				entity.HasKey(e => e.MaCs);

				entity.ToTable("DMDichVu_CS");

				entity.Property(e => e.MaCs)
					.HasColumnName("MaCS")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.ChisocaoNam).HasMaxLength(20);

				entity.Property(e => e.ChisocaoNu).HasMaxLength(20);

				entity.Property(e => e.ChisothapNam).HasMaxLength(20);

				entity.Property(e => e.ChisothapNu).HasMaxLength(20);

				entity.Property(e => e.DonViDo).HasMaxLength(30);

				entity.Property(e => e.Ghichu).HasMaxLength(300);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaDv)
					.IsRequired()
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.Maxn)
					.HasColumnName("MAXN")
					.HasMaxLength(50);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenCs)
					.IsRequired()
					.HasColumnName("TenCS")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmdichVuLoaiHinh>(entity =>
			{
				entity.HasKey(e => e.MaLh);

				entity.ToTable("DMDichVu_LoaiHinh");

				entity.Property(e => e.MaLh)
					.HasColumnName("MaLH")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaChungLoai)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenLh)
					.IsRequired()
					.HasColumnName("TenLH")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmdichVuNhom>(entity =>
			{
				entity.HasKey(e => e.MaNhomdv)
					.HasName("PK_DMDMNHOMDV");

				entity.ToTable("DMDichVu_Nhom");

				entity.Property(e => e.MaNhomdv)
					.HasColumnName("MaNHOMDV")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenNhomdv)
					.IsRequired()
					.HasColumnName("TenNHOMDV")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmdichvuNhomInChiDinh>(entity =>
			{
				entity.HasKey(e => e.Stt);

				entity.ToTable("DMDichvu_NhomInChiDinh");

				entity.Property(e => e.Stt)
					.HasColumnName("STT")
					.HasColumnType("numeric(4, 0)");

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaPhieu).HasMaxLength(50);

				entity.Property(e => e.Ngayhuy).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.Sttin)
					.HasColumnName("STTIn")
					.HasColumnType("numeric(4, 0)");

				entity.Property(e => e.TenPhieu).HasMaxLength(150);
			});

			modelBuilder.Entity<DmdichvuPhanLoaiPttt>(entity =>
			{
				entity.HasKey(e => e.MaPlpttt);

				entity.ToTable("DMDichvu_PhanLoaiPTTT");

				entity.Property(e => e.MaPlpttt)
					.HasColumnName("MaPLPTTT")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.TenPlpttt)
					.IsRequired()
					.HasColumnName("TenPLPTTT")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmdoiTuong>(entity =>
			{
				entity.HasKey(e => e.MaDt);

				entity.ToTable("DMDoiTuong");

				entity.Property(e => e.MaDt)
					.HasColumnName("MaDT")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.NgayHuy)
					.HasColumnName("NgayHuy")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy)
					.HasColumnName("NguoiHuy")
					.HasMaxLength(50);

				entity.Property(e => e.TenDt)
					.IsRequired()
					.HasColumnName("TenDT")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<DmhuongDt>(entity =>
			{
				entity.HasKey(e => e.MaHdt);

				entity.ToTable("DMHuongDT");

				entity.Property(e => e.MaHdt)
					.HasColumnName("MaHDT")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Loai).HasColumnName("LOAI");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenHdt)
					.IsRequired()
					.HasColumnName("TenHDT")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<Dmkhoa>(entity =>
			{
				entity.HasKey(e => e.MaKhoa)
					.HasName("PK__DMKhoa__653904056586CBFB");

				entity.ToTable("DMKhoa");

				entity.Property(e => e.MaKhoa)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.DiaDiem).HasMaxLength(350);

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.MaByt)
					.HasColumnName("MaBYT")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNvdieuDuongTruong)
					.HasColumnName("MaNVDieuDuongTruong")
					.HasMaxLength(200);

				entity.Property(e => e.MaNvtruongKhoa)
					.HasColumnName("MaNVTruongKhoa")
					.HasMaxLength(200);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Sogiuong).HasColumnType("numeric(4, 0)");

				entity.Property(e => e.TenKhoa)
					.IsRequired()
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmkhoaB>(entity =>
			{
				entity.HasKey(e => e.MaKhoa)
					.HasName("PK__DMKhoa__653904056586CBFA");

				entity.ToTable("DMKhoaB");

				entity.Property(e => e.MaKhoa)
					.HasMaxLength(9)
					.ValueGeneratedNever();

				entity.Property(e => e.DiaDiem).HasMaxLength(350);

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.KhoaNt)
					.HasColumnName("KhoaNT")
					.HasMaxLength(50);

				entity.Property(e => e.KhongHd).HasColumnName("KhongHD");

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(8);

				entity.Property(e => e.MaKho).HasMaxLength(5);

				entity.Property(e => e.MaKhoThuoc).HasMaxLength(5);

				entity.Property(e => e.MaKhoaBc)
					.HasColumnName("MaKhoaBC")
					.HasMaxLength(9);

				entity.Property(e => e.MaKhoaQl)
					.HasColumnName("MaKhoaQL")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNhom).HasMaxLength(9);

				entity.Property(e => e.Mabyte)
					.HasColumnName("mabyte")
					.HasMaxLength(200);

				entity.Property(e => e.Machuyenkhoa).HasMaxLength(5);

				entity.Property(e => e.Manvtruongkhoa)
					.HasColumnName("manvtruongkhoa")
					.HasMaxLength(200);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.Sogiuong).HasColumnType("numeric(4, 0)");

				entity.Property(e => e.TenKhoa)
					.IsRequired()
					.HasMaxLength(150);

				entity.Property(e => e.TenTa)
					.HasColumnName("TenTA")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmkhoaBuong>(entity =>
			{
				entity.HasKey(e => new { e.MaBuong, e.MaKhoa });

				entity.ToTable("DMKhoa_Buong");

				entity.Property(e => e.MaBuong)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaKhoa)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenBuong)
					.IsRequired()
					.HasMaxLength(250);

				entity.HasOne(b => b.Dmkhoa)
					.WithMany(d => d.DmkhoaBuongs)
					.HasForeignKey(b => b.MaKhoa)
					.HasPrincipalKey(d => d.MaKhoa);
			});

			modelBuilder.Entity<DmkhoaGiuong>(entity =>
			{
				entity.HasKey(e => new { e.MaGiuong, e.MaBuong, e.MaKhoa });

				entity.ToTable("DMKhoa_Giuong");

				entity.Property(e => e.MaGiuong)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaBuong).HasMaxLength(50);

				entity.Property(e => e.MaKhoa).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenGiuong).HasMaxLength(250);

				entity.HasOne(kg => kg.DmkhoaBuong)
					.WithMany(kb => kb.DmkhoaGiuongs)
					.HasForeignKey(fk => new { fk.MaBuong, fk.MaKhoa })
					.HasPrincipalKey(pk => new { pk.MaBuong, pk.MaKhoa });
			});

			modelBuilder.Entity<DmloaiBa>(entity =>
			{
				entity.HasKey(e => e.MaLoaiBa);

				entity.ToTable("DMLoaiBA");

				entity.Property(e => e.MaLoaiBa).HasColumnName("MaLoaiBA");

				entity.Property(e => e.MaMay).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenLoaiBa)
					.HasColumnName("TenLoaiBA")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmloaiHd>(entity =>
			{
				entity.HasKey(e => e.MaLoaiHd);

				entity.ToTable("DMLoaiHD");

				entity.Property(e => e.MaLoaiHd)
					.HasColumnName("MaLoaiHD")
					.HasMaxLength(5)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenLoaiHd)
					.IsRequired()
					.HasColumnName("TenLoaiHD")
					.HasMaxLength(150);
			});
			modelBuilder.Entity<DmngheNghiep>(entity =>
			{
				entity.HasKey(e => e.MaNn);

				entity.ToTable("DMNgheNghiep");

				entity.Property(e => e.MaNn)
					.HasColumnName("MaNN")
					.HasMaxLength(3)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenNn)
					.IsRequired()
					.HasColumnName("TenNN")
					.HasMaxLength(150);

				entity.Property(e => e.TenTat).HasMaxLength(20);
			});

			modelBuilder.Entity<DmnhanVien>(entity =>
			{
				entity.HasKey(e => e.MaNv)
					.HasName("PK_DMNhanVien_1");

				entity.ToTable("DMNhanVien");

				entity.Property(e => e.MaNv)
					.HasColumnName("MaNV")
					.HasMaxLength(6)
					.ValueGeneratedNever();

				entity.Property(e => e.Chuky).HasMaxLength(400);

				entity.Property(e => e.DienThoai).HasMaxLength(255);

				entity.Property(e => e.DienThoaiKhoa).HasMaxLength(15);

				entity.Property(e => e.GhiChu).HasMaxLength(500);

				entity.Property(e => e.HoTen)
					.IsRequired()
					.HasMaxLength(150);

				entity.Property(e => e.Idnhanvien)
					.HasColumnName("idnhanvien")
					.HasMaxLength(30);

				entity.Property(e => e.KhongSd).HasColumnName("KhongSD");

				entity.Property(e => e.MaCd)
					.HasColumnName("MaCD")
					.HasMaxLength(5);

				entity.Property(e => e.MaChucVu).HasMaxLength(4);

				entity.Property(e => e.MaChungChiHanhNghe).HasMaxLength(255);

				entity.Property(e => e.MaChuyenMon).HasMaxLength(15);

				entity.Property(e => e.MaKhoa).HasMaxLength(6);

				entity.Property(e => e.MaLoaiHd)
					.HasColumnName("MaLoaiHD")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaQl).HasColumnName("MaQL");

				entity.Property(e => e.Manv1)
					.HasColumnName("manv1")
					.HasMaxLength(50);

				entity.Property(e => e.Manvtruongkhoa)
					.HasColumnName("manvtruongkhoa")
					.HasMaxLength(200);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgaySd1)
					.HasColumnName("NgaySD1")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiGiamHo).HasMaxLength(255);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.NguoiSd1)
					.HasColumnName("NguoiSD1")
					.HasMaxLength(6);

				entity.Property(e => e.TenTat).HasMaxLength(50);

				entity.HasOne(b => b.Dmkhoa)
					.WithMany(d => d.DmnhanViens)
					.HasForeignKey(fk => fk.MaKhoa)
					.HasPrincipalKey(pk => pk.MaKhoa);
			});

			modelBuilder.Entity<Dmnhom>(entity =>
			{
				entity.HasKey(e => e.MaNhom);

				entity.ToTable("DMNhom");

				entity.Property(e => e.MaNhom)
					.HasMaxLength(9)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaIcdnhom)
					.HasColumnName("MaICDNhom")
					.HasMaxLength(100);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNhomIcd)
					.HasColumnName("MaNhomICD")
					.HasMaxLength(100);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(6);

				entity.Property(e => e.NguoiLap).HasMaxLength(6);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenNhom)
					.IsRequired()
					.HasMaxLength(150);

				entity.Property(e => e.TenTa)
					.HasColumnName("TenTA")
					.HasMaxLength(150);
			});

			modelBuilder.Entity<DmphauThuat>(entity =>
			{
				entity.HasKey(e => e.MaPt);

				entity.ToTable("DMPhauThuat");

				entity.Property(e => e.MaPt)
					.HasColumnName("MaPT")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(300);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByt)
					.HasColumnName("MaBYT")
					.HasMaxLength(50);

				entity.Property(e => e.MaChungloai)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNhomdv)
					.IsRequired()
					.HasColumnName("MaNHOMDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaPlpttt)
					.IsRequired()
					.HasColumnName("MaPLPTTT")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenByt)
					.HasColumnName("TenBYT")
					.HasMaxLength(1000);

				entity.Property(e => e.TenPt)
					.IsRequired()
					.HasColumnName("TenPT")
					.HasMaxLength(1000);

				entity.Property(e => e.TenTat).HasMaxLength(20);
			});

			modelBuilder.Entity<DmphuongXa>(entity =>
			{
				entity.HasKey(e => e.MaPxa);

				entity.ToTable("DmPhuongXa");

				entity.Property(e => e.MaPxa)
					.HasColumnName("MaPXa")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.MaQh)
					.IsRequired()
					.HasColumnName("MaQH")
					.HasMaxLength(50);

				entity.Property(e => e.TenPxa)
					.IsRequired()
					.HasColumnName("TenPXa")
					.HasMaxLength(150);

				entity.Property(e => e.MaBhxh)
					.HasColumnName("MaBHXH")
					.HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhth)
					.HasColumnName("MaKHTH")
					.HasMaxLength(50);

				entity.Property(e => e.Matat)
						.HasMaxLength(20);

				entity.HasOne(px => px.DmquanHuyen)
					.WithMany(qh => qh.DmphuongXas)
					.HasForeignKey(fk => fk.MaQh);
			});

			modelBuilder.Entity<DmquanHuyen>(entity =>
			{
				entity.HasKey(e => e.MaQh);

				entity.ToTable("DmQuanHuyen");

				entity.Property(e => e.MaQh)
					.HasColumnName("MaQH")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.MaTinh)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.TenQh)
					.IsRequired()
					.HasColumnName("TenQH")
					.HasMaxLength(150);

				entity.Property(e => e.MaBhxh)
					.HasColumnName("MaBHXH")
					.HasMaxLength(50);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhth)
					.HasColumnName("MaKHTH")
					.HasMaxLength(50);

				entity.Property(e => e.Matat)
					.HasMaxLength(20);

				entity.HasOne(qh => qh.Dmtinh)
					.WithMany(t => t.DmquanHuyens)
					.HasForeignKey(fk => fk.MaTinh);
			});

			modelBuilder.Entity<DmquocGia>(entity =>
			{
				entity.HasKey(e => e.MaQg);

				entity.ToTable("DMQuocGia");

				entity.Property(e => e.MaQg)
					.HasColumnName("MaQG")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenQg)
					.IsRequired()
					.HasColumnName("TenQG")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<Dmthuoc>(entity =>
			{
				entity.HasKey(e => e.MaThuoc)
					.HasName("PK_DMThuoc_1");

				entity.ToTable("DMThuoc");

				entity.Property(e => e.MaThuoc)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.HamLuong).HasMaxLength(500);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByt)
					.HasColumnName("MaBYT")
					.HasMaxLength(500);

				entity.Property(e => e.MaChungLoai)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaDangBaoChe).HasMaxLength(50);

				entity.Property(e => e.MaDuongDung)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaDvt)
					.IsRequired()
					.HasColumnName("MaDVT")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNhom)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.MaNsx)
					.HasColumnName("MaNSX")
					.HasMaxLength(50);

				entity.Property(e => e.MaPl)
					.IsRequired()
					.HasColumnName("MaPL")
					.HasMaxLength(50);

				entity.Property(e => e.MaQg)
					.HasColumnName("MaQG")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgaySd1)
					.HasColumnName("NgaySD1")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiSd1)
					.HasColumnName("NguoiSD1")
					.HasMaxLength(50);

				entity.Property(e => e.SoDangKy).HasMaxLength(100);

				entity.Property(e => e.TenByt)
					.HasColumnName("TenBYT")
					.HasMaxLength(500);

				entity.Property(e => e.TenGoc).HasMaxLength(1000);

				entity.Property(e => e.TenTm)
					.IsRequired()
					.HasColumnName("TenTM")
					.HasMaxLength(500);

				entity.HasOne(b => b.DmthuocDonvitinh)
					.WithMany(d => d.Dmthuocs)
					.HasForeignKey(b => b.MaDvt)
					.HasPrincipalKey(d => d.MaDvt);

				entity.HasOne(b => b.DmthuocDuongDung)
				  .WithMany(d => d.Dmthuocs)
				  .HasForeignKey(b => b.MaDuongDung)
				  .HasPrincipalKey(d => d.MaDuongDung);

				entity.HasOne(b => b.DmquocGia)
				  .WithMany(d => d.Dmthuocs)
				  .HasForeignKey(b => b.MaQg)
				  .HasPrincipalKey(d => d.MaQg);

				entity.HasOne(b => b.DmNguoiLap)
				  .WithMany(d => d.DmthuocNguoiLaps)
				  .HasForeignKey(b => b.NguoiLap)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiHuy)
				  .WithMany(d => d.DmthuocNguoiHuys)
				  .HasForeignKey(b => b.NguoiHuy)
				  .HasPrincipalKey(d => d.MaNv);

				entity.HasOne(b => b.DmNguoiSD)
				   .WithMany(d => d.DmthuocNguoiSDs)
				   .HasForeignKey(b => b.NguoiSd)
				   .HasPrincipalKey(d => d.MaNv);
			});

			modelBuilder.Entity<DmthuocBaiThuoc>(entity =>
			{
				entity.HasKey(e => e.MaBthuoc);

				entity.ToTable("DMThuoc_BaiThuoc");

				entity.Property(e => e.MaBthuoc)
					.HasColumnName("MaBThuoc")
					.HasMaxLength(8)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.Loai).HasColumnName("loai");

				entity.Property(e => e.MaBs)
					.HasColumnName("MaBS")
					.HasMaxLength(150);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenBthuoc)
					.IsRequired()
					.HasColumnName("TenBThuoc")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmthuocBaiThuocC>(entity =>
			{
				entity.HasKey(e => new { e.MaBthuoc, e.Stt })
					.HasName("PK_DMThuoc_BaiThuoc_C");

				entity.ToTable("DMThuoc_BaiThuoc_C");

				entity.Property(e => e.MaBthuoc).HasMaxLength(8);

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.MaThuoc).HasMaxLength(6);

				entity.Property(e => e.Soluong)
					.HasColumnType("numeric(8, 2)")
					.HasDefaultValueSql("((1))");

				entity.Property(e => e.LieuDung).HasMaxLength(250);

				entity.Property(e => e.CachDung).HasMaxLength(250);

				entity.Property(e => e.Ghichu).HasMaxLength(300);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.HasOne(b => b.Dmthuoc)
					.WithMany(d => d.DmthuocBaiThuocCs)
					.HasForeignKey(b => b.MaThuoc)
					.HasPrincipalKey(d => d.MaThuoc);
			});

			modelBuilder.Entity<DmthuocChungloai>(entity =>
			{
				entity.HasKey(e => e.MaChungLoai);

				entity.ToTable("DMTHUOC_CHUNGLOAI");

				entity.Property(e => e.MaChungLoai)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenChungLoai)
					.IsRequired()
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmthuocDangBaoChe>(entity =>
			{
				entity.HasKey(e => e.MaDangBaoChe);

				entity.ToTable("DMThuoc_DangBaoChe");

				entity.Property(e => e.MaDangBaoChe)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenDangBaoChe)
					.IsRequired()
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmthuocDonvitinh>(entity =>
			{
				entity.HasKey(e => e.MaDvt);

				entity.ToTable("DMThuoc_Donvitinh");

				entity.Property(e => e.MaDvt)
					.HasColumnName("MaDVT")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenDvt)
					.IsRequired()
					.HasColumnName("TenDVT")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmthuocDuongDung>(entity =>
			{
				entity.HasKey(e => e.MaDuongDung);

				entity.ToTable("DMThuoc_DuongDung");

				entity.Property(e => e.MaDuongDung)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenDuongDung)
					.IsRequired()
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmthuocNhaSx>(entity =>
			{
				entity.HasKey(e => e.MaNsx);

				entity.ToTable("DMThuoc_NhaSX");

				entity.Property(e => e.MaNsx)
					.HasColumnName("MaNSX")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaQg)
					.HasColumnName("MaQG")
					.HasMaxLength(50);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenNsx)
					.IsRequired()
					.HasColumnName("TenNSX")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmthuocNhom>(entity =>
			{
				entity.HasKey(e => e.MaNhom);

				entity.ToTable("DMThuoc_Nhom");

				entity.Property(e => e.MaNhom)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenNhom)
					.IsRequired()
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmthuocPhanLoai>(entity =>
			{
				entity.HasKey(e => e.MaPl);

				entity.ToTable("DMThuoc_PhanLoai");

				entity.Property(e => e.MaPl)
					.HasColumnName("MaPL")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenPl)
					.IsRequired()
					.HasColumnName("TenPL")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<Dmtinh>(entity =>
					 {
						 entity.HasKey(e => e.MaTinh);

						 entity.ToTable("DMTinh");

						 entity.Property(e => e.MaTinh)
							 .HasMaxLength(50)
							 .ValueGeneratedNever();

						 entity.Property(e => e.MaQu)
							 .HasColumnName("MaQU")
							 .HasMaxLength(6);

						 entity.Property(e => e.MaVungLt)
							 .IsRequired()
							 .HasColumnName("MaVungLT")
							 .HasMaxLength(3);

						 entity.Property(e => e.TenTinh)
							 .IsRequired()
							 .HasMaxLength(150);

						 entity.Property(e => e.MaBhyt)
							 .HasColumnName("MaBHYT")
							 .HasMaxLength(50);

						 entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

						 entity.Property(e => e.MaMay).HasMaxLength(20);

						 entity.Property(e => e.NgaySd)
							 .HasColumnName("NgaySD")
							 .HasColumnType("datetime");

						 entity.Property(e => e.NguoiSd)
							 .IsRequired()
							 .HasColumnName("NguoiSD")
							 .HasMaxLength(50);

						 entity.Property(e => e.Matat)
							  .HasMaxLength(20);
					 });

			modelBuilder.Entity<Dmvtyt>(entity =>
			{
				entity.HasKey(e => e.MaVt)
					.HasName("PK_DMVT");

				entity.ToTable("DMVTYT");

				entity.Property(e => e.MaVt)
					.HasColumnName("MaVT")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(300);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaByt)
					.HasColumnName("MaBYT")
					.HasMaxLength(50);

				entity.Property(e => e.MaDvt)
					.IsRequired()
					.HasColumnName("MaDVT")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNhom).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenByt)
					.HasColumnName("TenBYT")
					.HasMaxLength(250);

				entity.Property(e => e.TenTm)
					.IsRequired()
					.HasColumnName("TenTM")
					.HasMaxLength(350);
			});

			modelBuilder.Entity<DmvtytDonvitinh>(entity =>
			{
				entity.HasKey(e => e.MaDvt);

				entity.ToTable("DMVTYT_Donvitinh");

				entity.Property(e => e.MaDvt)
					.HasColumnName("MaDVT")
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Ghichu).HasMaxLength(200);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenDvt)
					.IsRequired()
					.HasColumnName("TenDVT")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DmvtytNhom>(entity =>
			{
				entity.HasKey(e => e.MaNhom);

				entity.ToTable("DMVTYT_Nhom");

				entity.Property(e => e.MaNhom)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenNhom)
					.IsRequired()
					.HasMaxLength(250);
			});

			modelBuilder.Entity<DotDieuTri>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.SoPhieu, e.LoaiBa });

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.SoPhieu).HasMaxLength(50);

				entity.Property(e => e.LoaiBa).HasColumnName("LoaiBA");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.DoiTuong).HasMaxLength(50);

				entity.Property(e => e.KhamBenh).HasMaxLength(500);

				entity.Property(e => e.Kq)
					.HasColumnName("KQ")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Ppdt)
					.HasColumnName("PPDT")
					.HasMaxLength(250);

				entity.Property(e => e.XuTri).HasMaxLength(500);
			});

			modelBuilder.Entity<FilePhiCauTruc>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba, e.LoaiTaiLieu });

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TaiLiieuDinhKem).HasMaxLength(500);
			});

			modelBuilder.Entity<GiayChuyenTuyen>(entity =>
			{
				entity.HasKey(e => new { e.So, e.Idba });

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.ChanDoan).HasMaxLength(50);

				entity.Property(e => e.DauHieuLamSang).HasMaxLength(500);

				entity.Property(e => e.DiaChi).HasMaxLength(500);

				entity.Property(e => e.KhamDn1)
					.HasColumnName("KhamDN1")
					.HasColumnType("datetime");

				entity.Property(e => e.KhamDn2)
					.HasColumnName("KhamDN2")
					.HasColumnType("datetime");

				entity.Property(e => e.KhamTn1)
					.HasColumnName("KhamTN1")
					.HasColumnType("datetime");

				entity.Property(e => e.KhamTn2)
					.HasColumnName("KhamTN2")
					.HasColumnType("datetime");

				entity.Property(e => e.Kqxn)
					.HasColumnName("KQXN")
					.HasMaxLength(500);

				entity.Property(e => e.LyDoChuyen).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa1).HasMaxLength(50);

				entity.Property(e => e.MaKhoa2).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNoiChuyenDen).HasMaxLength(50);

				entity.Property(e => e.NgayChuyen).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiDuyet).HasMaxLength(50);

				entity.Property(e => e.NguoiHoTong).HasMaxLength(50);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.PhuongTien).HasMaxLength(50);

				entity.Property(e => e.SoLuuTru).HasMaxLength(50);

				entity.Property(e => e.TinhTrangBnchuyenTuyen)
					.HasColumnName("TinhTrangBNChuyenTuyen")
					.HasMaxLength(250);

				entity.Property(e => e.TtthuocDaSuDung).HasColumnName("TTThuocDaSuDung");

				entity.Property(e => e.TuyenKhoa).HasMaxLength(50);

				entity.Property(e => e.TuyenKhoa1).HasMaxLength(50);

				entity.Property(e => e.VaoSoChuyenTuyen).HasMaxLength(50);
			});

			modelBuilder.Entity<GiayCnphauThuat>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("GiayCNPhauThuat");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BenhVienThu).HasMaxLength(50);

				entity.Property(e => e.BskhamThu)
					.HasColumnName("BSKhamThu")
					.HasMaxLength(50);

				entity.Property(e => e.CachThucPt)
					.HasColumnName("CachThucPT")
					.HasMaxLength(250);

				entity.Property(e => e.DaPt)
					.HasColumnName("DaPT")
					.HasMaxLength(50);

				entity.Property(e => e.GhiChuThu).HasMaxLength(50);

				entity.Property(e => e.GiamDoc).HasMaxLength(50);

				entity.Property(e => e.Kqthu)
					.HasColumnName("KQThu")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKhamThu).HasMaxLength(50);

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhomMau).HasMaxLength(50);

				entity.Property(e => e.NoiKhamThu).HasMaxLength(50);

				entity.Property(e => e.RaNgayThu).HasMaxLength(50);

				entity.Property(e => e.Rh)
					.HasColumnName("RH")
					.HasMaxLength(50);

				entity.Property(e => e.TruongKhoa).HasMaxLength(50);

				entity.Property(e => e.VaoNgayThu).HasMaxLength(50);

				entity.Property(e => e.ViTriPt)
					.HasColumnName("ViTriPT")
					.HasMaxLength(250);
			});

			modelBuilder.Entity<KetQuaXetNghiem>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Sttkq, e.Idba });

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Sttkq).HasColumnName("STTKQ");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BatThuong).HasMaxLength(150);

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.Csbt)
					.HasColumnName("CSBT")
					.HasMaxLength(50);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.Kq).HasColumnName("KQ");

				entity.Property(e => e.Kqxn).HasColumnName("KQXN");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaCs)
					.HasColumnName("MaCS")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MayTh)
					.HasColumnName("MayTH")
					.HasMaxLength(50);

				entity.Property(e => e.NgayChiDinh)
					.HasColumnName("NgayChiDInh")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKyKq)
					.HasColumnName("NgayKyKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgayLayMau).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTraKq)
					.HasColumnName("NgayTraKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.TenCs)
					.HasColumnName("TenCS")
					.HasMaxLength(250);

				entity.Property(e => e.TruongKhoaXn)
					.HasColumnName("TruongKhoaXN")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Menu>(entity =>
			{
				entity.Property(e => e.MenuId)
					.HasMaxLength(128)
					.ValueGeneratedNever();

				entity.Property(e => e.MenuName).HasMaxLength(128);

				entity.Property(e => e.MenuParent).HasMaxLength(128);

				entity.HasOne(d => d.ApplicationAction)
					.WithMany(p => p.Menu)
					.HasForeignKey(d => d.ApplicationActionId)
					.HasConstraintName("FK_Menu_ApplicationAction");
				entity.HasOne(e => e.Parent)
					.WithMany(e => e.Children)
					.HasForeignKey(e => e.MenuParent);
			});

			modelBuilder.Entity<PhacDo>(entity =>
			{
				entity.HasKey(e => e.MaPhacDo);

				entity.Property(e => e.MaPhacDo)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.GiaiDoan).HasMaxLength(500);

				entity.Property(e => e.MaBenh).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MoTa).HasMaxLength(500);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SauPhacDo).HasMaxLength(500);

				entity.Property(e => e.TruocPhacDo).HasMaxLength(500);

				entity.Property(e => e.VungApDung).HasMaxLength(500);

				entity.Property(e => e.XuTri).HasMaxLength(500);
			});

			modelBuilder.Entity<PhieuChamSoc>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.SoPhieu });

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.SoPhieu).HasMaxLength(50);

				entity.Property(e => e.AnUong).HasMaxLength(50);

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CapCs).HasColumnName("CapCS");

				entity.Property(e => e.ChamSocKhac).HasMaxLength(250);

				entity.Property(e => e.ChanDanLuu).HasMaxLength(50);

				entity.Property(e => e.ChanDoan).HasMaxLength(250);

				entity.Property(e => e.ChuyenKhoa).HasMaxLength(50);

				entity.Property(e => e.CoXuongKhop).HasMaxLength(50);

				entity.Property(e => e.DaNiemMac).HasMaxLength(50);

				entity.Property(e => e.DaiTien).HasMaxLength(50);

				entity.Property(e => e.DanLuu).HasMaxLength(50);

				entity.Property(e => e.DauBung).HasMaxLength(50);

				entity.Property(e => e.DauNguc).HasMaxLength(50);

				entity.Property(e => e.Ddkhac)
					.HasColumnName("DDKhac")
					.HasMaxLength(250);

				entity.Property(e => e.DdthucHien)
					.HasColumnName("DDThucHien")
					.HasMaxLength(50);

				entity.Property(e => e.DienBien).HasMaxLength(250);

				entity.Property(e => e.DienBienKhac).HasMaxLength(500);

				entity.Property(e => e.DinhDuong).HasMaxLength(50);

				entity.Property(e => e.Gdsk)
					.HasColumnName("GDSK")
					.HasMaxLength(50);

				entity.Property(e => e.Ho).HasMaxLength(50);

				entity.Property(e => e.HoHap).HasMaxLength(50);

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoa).HasMaxLength(50);

				entity.Property(e => e.MauSacSondeDd)
					.HasColumnName("MauSacSondeDD")
					.HasMaxLength(50);

				entity.Property(e => e.MauSacSondeTieu).HasMaxLength(50);

				entity.Property(e => e.MauSacTieuChay).HasMaxLength(150);

				entity.Property(e => e.MoTaDanLuu).HasMaxLength(250);

				entity.Property(e => e.MoTaVetThuong).HasMaxLength(250);

				entity.Property(e => e.NgayChamSoc).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.Ngu).HasMaxLength(50);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhietDo).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.Phu).HasMaxLength(50);

				entity.Property(e => e.SlkhiDung).HasColumnName("SLKhiDung");

				entity.Property(e => e.Sloxy).HasColumnName("SLOxy");

				entity.Property(e => e.SltestMm).HasColumnName("SLTestMM");

				entity.Property(e => e.SltiemInsulin).HasColumnName("SLTiemInsulin");

				entity.Property(e => e.SoLuongSondeDd).HasColumnName("SoLuongSondeDD");

				entity.Property(e => e.Sot).HasMaxLength(50);

				entity.Property(e => e.SpO2).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.TanSoHo).HasMaxLength(50);

				entity.Property(e => e.TchatTim)
					.HasColumnName("TChatTim")
					.HasMaxLength(50);

				entity.Property(e => e.ThanKinhVanDong).HasMaxLength(50);

				entity.Property(e => e.TheRrang).HasMaxLength(50);

				entity.Property(e => e.TheoDoiDhst).HasColumnName("TheoDoiDHST");

				entity.Property(e => e.ThuThuat).HasMaxLength(500);

				entity.Property(e => e.ThucHienYlenh)
					.HasColumnName("ThucHienYLenh")
					.HasMaxLength(500);

				entity.Property(e => e.ThylenhKhac)
					.HasColumnName("THYLenhKhac")
					.HasMaxLength(500);

				entity.Property(e => e.TiepXuc).HasMaxLength(50);

				entity.Property(e => e.TietNieu).HasMaxLength(50);

				entity.Property(e => e.TieuHoa).HasMaxLength(50);

				entity.Property(e => e.TimMach).HasMaxLength(50);

				entity.Property(e => e.TinhChatTkvd)
					.HasColumnName("TinhChatTKVD")
					.HasMaxLength(50);

				entity.Property(e => e.TonThuongDa).HasMaxLength(50);

				entity.Property(e => e.VanDong).HasMaxLength(50);

				entity.Property(e => e.VeSinhCaNhan).HasMaxLength(50);

				entity.Property(e => e.VetThuong).HasMaxLength(50);

				entity.Property(e => e.VetThuongKhac).HasMaxLength(50);

				entity.Property(e => e.ViTriDauBung).HasMaxLength(50);

				entity.Property(e => e.Ylenh)
					.HasColumnName("YLenh")
					.HasMaxLength(250);

				entity.Property(e => e.Ythuc)
					.HasColumnName("YThuc")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<PhieuChanDoanNntuVong>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.SoPhieu })
					.HasName("PK_GiayTuVong");

				entity.ToTable("PhieuChanDoanNNTuVong");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.SoPhieu).HasMaxLength(50);

				entity.Property(e => e.CanNang).HasMaxLength(50);

				entity.Property(e => e.ChuSinh).HasMaxLength(500);

				entity.Property(e => e.GioSongSauSinh).HasMaxLength(50);

				entity.Property(e => e.HinhThucTv).HasColumnName("HinhThucTV");

				entity.Property(e => e.Kntt).HasColumnName("KNTT");

				entity.Property(e => e.LyDoPt)
					.HasColumnName("LyDoPT")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNntv)
					.HasColumnName("MaNNTV")
					.HasMaxLength(50);

				entity.Property(e => e.MangThaiGayTv).HasColumnName("MangThaiGayTV");

				entity.Property(e => e.MoTaNguyenNhanChanThuong).HasMaxLength(500);

				entity.Property(e => e.NgayCap).HasColumnType("datetime");

				entity.Property(e => e.NgayChanThuong).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgayPhauThuat).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTv)
					.HasColumnName("NgayTV")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiLap).HasMaxLength(6);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.NguyenNhan2).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanA).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanB).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanC).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanChanThuong).HasMaxLength(500);

				entity.Property(e => e.NguyenNhanD).HasMaxLength(500);

				entity.Property(e => e.NoiTv)
					.HasColumnName("NoiTV")
					.HasMaxLength(100);

				entity.Property(e => e.QuyenSo).HasMaxLength(50);

				entity.Property(e => e.QuyenSoLanDau).HasMaxLength(50);

				entity.Property(e => e.Sdkq).HasColumnName("SDKQ");

				entity.Property(e => e.SoGiayBaoTu).HasMaxLength(50);

				entity.Property(e => e.SoGiayBaoTuLanDau).HasMaxLength(50);

				entity.Property(e => e.SoTuanMangThai).HasMaxLength(50);

				entity.Property(e => e.TenNntv)
					.HasColumnName("TenNNTV")
					.HasMaxLength(500);

				entity.Property(e => e.ThoiGian2).HasMaxLength(100);

				entity.Property(e => e.ThoiGianA).HasMaxLength(100);

				entity.Property(e => e.ThoiGianB).HasMaxLength(100);

				entity.Property(e => e.ThoiGianC).HasMaxLength(100);

				entity.Property(e => e.ThoiGianD).HasMaxLength(100);

				entity.Property(e => e.TuoiMe).HasMaxLength(50);

				entity.Property(e => e.Tvcc).HasColumnName("TVCC");
			});

			modelBuilder.Entity<PhieuChupCht>(entity =>
			{
				entity.HasKey(e => new { e.So, e.LanThu, e.Idba });

				entity.ToTable("PhieuChupCHT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.BschuyenKhoa)
					.HasColumnName("BSChuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.CoDiVatKimLoai).HasMaxLength(250);

				entity.Property(e => e.DoiTuong).HasMaxLength(150);

				entity.Property(e => e.KetLuan).HasMaxLength(500);

				entity.Property(e => e.KqcdhadaCo)
					.HasColumnName("KQCDHADaCo")
					.HasMaxLength(250);

				entity.Property(e => e.KyThuat).HasMaxLength(250);

				entity.Property(e => e.LinkPacs)
					.HasColumnName("LinkPACS")
					.HasMaxLength(250);

				entity.Property(e => e.LoiDan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaMayThucHien).HasMaxLength(50);

				entity.Property(e => e.MoTa).HasMaxLength(500);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKq)
					.HasColumnName("NgayKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTiepNhan).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.ViTri).HasMaxLength(250);

				entity.Property(e => e.YeuCau).HasMaxLength(250);
			});

			modelBuilder.Entity<PhieuChupXquang>(entity =>
			{
				entity.HasKey(e => new { e.So, e.LanThu, e.Idba });

				entity.ToTable("PhieuChupXQuang");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.BschuyenKhoa)
					.HasColumnName("BSChuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.DiUng).HasMaxLength(250);

				entity.Property(e => e.KetLuan).HasMaxLength(500);

				entity.Property(e => e.LinkPacs)
					.HasColumnName("LinkPACS")
					.HasMaxLength(250);

				entity.Property(e => e.LoiDan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaMayThucHien).HasMaxLength(50);

				entity.Property(e => e.MoTa).HasMaxLength(500);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTiepNhan).HasColumnType("datetime");

				entity.Property(e => e.NgayTraKq)
					.HasColumnName("NgayTraKQ")
					.HasMaxLength(500);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.ViTri).HasMaxLength(250);

				entity.Property(e => e.YeuCau).HasMaxLength(250);
			});

			modelBuilder.Entity<PhieuDienNao>(entity =>
			{
				entity.HasKey(e => new { e.So, e.LanThu, e.Idba });

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.BschuyenKhoa)
					.HasColumnName("BSChuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.Kq).HasColumnName("KQ");

				entity.Property(e => e.LoiDan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaMayThucHien).HasMaxLength(50);

				entity.Property(e => e.MoTa).HasMaxLength(350);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHenGhiDienNao).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKyKq)
					.HasColumnName("NgayKyKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.Ttbn)
					.HasColumnName("TTBN")
					.HasMaxLength(500);

				entity.Property(e => e.YeuCau).HasMaxLength(250);
			});

			modelBuilder.Entity<PhieuDienTim>(entity =>
			{
				entity.HasKey(e => new { e.So, e.LanThu, e.Idba });

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.AVf)
					.HasColumnName("aVF")
					.HasMaxLength(50);

				entity.Property(e => e.AVl)
					.HasColumnName("aVL")
					.HasMaxLength(50);

				entity.Property(e => e.AVr)
					.HasColumnName("aVR")
					.HasMaxLength(50);

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.BschuyenKhoa)
					.HasColumnName("BSChuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.ChuyenDaoMau).HasMaxLength(250);

				entity.Property(e => e.Di)
					.HasColumnName("DI")
					.HasMaxLength(50);

				entity.Property(e => e.Dii)
					.HasColumnName("DII")
					.HasMaxLength(50);

				entity.Property(e => e.Diii)
					.HasColumnName("DIII")
					.HasMaxLength(50);

				entity.Property(e => e.Goc).HasMaxLength(50);

				entity.Property(e => e.KetLuan).HasMaxLength(250);

				entity.Property(e => e.LoiDan).HasMaxLength(250);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaMayThucHien).HasMaxLength(50);

				entity.Property(e => e.Mcl1)
					.HasColumnName("MCL1")
					.HasMaxLength(50);

				entity.Property(e => e.Mcl2)
					.HasColumnName("MCL2")
					.HasMaxLength(50);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTiepNhan).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhipTanSo).HasMaxLength(50);

				entity.Property(e => e.P).HasMaxLength(50);

				entity.Property(e => e.Pq)
					.HasColumnName("PQ")
					.HasMaxLength(50);

				entity.Property(e => e.Qrs)
					.HasColumnName("QRS")
					.HasMaxLength(50);

				entity.Property(e => e.Qt)
					.HasColumnName("QT")
					.HasMaxLength(50);

				entity.Property(e => e.St)
					.HasColumnName("ST")
					.HasMaxLength(50);

				entity.Property(e => e.T).HasMaxLength(50);

				entity.Property(e => e.Truc).HasMaxLength(50);

				entity.Property(e => e.TuTheTim).HasMaxLength(50);

				entity.Property(e => e.V1).HasMaxLength(50);

				entity.Property(e => e.V2).HasMaxLength(50);

				entity.Property(e => e.V3).HasMaxLength(50);

				entity.Property(e => e.V4).HasMaxLength(50);

				entity.Property(e => e.V4r)
					.HasColumnName("V4R")
					.HasMaxLength(50);

				entity.Property(e => e.V5).HasMaxLength(50);

				entity.Property(e => e.V6).HasMaxLength(50);

				entity.Property(e => e.YeuCau).HasMaxLength(250);
			});

			modelBuilder.Entity<PhieuDoLoangXuong>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.SoPhieu });

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschuyenKhoa)
					.HasColumnName("BSChuyenKhoa")
					.HasMaxLength(50);

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.DoiTuong).HasMaxLength(50);

				entity.Property(e => e.Kq)
					.HasColumnName("KQ")
					.HasMaxLength(500);

				entity.Property(e => e.LoaiPhieu).HasDefaultValueSql("((0))");

				entity.Property(e => e.LoiDan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaMayThucHien).HasMaxLength(50);

				entity.Property(e => e.MoTa).HasMaxLength(500);

				entity.Property(e => e.NgayChiDinh).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKyKq)
					.HasColumnName("NgayKyKQ")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.YeuCau).HasMaxLength(250);
			});

			modelBuilder.Entity<PhieuHoiChan>(entity =>
			{
				entity.HasKey(e => new { e.So, e.Idba });

				entity.Property(e => e.So).HasMaxLength(50);

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BienBanHoiChan).HasMaxLength(250);

				entity.Property(e => e.ChuToa).HasMaxLength(50);

				entity.Property(e => e.HuongDttiep)
					.HasColumnName("HuongDTTiep")
					.HasMaxLength(500);

				entity.Property(e => e.KetLuan).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoaDt)
					.HasColumnName("MaKhoaDT")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHoiChan).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.ThuKy).HasMaxLength(50);

				entity.Property(e => e.TomTatDienBienBenh).HasMaxLength(500);
			});

			modelBuilder.Entity<PhieuKhamGayMeTruocMo>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.SoPhieu });

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.SoPhieu).HasMaxLength(50);

				entity.Property(e => e.Asa).HasColumnName("ASA");

				entity.Property(e => e.BsgayMeKham)
					.HasColumnName("BSGayMeKham")
					.HasMaxLength(50);

				entity.Property(e => e.BsgayMeThamLaiTruocMo)
					.HasColumnName("BSGayMeThamLaiTruocMo")
					.HasMaxLength(50);

				entity.Property(e => e.BuaAnCuoiTruocMo).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.CanNang).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.ChanDoan).HasMaxLength(250);

				entity.Property(e => e.ChieuCao).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.CotSong).HasMaxLength(250);

				entity.Property(e => e.DiUng).HasMaxLength(250);

				entity.Property(e => e.DuKienCachVoCam).HasMaxLength(250);

				entity.Property(e => e.DuKienGiamDauSauMo).HasMaxLength(250);

				entity.Property(e => e.HaMieng).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.HoHap).HasMaxLength(250);

				entity.Property(e => e.HuongXuTri).HasMaxLength(500);

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.KhamLamSang).HasMaxLength(500);

				entity.Property(e => e.KhoangCachCamGiap).HasColumnType("numeric(8, 2)");

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.Mallampati).HasMaxLength(5);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKham).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayThamLaiTruocMo).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhomMau).HasMaxLength(50);

				entity.Property(e => e.RangGia).HasDefaultValueSql("((0))");

				entity.Property(e => e.ThanKinh).HasMaxLength(250);

				entity.Property(e => e.ThuocDt)
					.HasColumnName("ThuocDT")
					.HasMaxLength(500);

				entity.Property(e => e.TienSuGayMe).HasMaxLength(500);

				entity.Property(e => e.TienSuNgoaiKhoa).HasMaxLength(500);

				entity.Property(e => e.TienSuNoiKhoa).HasMaxLength(500);

				entity.Property(e => e.TuanHoan).HasMaxLength(250);

				entity.Property(e => e.XnbatThuong)
					.HasColumnName("XNBatThuong")
					.HasMaxLength(250);

				entity.Property(e => e.YeuCauBoSung).HasMaxLength(250);

				entity.Property(e => e.YlenhTruocMo)
					.HasColumnName("YLenhTruocMo")
					.HasMaxLength(500);

				entity.Property(e => e.YtaThucHien)
					.HasColumnName("YTaThucHien")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<PhieuKhamVaoVien>(entity =>
			{
				entity.HasKey(e => e.Idba);

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BacSy).HasMaxLength(50);

				entity.Property(e => e.CacBoPhan).HasMaxLength(500);

				entity.Property(e => e.ChanDoanVv)
					.HasColumnName("ChanDoanVV")
					.HasMaxLength(500);

				entity.Property(e => e.ChuY).HasMaxLength(250);

				entity.Property(e => e.DaXuLy).HasMaxLength(50);

				entity.Property(e => e.DoiTuong).HasMaxLength(50);

				entity.Property(e => e.Gtbhytdn)
					.HasColumnName("GTBHYTDN")
					.HasColumnType("datetime");

				entity.Property(e => e.Gtbhyttn)
					.HasColumnName("GTBHYTTN")
					.HasColumnType("datetime");

				entity.Property(e => e.HuyetAp).HasMaxLength(50);

				entity.Property(e => e.KhamToanThan).HasMaxLength(500);

				entity.Property(e => e.LyDoVv)
					.HasColumnName("LyDoVV")
					.HasMaxLength(250);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaCdnoiChuyenDen)
					.HasColumnName("MaCDNoiChuyenDen")
					.HasMaxLength(50);

				entity.Property(e => e.MaKhoaVv)
					.HasColumnName("MaKhoaVV")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKham).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhietDo).HasColumnType("numeric(5, 2)");

				entity.Property(e => e.QuaTrinhBenhLy).HasMaxLength(500);

				entity.Property(e => e.SoTheBhyt)
					.HasColumnName("SoTheBHYT")
					.HasMaxLength(15);

				entity.Property(e => e.TienSuBanThan).HasMaxLength(500);

				entity.Property(e => e.TienSuGiaDinh).HasMaxLength(500);

				entity.Property(e => e.TomTatKqcls)
					.HasColumnName("TomTatKQCLS")
					.HasMaxLength(500);
			});

			modelBuilder.Entity<Pttt>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("PTTT");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Bac).HasMaxLength(50);

				entity.Property(e => e.BsgayMe)
					.HasColumnName("BSGayMe")
					.HasMaxLength(50);

				entity.Property(e => e.Bspt)
					.HasColumnName("BSPT")
					.HasMaxLength(50);

				entity.Property(e => e.ChanDoanSauPt)
					.HasColumnName("ChanDoanSauPT")
					.HasMaxLength(50);

				entity.Property(e => e.ChanDoanTruocPt)
					.HasColumnName("ChanDoanTruocPT")
					.HasMaxLength(50);

				entity.Property(e => e.DanLuu).HasMaxLength(50);

				entity.Property(e => e.Khac).HasMaxLength(500);

				entity.Property(e => e.Loai).HasMaxLength(50);

				entity.Property(e => e.LuocDoPt)
					.HasColumnName("LuocDoPT")
					.HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayCatChi).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgayPt)
					.HasColumnName("NgayPT")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayRutChi).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.PhuongPhap).HasMaxLength(500);

				entity.Property(e => e.PhuongPhapVoCam).HasMaxLength(50);

				entity.Property(e => e.Ptvien)
					.HasColumnName("PTVien")
					.HasMaxLength(50);

				entity.Property(e => e.TrinhTuPt)
					.HasColumnName("TrinhTuPT")
					.HasMaxLength(500);
			});

			modelBuilder.Entity<Roles>(entity =>
			{
				entity.HasKey(e => e.ApplicationRolesId);

				entity.Property(e => e.ApplicationRolesId)
					.HasMaxLength(128)
					.ValueGeneratedNever();

				entity.Property(e => e.GhiChu).HasMaxLength(500);

				entity.Property(e => e.MaMay)
					.IsRequired()
					.HasMaxLength(20);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.IsRequired()
					.HasColumnName("NguoiSD")
					.HasMaxLength(6);

				entity.Property(e => e.TenRole)
					.IsRequired()
					.HasMaxLength(500);
			});

			modelBuilder.Entity<TaiBienPttt>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.ToTable("TaiBienPTTT");

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.CachDung).HasMaxLength(50);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.GhiChu).HasMaxLength(500);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.KetQuaTaiBien).HasMaxLength(500);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaPt)
					.HasColumnName("MaPT")
					.HasMaxLength(50);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.MaTt)
					.HasColumnName("MaTT")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTaiBien).HasColumnType("datetime");

				entity.Property(e => e.NgayThucHien).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguyenNhanTaiBien).HasMaxLength(500);
			});

			modelBuilder.Entity<ThanhVienHc>(entity =>
			{
				entity.HasKey(e => new { e.So, e.Stttv, e.Idba });

				entity.ToTable("ThanhVienHC");

				entity.Property(e => e.So).HasMaxLength(50);

				entity.Property(e => e.Stttv).HasColumnName("STTTV");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.LoaiPhieu).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaChucDanh).HasMaxLength(50);

				entity.Property(e => e.MaChucVu).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNv)
					.HasColumnName("MaNV")
					.HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);
			});

			modelBuilder.Entity<ThongTinBn>(entity =>
			{
				entity.HasKey(e => new { e.MaBn, e.Idba })
					.HasName("PK_ThongTinBN_1");

				entity.ToTable("ThongTinBN");

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.Cmnd)
					.HasColumnName("CMND")
					.HasMaxLength(50);

				entity.Property(e => e.DangKhuyetTat).HasMaxLength(50);

				entity.Property(e => e.DoiTuong).HasMaxLength(50);

				entity.Property(e => e.GiayCnkhuyetTat)
					.HasColumnName("GiayCNKhuyetTat")
					.HasMaxLength(50);

				entity.Property(e => e.Gtbhytdn)
					.HasColumnName("GTBHYTDN")
					.HasColumnType("datetime");

				entity.Property(e => e.Gtbhyttn)
					.HasColumnName("GTBHYTTN")
					.HasColumnType("datetime");

				entity.Property(e => e.HoTen)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.HoTenCha).HasMaxLength(250);

				entity.Property(e => e.HoTenMe).HasMaxLength(250);

				entity.Property(e => e.Huy).HasDefaultValueSql("((0))");

				entity.Property(e => e.LienHe).HasMaxLength(250);

				entity.Property(e => e.MaDanToc).HasMaxLength(50);

				entity.Property(e => e.MaHuyen).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaNgheNghiep).HasMaxLength(50);

				entity.Property(e => e.MaNoiDkbd)
					.HasColumnName("MaNoiDKBD")
					.HasMaxLength(50);

				entity.Property(e => e.MaPxa)
					.HasColumnName("MaPXa")
					.HasMaxLength(50);

				entity.Property(e => e.MaQuocTich).HasMaxLength(50);

				entity.Property(e => e.MaTinh).HasMaxLength(50);

				entity.Property(e => e.MucDoKhuyetTat).HasMaxLength(50);

				entity.Property(e => e.NgayCapCmnd)
					.HasColumnName("NgayCapCMND")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgaySinh).HasColumnType("datetime");

				entity.Property(e => e.NgheNghiepNguoiGiamHo).HasMaxLength(50);

				entity.Property(e => e.NguoiGiamHo).HasMaxLength(500);

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NhomMau).HasMaxLength(50);

				entity.Property(e => e.NoiCapCmnd)
					.HasColumnName("NoiCapCMND")
					.HasMaxLength(150);

				entity.Property(e => e.NoiLamViec).HasMaxLength(250);

				entity.Property(e => e.QuanHeNguoiGiamHo).HasMaxLength(150);

				entity.Property(e => e.Rh).HasMaxLength(50);

				entity.Property(e => e.SoDienThoai).HasMaxLength(50);

				entity.Property(e => e.SoNha).HasMaxLength(50);

				entity.Property(e => e.SoTheBhyt)
					.HasColumnName("SoTheBHYT")
					.HasMaxLength(15);

				entity.Property(e => e.Thon).HasMaxLength(50);

				entity.HasOne(bn => bn.DmngheNghiep)
					.WithMany(nn => nn.ThongTinBns)
					.HasForeignKey(fk => fk.MaNgheNghiep);

				entity.HasOne(bn => bn.DmdanToc)
					.WithMany(dt => dt.ThongTinBns)
					.HasForeignKey(fk => fk.MaDanToc);

				entity.HasOne(bn => bn.DmquocGia)
					.WithMany(qg => qg.ThongTinBns)
					.HasForeignKey(fk => fk.MaQuocTich);

				entity.HasOne(bn => bn.DmphuongXa)
					.WithMany(px => px.ThongTinBns)
					.HasForeignKey(fk => fk.MaPxa);

				entity.HasOne(bn => bn.DmquanHuyen)
					.WithMany(qh => qh.ThongTinBns)
					.HasForeignKey(fk => fk.MaHuyen);

				entity.HasOne(bn => bn.Dmtinh)
					.WithMany(t => t.ThongTinBns)
					.HasForeignKey(fk => fk.MaTinh);

				entity.HasOne(bn => bn.DmdoiTuong)
					.WithMany(d => d.ThongTinBns)
					.HasForeignKey(fk => fk.DoiTuong)
					.HasPrincipalKey(pk => pk.MaDt);
			});

			modelBuilder.Entity<ThuPhanUngThuoc>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.Bsdoc)
					.HasColumnName("BSDoc")
					.HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

				entity.Property(e => e.NgayDoc).HasColumnType("datetime");

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiThu).HasMaxLength(50);

				entity.Property(e => e.PhuongPhapThu).HasMaxLength(500);
			});

			modelBuilder.Entity<ThucHienVltl>(entity =>
			{
				entity.HasKey(e => new { e.Idba, e.SoPhieu });

				entity.ToTable("ThucHienVLTL");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.SoPhieu).HasMaxLength(50);

				entity.Property(e => e.CachDung).HasMaxLength(50);

				entity.Property(e => e.DonVi).HasMaxLength(50);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaDv)
					.HasColumnName("MaDV")
					.HasMaxLength(50);

				entity.Property(e => e.MaThuoc).HasMaxLength(50);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTh)
					.HasColumnName("NgayTH")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NguoiThucHien).HasMaxLength(50);

				entity.Property(e => e.ViTri).HasMaxLength(150);
			});

			modelBuilder.Entity<TokenApi>(entity =>
			{
				entity.ToTable("Token_API");

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.HasColumnType("numeric(38, 0)")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.Account).HasMaxLength(500);

				entity.Property(e => e.NgayCap).HasColumnType("datetime");

				entity.Property(e => e.Token).HasMaxLength(500);
			});

			modelBuilder.Entity<TongKet15Ngay>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BsdieuTri)
					.HasColumnName("BSDieuTri")
					.HasMaxLength(50);

				entity.Property(e => e.DanhGiaKq)
					.HasColumnName("DanhGiaKQ")
					.HasMaxLength(250);

				entity.Property(e => e.DienBienLamSang).HasMaxLength(500);

				entity.Property(e => e.HuongDt)
					.HasColumnName("HuongDT")
					.HasMaxLength(520);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayKyBsdieuTri)
					.HasColumnName("NgayKyBSDieuTri")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayKyTruongKhoa).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.QuaTrinhDt)
					.HasColumnName("QuaTrinhDT")
					.HasMaxLength(500);

				entity.Property(e => e.TruongKhoa).HasMaxLength(50);

				entity.Property(e => e.XnlamSang)
					.HasColumnName("XNLamSang")
					.HasMaxLength(500);
			});

			modelBuilder.Entity<TraceLog>(entity =>
			{
				entity.Property(e => e.Id).HasColumnType("numeric(38, 0)");

				entity.Property(e => e.KieuTacDong).HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(50);

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.NoiDungSd).HasColumnName("NoiDungSD");

				entity.Property(e => e.TenBang).HasMaxLength(50);
			});

			modelBuilder.Entity<TraceLogKieuTacDong>(entity =>
			{
				entity.HasKey(e => e.MaKieu);

				entity.Property(e => e.MaKieu)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.TenKieu).HasMaxLength(250);
			});

			modelBuilder.Entity<TraceLogTableName>(entity =>
			{
				entity.HasKey(e => e.MaBang);

				entity.Property(e => e.MaBang)
					.HasMaxLength(50)
					.ValueGeneratedNever();

				entity.Property(e => e.TenBang).HasMaxLength(250);
			});

			modelBuilder.Entity<TruyenDich>(entity =>
			{
				entity.HasKey(e => new { e.Stt, e.Idba });

				entity.Property(e => e.Stt).HasColumnName("STT");

				entity.Property(e => e.Idba)
					.HasColumnName("IDBA")
					.HasColumnType("numeric(38, 0)");

				entity.Property(e => e.BschiDinh)
					.HasColumnName("BSChiDinh")
					.HasMaxLength(50);

				entity.Property(e => e.DieuDuong).HasMaxLength(50);

				entity.Property(e => e.HamLuong).HasMaxLength(50);

				entity.Property(e => e.MaBa)
					.IsRequired()
					.HasColumnName("MaBA")
					.HasMaxLength(50);

				entity.Property(e => e.MaBn)
					.IsRequired()
					.HasColumnName("MaBN")
					.HasMaxLength(50);

				entity.Property(e => e.MaDichTruyen).HasMaxLength(50);

				entity.Property(e => e.MaMay).HasMaxLength(20);

				entity.Property(e => e.NgayHuy).HasColumnType("datetime");

				entity.Property(e => e.NgayLap).HasColumnType("datetime");

				entity.Property(e => e.NgaySd)
					.HasColumnName("NgaySD")
					.HasColumnType("datetime");

				entity.Property(e => e.NgayTheoDoi).HasColumnType("datetime");

				entity.Property(e => e.NguoiHuy).HasMaxLength(50);

				entity.Property(e => e.NguoiLap).HasMaxLength(50);

				entity.Property(e => e.NguoiSd)
					.HasColumnName("NguoiSD")
					.HasMaxLength(50);

				entity.Property(e => e.SoLo).HasMaxLength(50);

				entity.Property(e => e.ThoiGianBatDau).HasColumnType("datetime");

				entity.Property(e => e.ThoiGianKetThuc).HasColumnType("datetime");

				entity.Property(e => e.TocDo).HasMaxLength(50);
			});
		}
	}
}
