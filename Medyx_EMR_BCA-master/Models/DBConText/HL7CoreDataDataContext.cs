using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.Models.DanhMuc;
using Medyx_EMR_BCA.Models.HSBA;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace Medyx_EMR_BCA.Models.DBConText
{	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name = "MedYX_EMR_BCA")]
	public partial class HL7CoreDataDataContext : System.Data.Linq.DataContext
	{
		private readonly IConfiguration _config;
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        public object MaQU { get; private set; }
        #region Extensibility Method Definitions
        partial void OnCreated();
		#endregion
		public HL7CoreDataDataContext() :
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		public HL7CoreDataDataContext(string connection) :
				base(connection, mappingSource)
		{
			OnCreated();
		}
		public HL7CoreDataDataContext(System.Data.IDbConnection connection) :
				base(connection, mappingSource)
		{
			OnCreated();
		}
		public HL7CoreDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
				base(connection, mappingSource)
		{
			OnCreated();
		}
		public HL7CoreDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
				base(connection, mappingSource)
		{
			OnCreated();
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spACCOUNT_Get")]
		public ISingleResult<spACCOUNT_Get> spACCOUNT_Get([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(100)")] string ACCOUNT)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ACCOUNT);
			return ((ISingleResult<spACCOUNT_Get>)(result.ReturnValue));
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spACCOUNT_ResetPassWord")]
		public int spACCOUNT_ResetPassWord([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string manv, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string Account, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string passwordCu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string password, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), manv, Account, passwordCu,password, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.sp_GetAllMenuByUserID")]
		public IEnumerable<MenuUserVm> GetAllMenuByUserId([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(100)")] string UserName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), UserName);
			return ((IEnumerable<MenuUserVm>)(result.ReturnValue));
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.sp_GetAllActionByRoleID")]
		public IEnumerable<RoleUserVm> GetActionByRoleID([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(100)")] String Account)
		{
			//object[] para ={
			//new SqlParameter("@RolesId",RolesId)
			//};
			//return DbContext.Database.SqlQuery<RoleUserVm>("sp_GetAllActionByRoleID @RolesId", RolesId).ToList();
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), Account);
			return ((IEnumerable<RoleUserVm>)(result.ReturnValue));
		}
        #region DMNV
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMNhanVien_GetAllPaging")]
        public IEnumerable<DMNV> DMNhanVien_GetAll([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(100)")] string maNV, string iDNhanVien, string hoTen, string maChucVu, string maChuyenMon, string maKhoa, string maMay, string nguoiSD, string ngaySD, string nguoiSD1, string ngaySD1, string maQL, string maCD, string tenTat, string ghiChu, string maNV1, string account, string password, string tenrole, int pageIndex, int pageSize, int add)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maNV, iDNhanVien, hoTen, maChucVu, maChuyenMon, maKhoa, maMay, nguoiSD, ngaySD, nguoiSD1, ngaySD1, maQL, maCD, tenTat, ghiChu, maNV1, account,password,tenrole, pageIndex, pageSize, add);
            return ((IEnumerable<DMNV>)(result.ReturnValue));
        }
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMNhanVien_GetAll")]
		public IEnumerable<DMNV> GetAllDMNhanVien([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(100)")] Boolean _qadmin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), _qadmin);
			return ((IEnumerable<DMNV>)(result.ReturnValue));
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMNhanVien_DELETED")]
		public int spDMNhanVien_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaNV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaNV, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMNhanVien_Create")]
		public int spDMNhanVien_Create([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(150)")] string HoTen,string MaChucVu, string MaChuyenMon, string MaKhoa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, int MaQL, string MaCD, string TenTat, string GhiChu, string idnhanvien, string manv1, string maRole, string Account, string password, bool qadmin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), HoTen, MaChucVu, MaChuyenMon, MaKhoa, MAMAY, NGUOISD, MaQL, MaCD, TenTat, GhiChu, idnhanvien, manv1, maRole, Account, password, qadmin);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMNhanVien_Update")]
		public int spDMNhanVien_Update([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(150)")]string manv, string HoTen, string MaChucVu, string MaChuyenMon, string MaKhoa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, int MaQL, string MaCD, string TenTat, string GhiChu, string idnhanvien, string manv1, string maRole, string Account, string password, bool qadmin, bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), manv, HoTen, MaChucVu, MaChuyenMon, MaKhoa, MAMAY, NGUOISD, MaQL, MaCD, TenTat, GhiChu, idnhanvien, manv1, maRole, Account, password, qadmin, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMNhanVien(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMNhanVien";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMNhanVien_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMNhanVien(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMNhanVien";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMNhanVien_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableNhanVien";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMChucVu
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCVU_GetAllPaging")]
		public IEnumerable<DMChucVuVM> DMChucVuGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")]  string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = ((IEnumerable<DMChucVuVM>)(result.ReturnValue));
			return list;
		}
     
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCVU_CREATE")]
		public int spDMCHUCVU_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())),TENCV, MAMAY, NGUOISD);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = (int)(result.ReturnValue);
            return list;
        }
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCVU_DELETED")]
		public int spDMCHUCVU_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaCV, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCVU_UPDATE")]
		public int spDMCHUCVU_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MACV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MACV, TENCV, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMChucVu(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMChucVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMChucVu_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMChucVu(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMChucVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMChucVu_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableChucVu";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCVU_GetAll")]
		public IEnumerable<DMChucVu> spDMCHUCVU_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMChucVu>)(result.ReturnValue));
			return list;
		}
		#endregion
		#region DMCHUCDANH
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCDANH_GetAllPaging")]
		public IEnumerable<DMChucDanhVM> DMCHUCDANHGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maCD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenCD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCD, tenCD, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMChucDanhVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCDANH_GetAll")]
		public IEnumerable<DMChucDanh> spDMCHUCDANH_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMChucDanh>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCDANH_CREATE")]
		public int spDMCHUCDanh_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENCD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENCD, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCDANH_DELETED")]
		public int spDMCHUCDanh_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaCD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaCD, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUCDANH_UPDATE")]
		public int spDMCHUCDanh_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MACD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENCD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MACD, TENCD, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMChucDanh(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMCHUCDANH";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMCHUCDANH_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMChucDanh(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMCHUCDANH";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMCHUCDANH_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMTinh";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMChephamMau
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMChephamMau_GetAllPaging")]
		public IEnumerable<DMChephamMauVM> DMChephamMauGetList(string maCPMau, string tenCPMau, string TenDVT, string TenTat, string MaBYT, string TenBYT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCPMau, tenCPMau, TenDVT, TenTat, MaBYT, TenBYT, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMChephamMauVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMChephamMau_GetAll")]
		public IEnumerable<DMChephamMau> spDMChephamMau_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCPMau, @TenCPMau, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMChephamMau>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMChephamMau_CREATE")]
		public int spDMChephamMau_CREATE(string tenCPMau, string TenDVT, string TenTat, string MaBYT, string TenBYT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenCPMau, TenDVT, TenTat, MaBYT, TenBYT, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCPMau, @TenCPMau, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMChephamMau_DELETED")]
		public int spDMChephamMau_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaCPMau, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaCPMau, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCPMau, @TenCPMau, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMChephamMau_UPDATE")]
		public int spDMChephamMau_UPDATE(string maCPMau, string tenCPMau, string TenDVT, string TenTat, string MaBYT, string TenBYT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCPMau, tenCPMau, TenDVT, TenTat, MaBYT, TenBYT, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCPMau, @TenCPMau, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMChephamMau(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMChephamMau";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMChephamMau_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMChephamMau(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMChephamMau";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMChephamMau_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableChephamMau";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMAction
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMAction_GetAllPaging")]
		public IEnumerable<DMActionVM> DMActionGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maAction, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenAction, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ButtonName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int ApplicationActionID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maAction, tenAction, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, ButtonName, ApplicationActionID);
			var list = ((IEnumerable<DMActionVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMAction_GetAll")]
		public IEnumerable<DMAction> spDMAction_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaAction, @TenAction, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMAction>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMAction_CREATE")]
		public int spDMAction_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENAction, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ButtonName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int ApplicationActionID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENAction, MAMAY, NGUOISD,ButtonName,ApplicationActionID);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaAction, @TenAction, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMAction_DELETED")]
		public int spDMAction_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaAction, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaAction, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaAction, @TenAction, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMAction_UPDATE")]
		public int spDMAction_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAAction, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENAction, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ButtonName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int ApplicationActionID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MAAction, TENAction, MAMAY, NGUOISD, huy,ButtonName,ApplicationActionID);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaAction, @TenAction, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMAction(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMAction";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMAction_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMAction(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMAction";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMAction_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableAction";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMMenu
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMMenu_GetAllPaging")]
		public IEnumerable<DMMenuVM> DMMenuGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MenuID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MenuName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, int Level, string MenuParent, int ApplicationActionID, string ActionName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MenuID, MenuName, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, Level, MenuParent, ApplicationActionID, ActionName);
			var list = ((IEnumerable<DMMenuVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMMenu_GetAll")]
		public IEnumerable<DMMenu> spDMMenu_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MenuID, @MenuName, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMMenu>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMMenu_CREATE")]
		public int spDMMenu_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MenuID, string MenuName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, int Level, string MenuParent, int ApplicationActionID, string ActionName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())) , MenuID, MenuName, MAMAY, NGUOISD, Level, MenuParent, ApplicationActionID, ActionName);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MenuID, @MenuName, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMMenu_DELETED")]
		public int spDMMenu_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MenuID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MenuID, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MenuID, @MenuName, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMMenu_UPDATE")]
		public int spDMMenu_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MenuID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MenuName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, int Level, string MenuParent, int ApplicationActionID, string ActionName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MenuID, MenuName, MAMAY, NGUOISD, huy, Level, MenuParent, ApplicationActionID, ActionName);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MenuID, @MenuName, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMMenu(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMMenu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMMenu_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMMenu(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMMenu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMMenu_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableMenu";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMDichVu_ChungLoai
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_ChungLoai_GetAllPaging")]
		public IEnumerable<DMDichVu_ChungLoaiVM> DMDichVu_ChungLoaiGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maChungLoai, tenChungLoai, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMDichVu_ChungLoaiVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_ChungLoai_GetAll")]
		public IEnumerable<DMDichVu_ChungLoai> spDMDichVu_ChungLoai_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDichVu_ChungLoai>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_ChungLoai_CREATE")]
		public int spDMDichVu_ChungLoai_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENChungLoai, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_ChungLoai_DELETED")]
		public int spDMDichVu_ChungLoai_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaChungLoai, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_ChungLoai_UPDATE")]
		public int spDMDichVu_ChungLoai_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MAChungLoai, TENChungLoai, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMDichVu_ChungLoai(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_ChungLoai";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_ChungLoai_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMDichVu_ChungLoai(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_ChungLoai";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_ChungLoai_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMDichVu_CHUNGLOAI";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMDichVu_LoaiHinh
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_LoaiHinh_GetAllPaging")]
		public IEnumerable<DMDichVu_LoaiHinhVM> DMDichVu_LoaiHinhGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maLH, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenLH, string tenChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maLH, tenLH, tenChungLoai, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMDichVu_LoaiHinhVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_LoaiHinh_GetAll")]
		public IEnumerable<DMDichVu_LoaiHinh> spDMDichVu_LoaiHinh_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maLH, @tenLH, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDichVu_LoaiHinh>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_LoaiHinh_CREATE")]
		public int spDMDichVu_LoaiHinh_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenLH, string maChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenLH, maChungLoai, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maLH, @tenLH, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_LoaiHinh_DELETED")]
		public int spDMDichVu_LoaiHinh_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maLH, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maLH, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maLH, @tenLH, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_LoaiHinh_UPDATE")]
		public int spDMDichVu_LoaiHinh_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maLH, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenLH, string maChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maLH, tenLH,maChungLoai, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maLH, @tenLH, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMDichVu_LoaiHinh(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_LoaiHinh";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_LoaiHinh_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMDichVu_LoaiHinh(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_LoaiHinh";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_LoaiHinh_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMDichVu_LoaiHinh";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMDichVu_Nhom
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_Nhom_GetAllPaging")]
		public IEnumerable<DMDichVu_NhomVM> DMDichVu_NhomGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maNhomDV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenNhomDV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maNhomDV, tenNhomDV, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMDichVu_NhomVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_Nhom_GetAll")]
		public IEnumerable<DMDichVu_Nhom> spDMDichVu_Nhom_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maNhomDV, @tenNhomDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDichVu_Nhom>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_Nhom_CREATE")]
		public int spDMDichVu_Nhom_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenNhomDV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenNhomDV, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maNhomDV, @tenNhomDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_Nhom_DELETED")]
		public int spDMDichVu_Nhom_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maNhomDV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maNhomDV, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maNhomDV, @tenNhomDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_Nhom_UPDATE")]
		public int spDMDichVu_Nhom_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maNhomDV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenNhomDV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maNhomDV, tenNhomDV, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @maNhomDV, @tenNhomDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMDichVu_Nhom(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_Nhom";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_Nhom_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMDichVu_Nhom(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_Nhom";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_Nhom_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMDichVu_Nhom";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMDichVu_PhanLoaiPTTT
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_PhanLoaiPTTT_GetAllPaging")]
		public IEnumerable<DMDichVu_PhanLoaiPTTTVM> DMDichVu_PhanLoaiPTTTGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaPLPTTT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TenPLPTTT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaPLPTTT, TenPLPTTT, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMDichVu_PhanLoaiPTTTVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_PhanLoaiPTTT_GetAll")]
		public IEnumerable<DMDichVu_PhanLoaiPTTT> spDMDichVu_PhanLoaiPTTT_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPLPTTT, @TenPLPTTT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDichVu_PhanLoaiPTTT>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_PhanLoaiPTTT_CREATE")]
		public int spDMDichVu_PhanLoaiPTTT_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TenPLPTTT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TenPLPTTT, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPLPTTT, @TenPLPTTT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_PhanLoaiPTTT_DELETED")]
		public int spDMDichVu_PhanLoaiPTTT_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaPLPTTT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaPLPTTT, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPLPTTT, @TenPLPTTT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_PhanLoaiPTTT_UPDATE")]
		public int spDMDichVu_PhanLoaiPTTT_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaPLPTTT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TenPLPTTT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaPLPTTT, TenPLPTTT, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPLPTTT, @TenPLPTTT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMDichVu_PhanLoaiPTTT(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_PhanLoaiPTTT";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_PhanLoaiPTTT_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMDichVu_PhanLoaiPTTT(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_PhanLoaiPTTT";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_PhanLoaiPTTT_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMDichVu_PhanLoaiPTTT";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMDichVu
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_GetAllPaging")]
		public IEnumerable<DMDichVuVM> DMDichVuGetList(string maDV, string tenDV,String TenChungLoai,String TenLH,String TenPLPTTT,String TenTat,String MaBYT,String TenBYT,String TenNhomDV,String MaXN,String ChisocaoNu,String ChisocaoNam,String ChisothapNu,String ChisothapNam,String DonViDo,String GhiChu, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDV, tenDV, TenChungLoai, TenLH, TenPLPTTT, TenTat, MaBYT, TenBYT, TenNhomDV, MaXN, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, GhiChu, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
			var list = ((IEnumerable<DMDichVuVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_GetAll")]
		public IEnumerable<DMDichVu> spDMDichVu_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDichVu>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_CREATE")]
		public int spDMDichVu_CREATE( String TenDV, String MaChungLoai, String MaLH, String MaPLPTTT, String TenTat, String MaBYT, String TenBYT, String MaNhomDV, String MaXN, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String GhiChu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TenDV, MaChungLoai, MaLH, MaPLPTTT, TenTat, MaBYT, TenBYT, MaNhomDV, MaXN, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, GhiChu, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_DELETED")]
		public int spDMDichVu_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaChungLoai, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_UPDATE")]
		public int spDMDichVu_UPDATE(String MaDV, String TenDV, String MaChungLoai, String MaLH, String MaPLPTTT, String TenTat, String MaBYT, String TenBYT, String MaNhomDV, String MaXN, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String GhiChu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaDV, TenDV, MaChungLoai, MaLH, MaPLPTTT, TenTat, MaBYT, TenBYT, MaNhomDV, MaXN, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, GhiChu, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMDichVu(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMDichVu(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMDichVu";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMDichVu_CS
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_CS_GetAllPaging")]
		public IEnumerable<DMDichVu_CSVM> DMDichVu_CSGetList(string maCS, string tenCS, String TenDV, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String MaXN, String GhiChu, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCS, tenCS, TenDV, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, MaXN, GhiChu, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
			var list = ((IEnumerable<DMDichVu_CSVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_CS_GetAll")]
		public IEnumerable<DMDichVu_CS> spDMDichVu_CS_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDV, @TenDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDichVu_CS>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_CS_CREATE")]
		public int spDMDichVu_CS_CREATE(String TenCS, String MaDV, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String MaXN, String GhiChu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TenCS, MaDV, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, MaXN, GhiChu, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDV, @TenDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_CS_DELETED")]
		public int spDMDichVu_CS_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaCS, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaCS, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDV, @TenDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDichVu_CS_UPDATE")]
		public int spDMDichVu_CS_UPDATE(String MaCS, String TenCS, String MaDV, String ChisocaoNu, String ChisocaoNam, String ChisothapNu, String ChisothapNam, String DonViDo, String MaXN, String GhiChu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaCS, TenCS, MaDV, ChisocaoNu, ChisocaoNam, ChisothapNu, ChisothapNam, DonViDo, MaXN, GhiChu, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDV, @TenDV, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMDichVu_CS(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_CS";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_CS_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMDichVu_CS(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDichVu_CS";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDichVu_CS_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMDichVu_CS";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMPhauThuat
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMPhauThuat_GetAllPaging")]
		public IEnumerable<DMPhauThuatVM> DMPhauThuatGetList(string maPT, string tenPT, String TenNhomDV, String TenPLPTTT, String TenTat, String TenChungLoai, String MaBYT, String TenBYT, String GhiChu, string maMay, string ngaySD, string nguoiSD, int pageIndex, int pageSize, int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maPT, tenPT, TenNhomDV, TenPLPTTT, TenTat, TenChungLoai, MaBYT, TenBYT, GhiChu, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
			var list = ((IEnumerable<DMPhauThuatVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMPhauThuat_GetAll")]
		public IEnumerable<DMPhauThuat> spDMPhauThuat_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMPhauThuat>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMPhauThuat_CREATE")]
		public int spDMPhauThuat_CREATE(string TenPT, string MaNhomDV, string MaPLPTTT, string TenTat, string MaChungLoai, string MaBYT, string TenBYT, string GhiChu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TenPT, MaNhomDV, MaPLPTTT, TenTat, MaChungLoai, MaBYT, TenBYT, GhiChu, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMPhauThuat_DELETED")]
		public int spDMPhauThuat_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maPT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maPT, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMPhauThuat_UPDATE")]
		public int spDMPhauThuat_UPDATE(string MaPT, string TenPT, string MaNhomDV, string MaPLPTTT, string TenTat, string MaChungLoai, string MaBYT, string TenBYT, string GhiChu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaPT, TenPT, MaNhomDV, MaPLPTTT, TenTat, MaChungLoai, MaBYT, TenBYT, GhiChu, GhiChu, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMPhauThuat(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMPhauThuat";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMPhauThuat_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMPhauThuat(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMPhauThuat";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMPhauThuat_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMPhauThuat";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc_ChungLoai
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_ChungLoai_GetAllPaging")]
		public IEnumerable<DMThuoc_ChungLoaiVM> DMThuoc_ChungLoaiGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maChungLoai, tenChungLoai, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMThuoc_ChungLoaiVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_ChungLoai_GetAll")]
		public IEnumerable<DMThuoc_ChungLoai> spDMThuoc_ChungLoai_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc_ChungLoai>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_ChungLoai_CREATE")]
		public int spDMThuoc_ChungLoai_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENChungLoai, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_ChungLoai_DELETED")]
		public int spDMThuoc_ChungLoai_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaChungLoai, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_ChungLoai_UPDATE")]
		public int spDMThuoc_ChungLoai_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENChungLoai, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MAChungLoai, TENChungLoai, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc_ChungLoai(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_ChungLoai";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_ChungLoai_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc_ChungLoai(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_ChungLoai";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_ChungLoai_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMTHUOC_CHUNGLOAI";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc_DangBaoChe
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DangBaoChe_GetAllPaging")]
		public IEnumerable<DMThuoc_DangBaoCheVM> DMThuoc_DangBaoCheGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDangBaoChe, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDangBaoChe, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDangBaoChe, tenDangBaoChe, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMThuoc_DangBaoCheVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DangBaoChe_GetAll")]
		public IEnumerable<DMThuoc_DangBaoChe> spDMThuoc_DangBaoChe_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDangBaoChe, @TenDangBaoChe, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc_DangBaoChe>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DangBaoChe_CREATE")]
		public int spDMThuoc_DangBaoChe_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDangBaoChe, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENDangBaoChe, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDangBaoChe, @TenDangBaoChe, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DangBaoChe_DELETED")]
		public int spDMThuoc_DangBaoChe_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaDangBaoChe, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaDangBaoChe, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDangBaoChe, @TenDangBaoChe, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DangBaoChe_UPDATE")]
		public int spDMThuoc_DangBaoChe_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MADangBaoChe, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDangBaoChe, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MADangBaoChe, TENDangBaoChe, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDangBaoChe, @TenDangBaoChe, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc_DangBaoChe(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_DangBaoChe";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_DangBaoChe_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc_DangBaoChe(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_DangBaoChe";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_DangBaoChe_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMTHUOC_DangBaoChe";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc_Donvitinh
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Donvitinh_GetAllPaging")]
		public IEnumerable<DMThuoc_DonvitinhVM> DMThuoc_DonvitinhGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDVT, tenDVT, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMThuoc_DonvitinhVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Donvitinh_GetAll")]
		public IEnumerable<DMThuoc_Donvitinh> spDMThuoc_Donvitinh_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc_Donvitinh>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Donvitinh_CREATE")]
		public int spDMThuoc_Donvitinh_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENDVT, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Donvitinh_DELETED")]
		public int spDMThuoc_Donvitinh_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaDVT, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Donvitinh_UPDATE")]
		public int spDMThuoc_Donvitinh_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MADVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MADVT, TENDVT, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc_Donvitinh(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_Donvitinh";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_Donvitinh_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc_Donvitinh(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_Donvitinh";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_Donvitinh_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMTHUOC_Donvitinh";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc_DuongDung
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DuongDung_GetAllPaging")]
		public IEnumerable<DMThuoc_DuongDungVM> DMThuoc_DuongDungGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDuongDung, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDuongDung, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDuongDung, tenDuongDung, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMThuoc_DuongDungVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DuongDung_GetAll")]
		public IEnumerable<DMThuoc_DuongDung> spDMThuoc_DuongDung_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDuongDung, @TenDuongDung, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc_DuongDung>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DuongDung_CREATE")]
		public int spDMThuoc_DuongDung_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDuongDung, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENDuongDung, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDuongDung, @TenDuongDung, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DuongDung_DELETED")]
		public int spDMThuoc_DuongDung_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaDuongDung, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaDuongDung, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDuongDung, @TenDuongDung, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DuongDung_UPDATE")]
		public int spDMThuoc_DuongDung_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MADuongDung, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDuongDung, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MADuongDung, TENDuongDung, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDuongDung, @TenDuongDung, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc_DuongDung(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_DuongDung";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_DuongDung_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc_DuongDung(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_DuongDung";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_DuongDung_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMTHUOC_DuongDung";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc_NhaSX
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_NhaSX_GetAllPaging")]
		public IEnumerable<DMThuoc_NhaSXVM> DMThuoc_NhaSXGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maNSX, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenNSX, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maNSX, tenNSX, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMThuoc_NhaSXVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_NhaSX_GetAll")]
		public IEnumerable<DMThuoc_NhaSX> spDMThuoc_NhaSX_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNSX, @TenNSX, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc_NhaSX>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_NhaSX_CREATE")]
		public int spDMThuoc_NhaSX_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENNSX, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENNSX, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNSX, @TenNSX, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_NhaSX_DELETED")]
		public int spDMThuoc_NhaSX_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaNSX, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaNSX, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNSX, @TenNSX, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_NhaSX_UPDATE")]
		public int spDMThuoc_NhaSX_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MANSX, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENNSX, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MANSX, TENNSX, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNSX, @TenNSX, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc_NhaSX(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_NhaSX";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_NhaSX_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc_NhaSX(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_NhaSX";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_NhaSX_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableThuoc_NhaSX";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc_Nhom
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Nhom_GetAllPaging")]
		public IEnumerable<DMThuoc_NhomVM> DMThuoc_NhomGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maNhom, tenNhom, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMThuoc_NhomVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Nhom_GetAll")]
		public IEnumerable<DMThuoc_Nhom> spDMThuoc_Nhom_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc_Nhom>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Nhom_CREATE")]
		public int spDMThuoc_Nhom_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENNhom, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Nhom_DELETED")]
		public int spDMThuoc_Nhom_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaNhom, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_Nhom_UPDATE")]
		public int spDMThuoc_Nhom_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MANhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MANhom, TENNhom, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc_Nhom(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_Nhom";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_Nhom_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc_Nhom(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_Nhom";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_Nhom_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMTHUOC_Nhom";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc_PhanLoai
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_PhanLoai_GetAllPaging")]
		public IEnumerable<DMThuoc_PhanLoaiVM> DMThuoc_PhanLoaiGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maPL, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenPL, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maPL, tenPL, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMThuoc_PhanLoaiVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_PhanLoai_GetAll")]
		public IEnumerable<DMThuoc_PhanLoai> spDMThuoc_PhanLoai_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPL, @TenPL, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc_PhanLoai>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_PhanLoai_CREATE")]
		public int spDMThuoc_PhanLoai_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENPL, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENPL, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPL, @TenPL, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_PhanLoai_DELETED")]
		public int spDMThuoc_PhanLoai_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaPL, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaPL, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPL, @TenPL, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_PhanLoai_UPDATE")]
		public int spDMThuoc_PhanLoai_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAPL, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENPL, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MAPL, TENPL, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaPL, @TenPL, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc_PhanLoai(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_PhanLoai";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_PhanLoai_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc_PhanLoai(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc_PhanLoai";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_PhanLoai_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMThuoc_PhanLoai";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMThuoc
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_GetAllPaging")]
		public IEnumerable<DMThuocVM> DMThuocGetList(String MaThuoc,
		String TenNhom,
		String TenPL,
		String TenChungLoai,
		String TenDangBaoChe,
		String TenGoc,
		String TenTM,
		String HamLuong,
		String TenDVT,
		String TenNSX,
		String GhiChu,
		String TenQG,
		String TenDuongDung,
		String MaBYT,
		String TenBYT,
		String SoDangKy,
		String MaMay,
		String NgaySD,
		String NguoiSD, int PageIndex, int pageSize, int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaThuoc, TenNhom, TenPL, TenChungLoai, TenDangBaoChe, TenGoc, TenTM, HamLuong, TenDVT, TenNSX, GhiChu, TenQG, TenDuongDung, MaBYT, TenBYT, SoDangKy, MaMay, NgaySD, NguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMThuocVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_GetAll")]
		public IEnumerable<DMThuoc> spDMThuoc_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaThuoc, @TenThuoc, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMThuoc>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_CREATE")]
		public int spDMThuoc_CREATE(
		String MaNhom,
		String MaPL,
		String MaChungLoai,
		String MaDangBaoChe,
		String TenGoc,
		String TenTM,
		String HamLuong,
		String MaDVT,
		String MaNSX,
		String GhiChu,
		String MaQG,
		String MaDuongDung,
		String MaBYT,
		String TenBYT,
		String SoDangKy,
		String MaMay,
		String NguoiSD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaNhom, MaPL, MaChungLoai, MaDangBaoChe, TenGoc, TenTM, HamLuong, MaDVT, MaNSX, GhiChu, MaQG, MaDuongDung, MaBYT, TenBYT, SoDangKy, MaMay, NguoiSD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaThuoc, @TenThuoc, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_DELETED")]
		public int spDMThuoc_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaThuoc, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaThuoc, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaThuoc, @TenThuoc, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMThuoc_UPDATE")]
		public int spDMThuoc_UPDATE(String MaThuoc,
		String MaNhom,
		String MaPL,
		String MaChungLoai,
		String MaDangBaoChe,
		String TenGoc,
		String TenTM,
		String HamLuong,
		String MaDVT,
		String MaNSX,
		String GhiChu,
		String MaQG,
		String MaDuongDung,
		String MaBYT,
		String TenBYT,
		String SoDangKy,
		String MaMay,
		Boolean Huy,
		String NguoiSD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaThuoc, MaNhom, MaPL, MaChungLoai, MaDangBaoChe, TenGoc, TenTM, HamLuong, MaDVT, MaNSX, GhiChu, MaQG, MaDuongDung, MaBYT, TenBYT, SoDangKy, MaMay, Huy, NguoiSD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaThuoc, @TenThuoc, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMThuoc(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMThuoc(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMThuoc";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMThuoc_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMThuoc";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMVTYT_Donvitinh
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Donvitinh_GetAllPaging")]
		public IEnumerable<DMVTYT_DonvitinhVM> DMVTYT_DonvitinhGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDVT, tenDVT, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMVTYT_DonvitinhVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Donvitinh_GetAll")]
		public IEnumerable<DMVTYT_Donvitinh> spDMVTYT_Donvitinh_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMVTYT_Donvitinh>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Donvitinh_CREATE")]
		public int spDMVTYT_Donvitinh_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENDVT, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Donvitinh_DELETED")]
		public int spDMVTYT_Donvitinh_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaDVT, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Donvitinh_UPDATE")]
		public int spDMVTYT_Donvitinh_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MADVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENDVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MADVT, TENDVT, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaDVT, @TenDVT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMVTYT_Donvitinh(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMVTYT_Donvitinh";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMVTYT_Donvitinh_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMVTYT_Donvitinh(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMVTYT_Donvitinh";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMVTYT_Donvitinh_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMVTYT_Donvitinh";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMVTYT_Nhom
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Nhom_GetAllPaging")]
		public IEnumerable<DMVTYT_NhomVM> DMVTYT_NhomGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maNhom, tenNhom, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, GhiChu);
			var list = ((IEnumerable<DMVTYT_NhomVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Nhom_GetAll")]
		public IEnumerable<DMVTYT_Nhom> spDMVTYT_Nhom_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMVTYT_Nhom>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Nhom_CREATE")]
		public int spDMVTYT_Nhom_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENNhom, MAMAY, NGUOISD, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Nhom_DELETED")]
		public int spDMVTYT_Nhom_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaNhom, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_Nhom_UPDATE")]
		public int spDMVTYT_Nhom_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MANhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENNhom, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string GhiChu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MANhom, TENNhom, MAMAY, NGUOISD, huy, GhiChu);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaNhom, @TenNhom, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMVTYT_Nhom(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMVTYT_Nhom";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMVTYT_Nhom_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMVTYT_Nhom(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMVTYT_Nhom";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMVTYT_Nhom_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMVTYT_Nhom";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMVTYT
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_GetAllPaging")]
		public IEnumerable<DMVTYTVM> DMVTYTGetList(String MaVT,
		String TenNhom,
		String TenTM,
		String TenDVT,
		String GhiChu,
		String MaBYT,
		String TenBYT,
		String MaMay,
		String NgaySD,
		String NguoiSD, int PageIndex, int pageSize, int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaVT, TenNhom, TenTM, TenDVT, GhiChu, MaBYT, TenBYT, MaMay, NgaySD, NguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMVTYTVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_GetAll")]
		public IEnumerable<DMVTYT> spDMVTYT_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaVTYT, @TenVTYT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMVTYT>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_CREATE")]
		public int spDMVTYT_CREATE(
		String MaNhom,
		String TenTM,
		String MaDVT,
		String GhiChu,
		String MaBYT,
		String TenBYT,
		String MaMay,
		String NguoiSD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaNhom, TenTM, MaDVT, GhiChu, MaBYT, TenBYT, MaMay, NguoiSD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaVTYT, @TenVTYT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_DELETED")]
		public int spDMVTYT_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaVT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaVT, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaVTYT, @TenVTYT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMVTYT_UPDATE")]
		public int spDMVTYT_UPDATE(String MaVT,
		String MaNhom,
		String TenTM,
		String MaDVT,
		String GhiChu,
		String MaBYT,
		String TenBYT,
		String MaMay,
		Boolean Huy,
		String NguoiSD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaVT, MaNhom, TenTM, MaDVT, GhiChu, MaBYT, TenBYT, MaMay, Huy, NguoiSD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaVTYT, @TenVTYT, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMVTYT(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMVTYT";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMVTYT_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMVTYT(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMVTYT";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMVTYT_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMVTYT";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMKHoa
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKHOA_GetAll")]
		public IEnumerable<DMKhoa> DMKhoaGetAll([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] Boolean qadmin)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), qadmin);
			var list= ((IEnumerable<DMKhoa>)(result.ReturnValue));
			//return ((IEnumerable<DMKhoa>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_GetAllPaging")]
		public IEnumerable<DMKhoaVM> DMKhoaGetList(string maKhoa, string tenKhoa, string DiaDiem, byte Loai, string MaBYT, string GhiChu, int SoGiuong, string TenNVTruongKhoa, string TenNVDieuDuongTruong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maKhoa, tenKhoa, DiaDiem, Loai, MaBYT, GhiChu, SoGiuong, TenNVTruongKhoa, TenNVDieuDuongTruong, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMKhoaVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_CREATE")]
		public int spDMKhoa_CREATE(string tenKhoa, string DiaDiem, byte Loai, string MaBYT, string GhiChu, decimal SoGiuong, string MaNVTruongKhoa, string MaNVDieuDuongTruong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenKhoa, DiaDiem, Loai, MaBYT, GhiChu, SoGiuong, MaNVTruongKhoa, MaNVDieuDuongTruong, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_DELETED")]
		public int spDMKhoa_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaKhoa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaKhoa, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_UPDATE")]
		public int spDMKhoa_UPDATE(string maKhoa, string tenKhoa, string DiaDiem, byte Loai, string MaBYT, string GhiChu, decimal SoGiuong, string MaNVTruongKhoa, string MaNVDieuDuongTruong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maKhoa, tenKhoa, DiaDiem, Loai, MaBYT, GhiChu, SoGiuong, MaNVTruongKhoa, MaNVDieuDuongTruong, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaChungLoai, @TenChungLoai, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMKhoa(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMKhoa";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMKhoa_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMKhoa(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMKhoa";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMKhoa_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMKhoa";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMNVKhoa_GetAllByAcc")]
		public IEnumerable<Dmkhoa> GetDMNVKhoaByAcc([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(100)")] string UserName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), UserName);
			return ((IEnumerable<Dmkhoa>)(result.ReturnValue));
		}
		#endregion
		#region DMKhoa_Buong
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Buong_GetAllPaging")]
		public IEnumerable<DMKhoa_BuongVM> DMKhoa_BuongGetList(string maBuong, string tenBuong, string tenKhoa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maBuong, tenBuong, tenKhoa, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMKhoa_BuongVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Buong_GetAll")]
		public IEnumerable<DMKhoa_Buong> spDMKhoa_Buong_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaBuong, @TenBuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMKhoa_Buong>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Buong_CREATE")]
		public int spDMKhoa_Buong_CREATE(string tenBuong, string maKhoa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenBuong, maKhoa, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaBuong, @TenBuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Buong_DELETED")]
		public int spDMKhoa_Buong_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaBuong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaBuong, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaBuong, @TenBuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Buong_UPDATE")]
		public int spDMKhoa_Buong_UPDATE(string MABuong, string tenBuong, string maKhoa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MABuong, tenBuong, maKhoa, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaBuong, @TenBuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMKhoa_Buong(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMKhoa_Buong";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMKhoa_Buong_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMKhoa_Buong(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMKhoa_Buong";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMKhoa_Buong_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableBuong";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMKhoa_Giuong
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Giuong_GetAllPaging")]
		public IEnumerable<DMKhoa_GiuongVM> DMKhoa_GiuongGetList(string maGiuong, string tenGiuong, string tenKhoa, string tenBuong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maGiuong, tenGiuong, tenKhoa, tenBuong, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DMKhoa_GiuongVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Giuong_GetAll")]
		public IEnumerable<DMKhoa_Giuong> spDMKhoa_Giuong_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaGiuong, @TenGiuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMKhoa_Giuong>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Giuong_CREATE")]
		public int spDMKhoa_Giuong_CREATE(string tenGiuong, string maKhoa, string maBuong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenGiuong, maKhoa,maBuong, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaGiuong, @TenGiuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Giuong_DELETED")]
		public int spDMKhoa_Giuong_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaGiuong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaGiuong, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaGiuong, @TenGiuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMKhoa_Giuong_UPDATE")]
		public int spDMKhoa_Giuong_UPDATE(string MAGiuong, string tenGiuong, string maKhoa, string maBuong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MAGiuong, tenGiuong, maKhoa, maBuong, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaGiuong, @TenGiuong, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMKhoa_Giuong(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMKhoa_Giuong";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMKhoa_Giuong_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMKhoa_Giuong(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMKhoa_Giuong";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMKhoa_Giuong_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableGiuong";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		#endregion
		#region DMLoaiDNTL
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMLoaiDNTL_GetAll")]
		public IEnumerable<DMLoaiDNTL> DMLoaiDNTLGetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			var list = ((IEnumerable<DMLoaiDNTL>)(result.ReturnValue));
			//return ((IEnumerable<DMKhoa>)(result.ReturnValue));
			return list;
		}
		#endregion
		#region DMChuyenMon
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMCHUYENMON_GetAll")]
		public IEnumerable<DMChuyenMon> spDMCHUYENMON_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMChuyenMon>)(result.ReturnValue));
			return list;
		}
		#endregion
		#region DMQuocGia
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMQUOCGIA_GetAllPaging")]
		public IEnumerable<DMQuocGiaVM> DMQuocGiaGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maQG, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenQG, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maQG, tenQG, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMQuocGiaVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMQUOCGIA_CREATE")]
		public int spDMQUOCGIA_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENQG, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENQG, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMQUOCGIA_DELETED")]
		public int spDMQUOCGIA_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaQG, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaQG, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMQUOCGIA_UPDATE")]
		public int spDMQUOCGIA_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAQG, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENQG, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MAQG, TENQG, MAMAY, NGUOISD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMQuocGia(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMQuocGia";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMQuocGia_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMQuocGia(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMQuocGia";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMQuocGia_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableQuocGia";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMQUOCGIA_GetAll")]
		public IEnumerable<DMQuocGia> spDMQUOCGIA_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMQuocGia>)(result.ReturnValue));
			return list;
		}
		#endregion
		#region DMDanToc
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDANTOC_GetAllPaging")]
		public IEnumerable<DMDanTocVM> DMDanTocGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDT, tenDT, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDT, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenDT, @maMay, @NgaySD, @nguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDanTocVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDANTOC_CREATE")]
		public int spDMDanToc_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenDT, maMay, nguoiSD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenDT, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenDT, @maMay, @NgaySD, @nguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDANTOC_DELETED")]
		public int spDMDanToc_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDT, maMay, nguoiSD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenDT, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenDT, @maMay, @NgaySD, @nguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDANTOC_UPDATE")]
		public int spDMDanToc_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDT, tenDT, maMay, nguoiSD, huy);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenDT, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenDT, @maMay, @NgaySD, @nguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable ExportDMDanToc(string key, string columns)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDANTOC";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDANTOC_ExportByColumn";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@Column", columns));
					Command.Parameters.Add(new SqlParameter("@dk", key));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable ImportDMDanToc(DataTable excel, bool insert)
		{
			DataTable dr = new DataTable();
			dr.TableName = "DMDANTOC";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMDANTOC_Import";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmp";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDANTOC";
					tab.Value = excel;
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(tab);
					Command.Parameters.Add(new SqlParameter("@insert", insert));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMDANTOC_GetAll")]
		public IEnumerable<DMDanToc> spDMDANTOC_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenDT, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenDT, @maMay, @NgaySD, @nguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMDanToc>)(result.ReturnValue));
			return list;
		}
        #endregion
        #region DM_Tinh

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDM_Tinh_GetAllPaging")]
        //public IEnumerable<DM_TinhVM> DM_TinhGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaTinh, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaQu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaVungLT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TenTinh, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaBHYT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string Huy, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string Matat)
        //public IEnumerable<DMDanTocVM> DMDanTocGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
        public IEnumerable<DM_TinhVM> DM_TinhGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaTinh, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaQu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaVungLT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TenTinh, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaBHYT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string Huy, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string Matat, int PageIndex, int PageSize, int add)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaTinh, MaQu, MaVungLT, TenTinh, MaBHYT, MaMay, Huy, ngaySD, nguoiSD, Matat, PageIndex, PageSize, add);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maDT, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenDT, @maMay, @NgaySD, @nguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = ((IEnumerable<DM_TinhVM>)(result.ReturnValue));
            return list;
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDM_Tinh_CREATE")]
        public int spDM_Tinh_CREATE(string MaQu,  string MaVungLT, string TenTinh, string MaBHYT, string MaMay, string nguoiSD)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaQu, MaVungLT, TenTinh, MaBHYT,MaMay,nguoiSD);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = (int)(result.ReturnValue);
            return list;
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDM_Tinh_DELETED")]
        public int spDM_Tinh_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaTinh, string MaMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NguoiSD)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaTinh, MaMay, NguoiSD);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = (int)(result.ReturnValue);
            return list;
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDM_Tinh_UPDATE")]
        public int spDM_Tinh_UPDATE(string MaTinh, string MaQU, string MaVungLT, string TenTinh, string MaBHYT, string MAMAY, string NguoiSD, bool Huy)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), 
				MaTinh,  MaQU,  MaVungLT,  TenTinh,  MaBHYT,  MAMAY,  NguoiSD,  Huy);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = (int)(result.ReturnValue);
            return list;
        }
        public DataTable ExportDM_Tinh(string key, string columns)
        {
            DataTable dr = new DataTable();
            dr.TableName = "DMTinh";
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
            string tenStore = "spDM_Tinh_ExportByColumn";
            using (SqlConnection Conection = new SqlConnection(conn))
            {
                Conection.Open();
                using (SqlCommand Command = new SqlCommand(tenStore, Conection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add(new SqlParameter("@Column", columns));
                    Command.Parameters.Add(new SqlParameter("@dk", key));
                    SqlDataAdapter dp = new SqlDataAdapter(Command);
                    dp.Fill(dr);
                }
                //if (dr.Rows.Count > 0)
                return dr;
                //else
                //    return "";
            }
        }
        public DataTable ImportDM_Tinh(DataTable excel, bool insert)
        {
            DataTable dr = new DataTable();
            dr.TableName = "DMTinh";
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
            string tenStore = "spDM_Tinh_Import";
            using (SqlConnection Conection = new SqlConnection(conn))
            {
                Conection.Open();
                using (SqlCommand Command = new SqlCommand(tenStore, Conection))
                {
                    SqlParameter tab = new SqlParameter();
                    tab.ParameterName = "@tmp";
                    tab.SqlDbType = SqlDbType.Structured;
                    tab.TypeName = "dbo.TableDMTinh";
                    tab.Value = excel;
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add(tab);
                    Command.Parameters.Add(new SqlParameter("@insert", insert));
                    SqlDataAdapter dp = new SqlDataAdapter(Command);
                    dp.Fill(dr);
                }
                //if (dr.Rows.Count > 0)
                return dr;
                //else
                //    return "";
            }
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMBA_HTRaVien_GetAll")]
        public IEnumerable<HTRaVien> spDM_Tinh_GetAll()
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = ((IEnumerable<HTRaVien>)(result.ReturnValue));
            return list;
        }
        #endregion
        #region DMRole PhanNhomQuyenDS
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMRole_GetAllPaging")]
		public IEnumerable<DMRoleVM> DMRoleGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maRole, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenRole, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maRole, tenRole, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMRoleVM>)(result.ReturnValue));
			return list;
		}
		//[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMRole_CREATE")]
		//public int spDMRole_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENRole, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		//{
		//	IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENRole, MAMAY, NGUOISD);
		//	//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
		//	//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
		//	var list = (int)(result.ReturnValue);
		//	return list;
		//}
		public DataTable spDMRole_CREATE(string TenRole, string mamay, string nguoisd, DataTable MenuRole, DataTable ActionRole)
		{
			DataTable dr = new DataTable();
			//dr.TableName = "DMChucVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMRole_CREATE";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@TENRole", TenRole));
					Command.Parameters.Add(new SqlParameter("@MAMAY", mamay));
					Command.Parameters.Add(new SqlParameter("@NGUOISD", nguoisd));
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmpMenuRole";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableMenuRole";
					tab.Value = MenuRole;
					Command.Parameters.Add(tab);
					SqlParameter tab1 = new SqlParameter();
					tab1.ParameterName = "@tmpActionRole";
					tab1.SqlDbType = SqlDbType.Structured;
					tab1.TypeName = "dbo.TableActionRole";
					tab1.Value = ActionRole;
					Command.Parameters.Add(tab1);
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMRole_DELETED")]
		public int spDMRole_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaRole, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaRole, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		//[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMRole_UPDATE")]
		//public int spDMRole_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MARole, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		//{
		//	IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MARole, TENCV, MAMAY, NGUOISD, huy);
		//	//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
		//	//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
		//	var list = (int)(result.ReturnValue);
		//	return list;
		//}
		public DataTable spDMRole_UPDATE(string ApplicationRolesId, string TenRole, bool Huy, string mamay, string nguoisd, DataTable MenuRole, DataTable ActionRole)
		{
			DataTable dr = new DataTable();
			//dr.TableName = "DMChucVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMRole_UPDATE";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@ApplicationRolesId", ApplicationRolesId));
					Command.Parameters.Add(new SqlParameter("@TENRole", TenRole));
					Command.Parameters.Add(new SqlParameter("@Huy", Huy));
					Command.Parameters.Add(new SqlParameter("@MAMAY", mamay));
					Command.Parameters.Add(new SqlParameter("@NGUOISD", nguoisd));
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmpMenuRole";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableMenuRole";
					tab.Value = MenuRole;
					Command.Parameters.Add(tab);
					SqlParameter tab1 = new SqlParameter();
					tab1.ParameterName = "@tmpActionRole";
					tab1.SqlDbType = SqlDbType.Structured;
					tab1.TypeName = "dbo.TableActionRole";
					tab1.Value = ActionRole;
					Command.Parameters.Add(tab1);
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		//public DataTable ExportDMChucVu(string key, string columns)
		//{
		//	DataTable dr = new DataTable();
		//	dr.TableName = "DMChucVu";
		//	var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
		//	string tenStore = "spDMChucVu_ExportByColumn";
		//	using (SqlConnection Conection = new SqlConnection(conn))
		//	{
		//		Conection.Open();
		//		using (SqlCommand Command = new SqlCommand(tenStore, Conection))
		//		{
		//			Command.CommandType = CommandType.StoredProcedure;
		//			Command.Parameters.Add(new SqlParameter("@Column", columns));
		//			Command.Parameters.Add(new SqlParameter("@dk", key));
		//			SqlDataAdapter dp = new SqlDataAdapter(Command);
		//			dp.Fill(dr);
		//		}
		//		//if (dr.Rows.Count > 0)
		//		return dr;
		//		//else
		//		//    return "";
		//	}
		//}
		//public DataTable ImportDMChucVu(DataTable excel, bool insert)
		//{
		//	DataTable dr = new DataTable();
		//	dr.TableName = "DMChucVu";
		//	var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
		//	string tenStore = "spDMChucVu_Import";
		//	using (SqlConnection Conection = new SqlConnection(conn))
		//	{
		//		Conection.Open();
		//		using (SqlCommand Command = new SqlCommand(tenStore, Conection))
		//		{
		//			SqlParameter tab = new SqlParameter();
		//			tab.ParameterName = "@tmp";
		//			tab.SqlDbType = SqlDbType.Structured;
		//			tab.TypeName = "dbo.TableChucVu";
		//			tab.Value = excel;
		//			Command.CommandType = CommandType.StoredProcedure;
		//			Command.Parameters.Add(tab);
		//			Command.Parameters.Add(new SqlParameter("@insert", insert));
		//			SqlDataAdapter dp = new SqlDataAdapter(Command);
		//			dp.Fill(dr);
		//		}
		//		//if (dr.Rows.Count > 0)
		//		return dr;
		//		//else
		//		//    return "";
		//	}
		//}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMRole_GetAll")]
		public IEnumerable<DMRole> spDMRole_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMRole>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMRole_Get")]
		public IEnumerable<DMRole> spDMRole_Get([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(128)")] string MaRole)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())),MaRole);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMRole>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMAction_GetByRole")]
		public IEnumerable<ActionRole> spDMAction_GetByRole([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(128)")] string MaRole)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaRole);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<ActionRole>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spMenu_GetByRole")]
		public IEnumerable<MenuRole> spMenu_GetByRole([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(128)")] string MaRole)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaRole);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<MenuRole>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMNVKhoa_GetByMaNV")]
		public IEnumerable<DMNVKhoa> spDMNVKhoa_GetByMaNV([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(128)")] string MaNV)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaNV);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<DMNVKhoa>)(result.ReturnValue));
			return list;
		}
		public DataTable spDMNVKhoa_UPDATE(string manv, string mamay, string nguoiSD , DataTable DMNVKhoaRole)
		{
			DataTable dr = new DataTable();
			//dr.TableName = "DMChucVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spDMNVKhoa_UPDATE";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@MaNV", manv));
					Command.Parameters.Add(new SqlParameter("@MaMay", mamay));
					Command.Parameters.Add(new SqlParameter("@NguoiSD", nguoiSD));
					SqlParameter tab = new SqlParameter();
					tab.ParameterName = "@tmpDMNVKhoa";
					tab.SqlDbType = SqlDbType.Structured;
					tab.TypeName = "dbo.TableDMNVKhoa";
					tab.Value = DMNVKhoaRole;
					Command.Parameters.Add(tab);
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
        #endregion
        #region DMBA_HTRaVien
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMBA_HTRaVien_GetAllPaging")]
        public IEnumerable<HTRaVienVM> DMBA_HTRaVienGetList( string maHTRaVien, string tenHTRaVien, string maMay,  string ngaySD, string nguoiSD, int PageIndex, int pageSize, int add, string ghichu, string mabyte)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maHTRaVien, tenHTRaVien, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add, ghichu, mabyte);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = ((IEnumerable<HTRaVienVM>)(result.ReturnValue));
            return list;
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDM_Tinh_CREATE")]
        public int spDMBA_HTRaVien_CREATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, string ghichu, string mabyte)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), TENCV, MAMAY, NGUOISD, ghichu, mabyte);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = (int)(result.ReturnValue);
            return list;
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMBA_HTRaVien_DELETED")]
        public int spDMBA_HTRaVien_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MaCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MaCV, MAMAY, NGUOISD);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = (int)(result.ReturnValue);
            return list;
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMBA_HTRaVien_UPDATE")]
        public int spDMBA_HTRaVien_UPDATE([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MACV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string TENCV, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy, string ghichu, string mabyte)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), MACV, TENCV, MAMAY, NGUOISD, huy, ghichu, mabyte);
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = (int)(result.ReturnValue);
            return list;
        }
        public DataTable ExportDMBA_HTRaVien(string key, string columns)
        {
            DataTable dr = new DataTable();
            dr.TableName = "DMBA_HTRaVien";
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
            string tenStore = "spDMBA_HTRaVien_ExportByColumn";
            using (SqlConnection Conection = new SqlConnection(conn))
            {
                Conection.Open();
                using (SqlCommand Command = new SqlCommand(tenStore, Conection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add(new SqlParameter("@Column", columns));
                    Command.Parameters.Add(new SqlParameter("@dk", key));
                    SqlDataAdapter dp = new SqlDataAdapter(Command);
                    dp.Fill(dr);
                }
                //if (dr.Rows.Count > 0)
                return dr;
                //else
                //    return "";
            }
        }
        public DataTable ImportDMBA_HTRaVien(DataTable excel, bool insert)
        {
            DataTable dr = new DataTable();
            dr.TableName = "DMBA_HTRaVien";
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
            string tenStore = "spDMBA_HTRaVien_Import";
            using (SqlConnection Conection = new SqlConnection(conn))
            {
                Conection.Open();
                using (SqlCommand Command = new SqlCommand(tenStore, Conection))
                {
                    SqlParameter tab = new SqlParameter();
                    tab.ParameterName = "@tmp";
                    tab.SqlDbType = SqlDbType.Structured;
                    tab.TypeName = "dbo.TableDMBA_HTRaVien";
                    tab.Value = excel;
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add(tab);
                    Command.Parameters.Add(new SqlParameter("@insert", insert));
                    SqlDataAdapter dp = new SqlDataAdapter(Command);
                    dp.Fill(dr);
                }
                //if (dr.Rows.Count > 0)
                return dr;
                //else
                //    return "";
            }
        }
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDMBA_HTRaVien_GetAll")]
        public IEnumerable<HTRaVien> spDMBA_HTRaVien_GetAll()
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
            //IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
            //var list = this.DbContext.Database.SqlQuery<DMBA_HTRaVienVm>("spDMBA_HTRaVien_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
            var list = ((IEnumerable<HTRaVien>)(result.ReturnValue));
            return list;
        }
        #endregion
        #region TraceLog
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spTraceLogTableName_GetAll")]
		public IEnumerable<TraceLogTableName> spTraceLogTableName_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<TraceLogTableName>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spTraceLogKieuTacDong_GetAll")]
		public IEnumerable<TraceLogKieuTacDong> spTraceLogKieuTacDong_GetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = ((IEnumerable<TraceLogKieuTacDong>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spTraceLog_GetAllPaging")]
		public IEnumerable<TraceLogSQLVM> TraceLogGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenbang, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string mabn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string kieutacdong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay,DateTime tungay, DateTime denngay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), tenbang,mabn,kieutacdong, maMay,tungay,denngay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<TraceLogSQLVM>)(result.ReturnValue));
			return list;
		}
		#endregion
		#region Trich Luc HSBA
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spFindHSBA_GetAll")]
		public IEnumerable<HSBAVM> FindHSBAGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string hotenbn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tungay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string denngay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string khoa)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), hotenbn, tungay, denngay, khoa);
			var list = ((IEnumerable<HSBAVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spFindHSBA_GetByDK")]
		public IEnumerable<HSBAVM> FindHSBAGetByDK([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string hotenbn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tungay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string denngay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string khoa, string dk)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), hotenbn, tungay, denngay, khoa,dk);
			var list = ((IEnumerable<HSBAVM>)(result.ReturnValue));
			return list;
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spDeNghiTrichLuc_GetAllPaging")]
		public IEnumerable<DeNghiTrichLucVM> DeNghiTrichLucGetList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string sophieu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string tenLoaiDeNghi, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string maba, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(30)")] string tungay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(30)")] string denngay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool Duyet, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string maMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string ngaySD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string nguoiSD, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int PageIndex, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int pageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "int")] int add)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sophieu, tenLoaiDeNghi, maba, tungay, denngay, Duyet, maMay, ngaySD, nguoiSD, PageIndex, pageSize, add);
			var list = ((IEnumerable<DeNghiTrichLucVM>)(result.ReturnValue));
			return list;
		}
		public DataTable spBenhAn_HauKiem(string hotenbn, string tungay, string denngay,string khoa, string dk)
		{
			DataTable dr = new DataTable();
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spBenhAn_HauKiem";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@hotenbn", hotenbn));
					Command.Parameters.Add(new SqlParameter("@tungay", tungay));
					Command.Parameters.Add(new SqlParameter("@denngay", denngay));
					Command.Parameters.Add(new SqlParameter("@khoa", khoa));
					Command.Parameters.Add(new SqlParameter("@dk", dk));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable spBenhAn_InLuuTru(string hotenbn, string tungay, string denngay, string khoa, string dk)
		{
			DataTable dr = new DataTable();
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spBenhAn_InLuuTru";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@hotenbn", hotenbn));
					Command.Parameters.Add(new SqlParameter("@tungay", tungay));
					Command.Parameters.Add(new SqlParameter("@denngay", denngay));
					Command.Parameters.Add(new SqlParameter("@khoa", khoa));
					Command.Parameters.Add(new SqlParameter("@dk", dk));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		//[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spBenhAn_DeNghiTrichLuc_CREATEOrUpdate")]
		//public int spBenhAn_DeNghiTrichLuc_CREATEOrUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "TinyInt")] byte LoaiDeNghi, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string MaBA, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string HoTenNguoiDeNghi, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string NgaySinhNguoiDN, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string SoCMT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string NgayCapCMT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(500)")] string NoiCapCMT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(250)")] string QHBN, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string HoTenBN, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(500)")] string DiaChi, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(250)")] string TGVQ, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string MaKhoaDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string TuNgayDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string DenNgayDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(500)")] string LyDo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string MaMay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string NguoiLap, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Decimal")] Decimal sophieu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool Duyet, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(50)")] string ngayduyet, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")] bool huy)
		//{
		//	IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), LoaiDeNghi, MaBA, HoTenNguoiDeNghi, NgaySinhNguoiDN, SoCMT, NgayCapCMT, NoiCapCMT, QHBN, HoTenBN, DiaChi, TGVQ, MaKhoaDT, TuNgayDT, DenNgayDT, LyDo, MaMay, NguoiLap, sophieu, Duyet, ngayduyet, huy);
		//	//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
		//	//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
		//	var list = (int)result.ReturnValue;
		//	return list;
		//}
		public decimal spBenhAn_DeNghiTrichLuc_CREATEOrUpdate(byte LoaiDeNghi, string MaBA, string HoTenNguoiDeNghi, string NgaySinhNguoiDN, string SoCMT, string NgayCapCMT, string NoiCapCMT,string QHBN, string HoTenBN, string DiaChi, string TGVQ, string MaKhoaDT, string TuNgayDT, string DenNgayDT, string LyDo, string MaMay, string NguoiLap, Decimal sophieu, bool Duyet, string ngayduyet, bool huy, string dvct, string NhamLan, string CMNhamLan, string MatRach)
		{
			DataTable dr = new DataTable();
			//dr.TableName = "DMChucVu";
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spBenhAn_DeNghiTrichLuc_CREATEOrUpdate";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@LoaiDeNghi", LoaiDeNghi));
					Command.Parameters.Add(new SqlParameter("@MaBA", MaBA));
					Command.Parameters.Add(new SqlParameter("@HoTenNguoiDeNghi", HoTenNguoiDeNghi));
					Command.Parameters.Add(new SqlParameter("@NgaySinhNguoiDN", NgaySinhNguoiDN));
					Command.Parameters.Add(new SqlParameter("@SoCMT", SoCMT));
					Command.Parameters.Add(new SqlParameter("@NgayCapCMT", NgayCapCMT));
					Command.Parameters.Add(new SqlParameter("@NoiCapCMT", NoiCapCMT));
					Command.Parameters.Add(new SqlParameter("@QHBN", QHBN));
					Command.Parameters.Add(new SqlParameter("@HoTenBN", HoTenBN));
					Command.Parameters.Add(new SqlParameter("@DiaChi", DiaChi));
					Command.Parameters.Add(new SqlParameter("@TGVQ", TGVQ));
					Command.Parameters.Add(new SqlParameter("@MaKhoaDT", MaKhoaDT));
					Command.Parameters.Add(new SqlParameter("@TuNgayDT", TuNgayDT));
					Command.Parameters.Add(new SqlParameter("@DenNgayDT", DenNgayDT));
					Command.Parameters.Add(new SqlParameter("@LyDo", LyDo));
					Command.Parameters.Add(new SqlParameter("@MaMay", MaMay));
					Command.Parameters.Add(new SqlParameter("@NguoiLap", NguoiLap));
					Command.Parameters.Add(new SqlParameter("@sophieu", sophieu));
					Command.Parameters.Add(new SqlParameter("@Duyet", Duyet));
					Command.Parameters.Add(new SqlParameter("@ngayduyet", ngayduyet));
					Command.Parameters.Add(new SqlParameter("@huy", huy));
					Command.Parameters.Add(new SqlParameter("@DVCT", dvct));
					Command.Parameters.Add(new SqlParameter("@NhamLan", NhamLan));
					Command.Parameters.Add(new SqlParameter("@CMNhamLan", CMNhamLan));
					Command.Parameters.Add(new SqlParameter("@MatRach", MatRach));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				if (dr.Rows.Count > 0)
					return decimal.Parse(string.IsNullOrEmpty(dr.Rows[0][0].ToString()) ? "0" : dr.Rows[0][0].ToString());
				else
					return 0;
			}
		}
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.spBenhAn_DeNghiTrichLuc_DELETED")]
		public int spBenhAn_DeNghiTrichLuc_DELETED([global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string sophieu, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string MAMAY, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")] string NGUOISD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sophieu, MAMAY, NGUOISD);
			//IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCV, tenCV, maMay, ngaySD, nguoiSD, index, pageSize, add);
			//var list = this.DbContext.Database.SqlQuery<DMChucVuVm>("spDMCHUCVU_GetAllPaging @MaCD, @TenCD, @MaMay, @NgaySD, @NguoiSD, @PageIndex, @PageSize, @add", paras).ToList();
			var list = (int)(result.ReturnValue);
			return list;
		}
		public DataTable spBenhAn_DeNghiTrichLuc_Print(string sophieu)
		{
			DataTable dr = new DataTable();
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spBenhAn_DeNghiTrichLuc_Print";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@sophieu", sophieu));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}
		public DataTable spBenhAn_DeNghiTrichLuc_PrintHSBA(string sophieu)
		{
			DataTable dr = new DataTable();
			var conn = System.Configuration.ConfigurationManager.ConnectionStrings["Medyx_EMR_BCA_SQLConnectionString"].ConnectionString;
			string tenStore = "spBenhAn_DeNghiTrichLuc_PrintHSBA";
			using (SqlConnection Conection = new SqlConnection(conn))
			{
				Conection.Open();
				using (SqlCommand Command = new SqlCommand(tenStore, Conection))
				{
					Command.CommandType = CommandType.StoredProcedure;
					Command.Parameters.Add(new SqlParameter("@sophieu", sophieu));
					SqlDataAdapter dp = new SqlDataAdapter(Command);
					dp.Fill(dr);
				}
				//if (dr.Rows.Count > 0)
				return dr;
				//else
				//    return "";
			}
		}

     
        #endregion
    }
}
