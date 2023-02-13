using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using System.Reflection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.IO.Compression;
using System.Xml;
using System.Text;
using System.Xml.Serialization;
using Medyx_EMR_BCA.ApiAssets.Models;

namespace Medyx_EMR_BCA.Models.DBConText
{
	public partial class spACCOUNT_Get
	{
		public Int32 Ordernumber { get; set; }
		public String GhiChu { get; set; }
		public String MaNV { get; set; }
		public String Account { get; set; }
		public String Password { get; set; }
		public String MaKhoaLS { get; set; }
		public String MaKhoaCLS { get; set; }
		public String MaKho { get; set; }
		public Boolean AllMaKho { get; set; }
		public Boolean AllMaKhoaCLS { get; set; }
		public Boolean AllMaKhoaLS { get; set; }
		public String QuyenDTuong { get; set; }
		public Boolean AllQuyenDTuong { get; set; }
		public String MaMay { get; set; }
		public Boolean Huy { get; set; }
		public DateTime NgaySD { get; set; }
		public String NguoiSD { get; set; }
		public Boolean Qadmin { get; set; }
		public Boolean Qsgia { get; set; }
		public String HoTen { get; set; }
		public String tennguoisd { get; set; }

		public spACCOUNT_Get()
		{
			GhiChu = "";
			MaNV = "";
			Account = "";
			Password = "";
			MaKhoaLS = "";
			MaKhoaCLS = "";
			MaKho = "";
			AllMaKho = false;
			AllMaKhoaCLS = false;
			AllMaKhoaLS = false;
			QuyenDTuong = "";
			AllQuyenDTuong = false;
			MaMay = "";
			Huy = false;
			NgaySD = new DateTime();
			NguoiSD = "";
			Qadmin = false;
			Qsgia = false;
			HoTen = "";
			tennguoisd = "";
			Ordernumber = 0;
		}
	}
	public partial class MenuUserVm
	{
		public String MenuID { get; set; }
		public String MenuName { get; set; }
		public Int32? Level { get; set; }
		public String MenuParent { get; set; }
		public String ControllerName { get; set; }
	}
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Tên đăng nhập")]
		public string userName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
	}
	public class ResetPassword
	{
		[Required]
		[Display(Name = "Tên đăng nhập")]
		public string userName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "PasswordCu")]
		public string PasswordCu { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "PasswordMoi")]
		public string PasswordMoi { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "PasswordNhapLai")]
		public string PasswordNhapLai { get; set; }
	}
	[Serializable]
	public class UserProfileSessionData
	{
		public string Pub_sNguoiSD { get; set; }
		public string Pub_sAccount { get; set; }
		public string Pub_sTenNguoiSD { get; set; }
		public string Pub_sQuay { get; set; }
		public bool Pub_bQadmin { get; set; }
		public bool Pub_bSgia { get; set; }
		public string MongoDBConnectionString { get; set; }
		public string MongoDBDataBaseName { get; set; }
		public IEnumerable<RoleUserVm> ListRoleSession { get; set; }
		public List<Dmkhoa> DMKhoaAcc { get; set; }
	}
	public class RoleUserVm
	{
		public Int64 ApplicationActionDetailsId { get; set; }
		public String ActionDetailsName { get; set; }
		public Int32? Status { get; set; }
		public String ActionName { get; set; }
		public Int64? ApplicationActionId { get; set; }
	}
	public static class SessionHelper
	{
		public static void SetObjectAsJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T GetObjectFromJson<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}
	}
	public class BCAController : Controller
	{
		//private readonly IConfiguration _config;
		//public BCAController(IConfiguration config)
		//{
		//	_config = config;
		//}
		public ActionResult Khoitao(IMemoryCache cache)
		{
			var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
			if (u != null)
			{
				if (u.Pub_sNguoiSD.Length == 0)
					return RedirectToAction("Login", "Login");
				else
				{
					HL7CoreDataDataContext db = new HL7CoreDataDataContext();
					List<MenuUserVm> Menu = cache.Get<List<MenuUserVm>>("Menu" + u.Pub_sNguoiSD);
					//if (!cache.TryGetValue<IEnumerable<MenuUserVm>>("Menu" + u.Pub_sNguoiSD, out Menu))
					if (Menu == null)
					{
						Menu = db.GetAllMenuByUserId(u.Pub_sAccount).ToList();
						//set cache 30 ngay
						cache.Set<List<MenuUserVm>>("Menu" + u.Pub_sNguoiSD, Menu, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(30)));
						
					}
					//else Menu = cache.Get<object>("Menu" + u.Pub_sNguoiSD);
					ViewData["Menu"] = Menu;
					ViewData["UserProfileSessionData"] = u;
					return View();
				}
			}
			else return RedirectToAction("Login", "Login");
		}
		protected ActionResult GetErrorResult(IdentityResult result)
		{
			if (result == null)
			{
				return View(); //
			}

			if (!result.Succeeded)
			{
				if (result.Errors != null)
				{
					foreach (string error in result.Errors)
					{
						ModelState.AddModelError("", error);
					}
				}

				if (ModelState.IsValid)
				{
					// No ModelState errors are available to send, so just return an empty BadRequest.
					return View();// Action tới View Error
				}

				return View();// Action tới View Error như nhau :D
			}

			return null;
		}
		protected JsonResult CreateJsonJsonResult(System.Func<JsonResult> function)
		{
			var obj = function.Invoke();
			try
			{
				return obj;
			}
			catch (Exception ex)
			{
				//LogError(ex);
				return null;
			}
		}
		protected string GetLocalIPAddress()
		{
			var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
			//var host = Dns.GetHostEntry(Dns.GetHostName());
			//foreach (var ip in host.AddressList)
			//{
			//	if (ip.AddressFamily == AddressFamily.InterNetwork)
			//	{
			//		return ip.ToString();
			//	}
			//}
			//throw new Exception("Local IP Address Not Found!");
			return remoteIpAddress.ToString();
		}
		public void ExportToExcel(string fileName, System.Data.DataTable dataSource)
		{
			ExcelPackage excel = new ExcelPackage();
			var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
			//workSheet.Cells[1, 1].Value = header;
			for (int j = 0; j < dataSource.Columns.Count; j++)
			{
				workSheet.Cells[1, j + 1].Value = dataSource.Columns[j].ColumnName;
			}
			for (int i = 0; i < dataSource.Rows.Count; i++)
			{
				for (int j = 0; j < dataSource.Columns.Count; j++)
				{
					workSheet.Cells[i + 2, j + 1].Value = dataSource.Rows[i][j].ToString();
				}
			}
			for (int j = 1; j <= dataSource.Columns.Count; j++)
			{
				workSheet.Column(j).AutoFit();
			}
			using (var memoryStream = new MemoryStream())
			{
				Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
				Response.Headers.Add("content-disposition", "attachment; filename=" + fileName);
				excel.SaveAs(memoryStream);
				memoryStream.WriteTo(Response.Body);
				memoryStream.Close();
				//Response.Flush();
				//Response.Clear();
			}

		}
		public FileStreamResult PrintReportPDF(string reportpath, string filename, ReportDocument rpt, IConfiguration _config)
		{
			try
			{
				string webRootPath = _config.GetValue<string>("ReportDirectory");
				string reportfilename = webRootPath + reportpath;
				string path = webRootPath + "\\temp\\" + DateTime.Now.AddDays(-1).Month.ToString() + DateTime.Now.AddDays(-1).Day.ToString();
				string fileName = path + filename;
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				if (System.IO.File.Exists(fileName))
				{
					System.IO.File.Delete(fileName);
				}
				CrystalDecisions.Shared.ExportRequestContext reqContext = new CrystalDecisions.Shared.ExportRequestContext();
				var exportOptions2 = new CrystalDecisions.Shared.ExportOptions
				{
					ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
					FormatOptions = new CrystalDecisions.Shared.PdfFormatOptions { UsePageRange = false, FirstPageNumber = 1, LastPageNumber = 1 }
				};
				reqContext.ExportInfo = exportOptions2;
				var stream2 = rpt.FormatEngine.ExportToStream(reqContext);
				stream2.Seek(0, SeekOrigin.Begin);
				var combinedPdf = new PdfSharp.Pdf.PdfDocument();
				int i = 0;
				foreach (PdfSharp.Pdf.PdfPage page in PdfSharp.Pdf.IO.PdfReader.Open(stream2, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import).Pages)
				{
					combinedPdf.AddPage(page);
					i++;
				}
				combinedPdf.Save(fileName);
				rpt.Close();
				rpt.Dispose();
				FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				return File(fs, "application/pdf");
			}
			catch (Exception ex)
			{
				WriteLog("PrintReportPDF Error: " + ex.ToString());
				return null;
			}
		}
		public FileStreamResult PrintPDF(string reportpath, string filename, DataTable dt, IConfiguration _config)
		{
			try
			{
				//string webRootPath = AppDomain.CurrentDomain;
				//var webRootPath = Directory.GetCurrentDirectory()+"\\ReportHSBA";
				//var webRootPath = ConfigurationManager.AppSettings["ReportDirectory"];
				//WriteLog("bat dau");
				string webRootPath = _config.GetValue<string>("ReportDirectory");
				//WriteLog("webRootPath: " + webRootPath);
				ReportDocument rpt = new ReportDocument();
				string reportfilename = webRootPath + reportpath;
				//WriteLog("reportfilename: "+ reportfilename);
				rpt.Load(reportfilename);//Crystal Report Path
				rpt.SetDataSource(dt);//Get data source. All the data can be read in SQL.
				string path = webRootPath + "\\temp\\" + DateTime.Now.AddDays(-1).Month.ToString() + DateTime.Now.AddDays(-1).Day.ToString();
				//WriteLog("path: " + path);
				string fileName = path + filename;

				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				if (System.IO.File.Exists(fileName))
				{
					System.IO.File.Delete(fileName);
				}
				CrystalDecisions.Shared.ExportRequestContext reqContext = new CrystalDecisions.Shared.ExportRequestContext();
				var exportOptions2 = new CrystalDecisions.Shared.ExportOptions
				{
					ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
					FormatOptions = new CrystalDecisions.Shared.PdfFormatOptions { UsePageRange = false, FirstPageNumber = 1, LastPageNumber = 1 }
				};
				reqContext.ExportInfo = exportOptions2;
				var stream2 = rpt.FormatEngine.ExportToStream(reqContext);
				stream2.Seek(0, SeekOrigin.Begin);

				// //// merge the two PDF streams
				var combinedPdf = new PdfSharp.Pdf.PdfDocument();

				// //foreach (PdfPage page in PdfReader.Open(stream1, PdfDocumentOpenMode.Import).Pages)
				// //    combinedPdf.AddPage(page);
				int i = 0;
				foreach (PdfSharp.Pdf.PdfPage page in PdfSharp.Pdf.IO.PdfReader.Open(stream2, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import).Pages)
				{
					//if ((filename.Contains("crBCHoadon") == true || filename.Contains("CRPhieuTamThu") == true || filename.Contains("CRPhieuChi") == true) && i == 0)
					//	combinedPdf.AddPage(page);
					//else if ((filename.Contains("crBCHoadon") == true || filename.Contains("CRPhieuTamThu") == true || filename.Contains("CRPhieuChi") == true) && i > 0)
					//{
					//}
					//else if (!(filename.Contains("crBCHoadon") == true || filename.Contains("CRPhieuTamThu") == true || filename.Contains("CRPhieuChi") == true))
					combinedPdf.AddPage(page);
					i++;

				}

				//// probably not the most efficient, but works
				//  var output = new MemoryStream();
				combinedPdf.Save(fileName);
				rpt.Close();
				rpt.Dispose();

				FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				return File(fs, "application/pdf");
				//return fileName;
			}
			catch (Exception ex)
			{
				WriteLog("PrintPDF Error: " + ex.ToString());
				return null;
			}
		}
		public FileStreamResult PrintZip(string reportpath, string filename, DataTable dt, IConfiguration _config)
		{
			#region PDF file
			//string webRootPath = AppDomain.CurrentDomain;
			//var webRootPath = Directory.GetCurrentDirectory()+"\\ReportHSBA";
			//var webRootPath = ConfigurationManager.AppSettings["ReportDirectory"];

			string webRootPath = _config.GetValue<string>("ReportDirectory");
			string HSBARootPath = _config.GetValue<string>("HSBADirectory");
			ReportDocument rpt = new ReportDocument();
			string reportfilename = webRootPath + reportpath;
			rpt.Load(reportfilename);//Crystal Report Path
			rpt.SetDataSource(dt);//Get data source. All the data can be read in SQL.
								  //string path = webRootPath + "\\temp\\" + DateTime.Now.AddDays(-1).Month.ToString() + DateTime.Now.AddDays(-1).Day.ToString();
			string MaMay = this.GetLocalIPAddress();
			string path = webRootPath + "\\temp\\" + DateTime.Now.AddDays(-1).Month.ToString() + DateTime.Now.AddDays(-1).Day.ToString() + "\\" + DateTime.Now.ToString("dd/MM/yyyyHHmm");
			string fileName = path + filename;

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			if (System.IO.File.Exists(fileName))
			{
				System.IO.File.Delete(fileName);
			}
			CrystalDecisions.Shared.ExportRequestContext reqContext = new CrystalDecisions.Shared.ExportRequestContext();
			var exportOptions2 = new CrystalDecisions.Shared.ExportOptions
			{
				ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat,
				FormatOptions = new CrystalDecisions.Shared.PdfFormatOptions { UsePageRange = false, FirstPageNumber = 1, LastPageNumber = 1 }
			};
			reqContext.ExportInfo = exportOptions2;
			var stream2 = rpt.FormatEngine.ExportToStream(reqContext);
			stream2.Seek(0, SeekOrigin.Begin);

			// //// merge the two PDF streams
			var combinedPdf = new PdfSharp.Pdf.PdfDocument();

			// //foreach (PdfPage page in PdfReader.Open(stream1, PdfDocumentOpenMode.Import).Pages)
			// //    combinedPdf.AddPage(page);
			int i = 0;
			foreach (PdfSharp.Pdf.PdfPage page in PdfSharp.Pdf.IO.PdfReader.Open(stream2, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import).Pages)
			{
				//if ((filename.Contains("crBCHoadon") == true || filename.Contains("CRPhieuTamThu") == true || filename.Contains("CRPhieuChi") == true) && i == 0)
				//	combinedPdf.AddPage(page);
				//else if ((filename.Contains("crBCHoadon") == true || filename.Contains("CRPhieuTamThu") == true || filename.Contains("CRPhieuChi") == true) && i > 0)
				//{
				//}
				//else if (!(filename.Contains("crBCHoadon") == true || filename.Contains("CRPhieuTamThu") == true || filename.Contains("CRPhieuChi") == true))
				combinedPdf.AddPage(page);
				i++;

			}

			//// probably not the most efficient, but works
			//  var output = new MemoryStream();
			combinedPdf.Save(fileName);

			//FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			////ZipFile.CreateFromDirectory(startPath, zipPath);
			//return File(fs, "application/pdf");
			////return fileName;
			#endregion

			#region Zip
			//tao file zip chua all tai lieu HSBA
			DataRow[] contains = dt.Select("LoaiDeNghi = 1");
			foreach (var r in contains)
			{
				string maba = r["MaBA"].ToString();
				string startPath = HSBARootPath + "\\" + maba;
				string zipPath = path + "\\" + maba + ".zip";
				if (maba.Trim().Length > 0)
					ZipFile.CreateFromDirectory(startPath, zipPath);
			}
			string zpath = webRootPath + "\\temp\\" + DateTime.Now.AddDays(-1).Month.ToString() + DateTime.Now.AddDays(-1).Day.ToString() + "\\PhotoHSBA.zip";
			//tao file zip chua all file can xuat ra
			ZipFile.CreateFromDirectory(path, zpath);
			FileStream fs = new FileStream(zpath, FileMode.Open, FileAccess.Read);
			return File(fs, "application/zip");
			#endregion
		}
        public FileContentResult PrintXML(string filename, List<Bundle> dt, IConfiguration _config)
        //public ActionResult PrintXML(string filename, object dt, IConfiguration _config)
		{
			try
			{
				//string webRootPath = _config.GetValue<string>("ReportDirectory");
				//string path = webRootPath + "\\temp\\" + DateTime.Now.AddDays(-1).Month.ToString() + DateTime.Now.AddDays(-1).Day.ToString();
				//string fileName = path + filename;

				//if (!Directory.Exists(path))
				//{
				//    Directory.CreateDirectory(path);
				//}
				//if (System.IO.File.Exists(fileName))
				//{
				//    System.IO.File.Delete(fileName);
				//}
				//XmlDocument xmldoc = SerializeToXmlDocument(dt);
				//xmldoc.Save(fileName);
				//FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				//return File(fs, "application/xml");
				////return Ok(xmldoc);
				if (dt.Count > 0)
				{
					using (var memoryStream = new MemoryStream())
					{
						using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
						{
							//var file1 = archive.CreateEntry("file1.txt");
							//using (var streamWriter = new StreamWriter(file1.Open()))
							//{
							//	streamWriter.Write("content1");
							//}

							//var file2 = archive.CreateEntry("file2.txt");
							//using (var streamWriter = new StreamWriter(file2.Open()))
							//{
							//	streamWriter.Write("content2");
							//}
							for (int i = 0; i < dt.Count; i++)
							{

								var file1 = archive.CreateEntry(dt[i].identifier.value + ".xml");
                                using (var streamWriter = new StreamWriter(file1.Open()))
                                {
									//XmlDocument xmldoc = SerializeToXmlDocument(dt[i]);
									//streamWriter.Write(xmldoc.InnerXml);

									//var stringwriter = new System.IO.StringWriter();
									//var serializer = new XmlSerializer(typeof(Bundle));
									//serializer.Serialize(stringwriter, dt[i]);
									//streamWriter.Write(stringwriter.ToString());

									//XmlSerializer xsSubmit = new XmlSerializer(typeof(Bundle));

									//XmlDocument doc = new XmlDocument();

									//System.IO.StringWriter sww = new System.IO.StringWriter();
									//XmlWriter writer = XmlWriter.Create(sww);
									//xsSubmit.Serialize(writer, dt[i]);
									//var xml = sww.ToString();
									//streamWriter.Write(xml);

									string jsonText = JsonConvert.SerializeObject(dt[i],
							Newtonsoft.Json.Formatting.None,
							new JsonSerializerSettings
							{
								NullValueHandling = NullValueHandling.Ignore,DateFormatString = "yyyy-MM-ddThh:mm:ssZ"
							});

									// To convert JSON text contained in string json into an XML node
									XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonText);

									streamWriter.Write(doc);
								}
                            }
						}

						return File(memoryStream.ToArray(), "application/zip");
					}
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				WriteLog("PrintXML Error: " + ex.ToString());
				return null;
			}
		}
        public FileContentResult PrintJSON(string filename, List<Bundle> dt, IConfiguration _config)
        //public ActionResult PrintJSON(string filename, object dt, IConfiguration _config)
        //public FileContentResult PrintJSON(string filename, Bundle dt, IConfiguration _config)
        {
			try
			{
				//string webRootPath = _config.GetValue<string>("ReportDirectory");
				//string path = webRootPath + "\\temp\\" + DateTime.Now.AddDays(-1).Month.ToString() + DateTime.Now.AddDays(-1).Day.ToString();

				//string fileName = path + filename;
				//if (!Directory.Exists(path))
				//{
				//    Directory.CreateDirectory(path);
				//}
				//if (System.IO.File.Exists(fileName))
				//{
				//    System.IO.File.Delete(fileName);
				//}
				//TextWriter writer;
				//using (writer = new StreamWriter(fileName, append: false))
				//{
				//    writer.WriteLine(JsonConvert.SerializeObject(dt,
				//            Newtonsoft.Json.Formatting.None,
				//            new JsonSerializerSettings
				//            {
				//                NullValueHandling = NullValueHandling.Ignore
				//            }));
				//}

				//FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				//return File(fs, "application/json");
				////return Ok(JsonConvert.SerializeObject(dt,
				////			Newtonsoft.Json.Formatting.None,
				////			new JsonSerializerSettings
				////			{
				////				NullValueHandling = NullValueHandling.Ignore
				////			}));
				//if (dt.Count > 0)
				//{
					using (var memoryStream = new MemoryStream())
					{
						using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
						{
						//var file1 = archive.CreateEntry("file1.txt");
						//using (var streamWriter = new StreamWriter(file1.Open()))
						//{
						//	streamWriter.Write("content1");
						//}

						//var file2 = archive.CreateEntry("file2.txt");
						//using (var streamWriter = new StreamWriter(file2.Open()))
						//{
						//	streamWriter.Write("content2");
						//}
						for (int i = 0; i < dt.Count; i++)
						{

							var file1 = archive.CreateEntry(dt[i].identifier.value + ".json");
							//var file1 = archive.CreateEntry(dt.identifier.value + ".json");
							using (var streamWriter = new StreamWriter(file1.Open()))
							{
								//XmlDocument xmldoc = SerializeToXmlDocument(dt[i]);
								streamWriter.Write(JsonConvert.SerializeObject(dt[i],
						Newtonsoft.Json.Formatting.None,
						new JsonSerializerSettings
						{
							NullValueHandling = NullValueHandling.Ignore,
							DateFormatString = "yyyy-MM-ddThh:mm:ssZ"
						}));
							}
						}
                    }

						return File(memoryStream.ToArray(), "application/zip");
					}
				//}
				//else
				//	return null;
			}
			catch (Exception ex)
			{
				WriteLog("PrintXML Error: " + ex.ToString());
				return null;
			}
		}
		public static DataTable CreateDataTable(IEnumerable source)
		{
			if (source != null)
			{
				var table = new DataTable();
				int index = 0;
				var properties = new List<PropertyInfo>();
				foreach (var obj in source)
				{
					if (index == 0)
					{
						foreach (var property in obj.GetType().GetProperties())
						{
							if (Nullable.GetUnderlyingType(property.PropertyType) != null)
							{
								//if(property.PropertyType.FullName.Contains("DateTime"))
								if (property.PropertyType == typeof(DateTime?))
								{

									properties.Add(property);
									table.Columns.Add(new DataColumn(property.Name, typeof(DateTime)));
								}
								continue;
							}
							properties.Add(property);
							table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
						}
					}
					object[] values = new object[properties.Count];
					for (int i = 0; i < properties.Count; i++)
					{
						values[i] = properties[i].GetValue(obj);
					}
					table.Rows.Add(values);
					index++;
				}
				return table;
			}
			else
				return null;
		}
		public void WriteLog(String log)
		{
			var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
			#region ghi log
			//string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
			//string constr = _config.GetValue<string>("Medyx_BCADatabase:ConnectionString");
			string constr = u.MongoDBConnectionString;
			var client = new MongoClient(constr);
			//IMongoDatabase db = client.GetDatabase("Medyx_BCA");
			//IMongoDatabase dbm = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
			//IMongoDatabase dbm = client.GetDatabase(_config.GetValue<string>("Medyx_BCADatabase:DatabaseName"));
			IMongoDatabase dbm = client.GetDatabase(u.MongoDBDataBaseName);
			IMongoCollection<TraceLogMongo> collection = dbm.GetCollection<TraceLogMongo>("TraceLog");
			string MaMay = this.GetLocalIPAddress();
			TraceLogMongo emp = new TraceLogMongo();
			emp.NgaySD = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
			emp.TenBang = "ErrorLoag";
			emp.KieuTacDong = "Error";
			emp.NguoiSD = u.Pub_sNguoiSD;
			emp.MaMay = MaMay;
			emp.NoiDungSD = log;
			collection.InsertOne(emp);
			#endregion
		}
		//public XmlDocument SerializeToXmlDocument(object input)
		//{
		//	XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");

		//	XmlDocument xd = null;

		//	using (MemoryStream memStm = new MemoryStream())
		//	{
		//		ser.Serialize(memStm, input);

		//		memStm.Position = 0;

		//		XmlReaderSettings settings = new XmlReaderSettings();
		//		settings.IgnoreWhitespace = true;

		//		using (var xtr = XmlReader.Create(memStm, settings))
		//		{
		//			xd = new XmlDocument();
		//			xd.Load(xtr);
		//		}
		//	}

		//	return xd;
		//}
		//public static string Serialize<T>(T dataToSerialize)
		//{
		//	try
		//	{
		//		var stringwriter = new System.IO.StringWriter();
		//		var serializer = new XmlSerializer(typeof(T));
		//		serializer.Serialize(stringwriter, dataToSerialize);
		//		return stringwriter.ToString();
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}
	}
	public class PaginationSet<T>
	{
		public int Page { set; get; }
		public IEnumerable<T> Items { get; set; }
		public int Count
		{
			get
			{
				return (Items != null) ? Items.Count() : 0;
			}
			//get;set;
		}
		public bool EditRole { set; get; }
		public bool DeleteRole { get; set; }
		public int TotalPages { get; set; }
		public int TotalCounts { get; set; }

        internal object ToList()
        {
            throw new NotImplementedException();
        }
    }
	public class DatabaseSettings
	{
		public string ConnectionString { get; set; }
	}
	#region HL7
	[XmlInclude(typeof(Composition))]
	[Serializable]
	public class Age : Quantity
	{ }
	[Serializable]
	public class Annotation
	{
		public Reference authorReference { get; set; }
		public string authorString { get; set; }
		public DateTime time { get; set; }
		public string text { get; set; }
	}
	[Serializable]
	public class Attachment
	{
		public string contentType { get; set; }
		public string language { get; set; }
		public string data { get; set; }
		public string url { get; set; }
		public uint size { get; set; }
		public string hash { get; set; }
		public string title { get; set; }
		public DateTime creation { get; set; }
	}
	[Serializable]
	public class Range
	{
		public Quantity low { get; set; }
		public Quantity high { get; set; }
	}
	[Serializable]
	public class Identifier
	{
		public string use { get; set; }
		public CodeableConcept type { get; set; }
		public string system { get; set; }
		public string value { get; set; }
		public Period period { get; set; }
		public Reference assigner { get; set; }
	}
	[Serializable]
	public class Narrative
	{
		public string status { get; set; }
		public string div { get; set; }
	}
	[Serializable]
	public class Timing
	{
		public List<DateTime> Event { get; set; }
		public Repeat repeat { get; set; }
		public CodeableConcept code { get; set; }
	}
	[Serializable]
	public class Repeat
	{
		public bounds bounds { get; set; }
		public uint count { get; set; }
		public uint countMax { get; set; }
		public decimal duration { get; set; }
		public decimal durationMax { get; set; }
		public string durationUnit { get; set; }
		public uint frequency { get; set; }
		public uint frequencyMax { get; set; }
		public decimal period { get; set; }
		public decimal periodMax { get; set; }
		public string periodUnit { get; set; }
		public List<string> dayOfWeek { get; set; }
		public List<string> timeOfDay { get; set; }
		public List<string> when { get; set; }
		public uint offset { get; set; }
	}
	[Serializable]
	public class bounds
	{
		public Duration boundsDuration { get; set; }
		public Range boundsRange { get; set; }
		public Period boundsPeriod { get; set; }
	}
	[Serializable]
	public class SampledData
	{
		public Quantity origin { get; set; }
		public decimal period { get; set; }
		public decimal factor { get; set; }
		public decimal lowerLimit { get; set; }
		public decimal upperLimit { get; set; }
		public uint dimensions { get; set; }
		public string data { get; set; }
	}
	[Serializable]
	public class Quantity
	{
		public decimal value { get; set; }
		public string comparator { get; set; }
		public string unit { get; set; }
		public string system { get; set; }
		public string code { get; set; }
	}
	[Serializable]
	public class Ratio
	{
		public Quantity numerator { get; set; }
		public Quantity denominator { get; set; }
	}
	[Serializable]
	public class SimpleQuantity
	{
		public decimal value { get; set; }
		public string currency { get; set; }
	}
	[Serializable]
	public class Duration : Quantity
	{ }
	[Serializable]
	public class Coding
	{
		public string system { get; set; }
		public string version { get; set; }
		public string code { get; set; }
		public string display { get; set; }
		public Boolean userSelected { get; set; }
	}
	[Serializable]
	public class CodeableConceptIPS
	{
		public Coding coding { get; set; }
	}
	[Serializable]
	public class Reference
	{
		public string reference { get; set; }
		public string type { get; set; }
		public Identifier identifier { get; set; }
		public string display { get; set; }
	}
	[Serializable]
	public class scheduled
	{
		public Timing scheduledTiming { get; set; }
		public Period scheduledPeriod { get; set; }
		public string scheduledString { get; set; }
	}
	[Serializable]
	public class Composition
	{

		public string resourceType { get; set; }
		public string text { get; set; }
		public Identifier identifier { get; set; }
		public string status { get; set; }
		public CodeableConceptIPS type { get; set; }
		public Reference subject { get; set; }
		public Reference encounter { get; set; }
		public DateTime date { get; set; }
		public Reference author { get; set; }
		public string title { get; set; }
		public BackboneElement attester { get; set; }
		public Reference custodian { get; set; }
		public List<BackboneElement> Event { get; set; }
		public List<BackboneElement> section { get; set; }
	}
	[Serializable]
	public class ClinicalImpression
	{
		public Identifier identifier { get; set; }
		public string status { get; set; }
		public CodeableConcept statusReason { get; set; }
		public CodeableConcept code { get; set; }
		public string description { get; set; }
		public Reference subject { get; set; }
		public Reference encounter { get; set; }
		public Period effective { get; set; }
		public DateTime date { get; set; }
		public Reference assessor { get; set; }
		public Reference previous { get; set; }
		public Reference problem { get; set; }
		public BackboneElement investigation { get; set; }
		public string protocol { get; set; }
		public string summary { get; set; }
		public BackboneElement finding { get; set; }
		public CodeableConcept pronosisCodeableConcept { get; set; }
		public Reference pronosisReference { get; set; }
		public Reference supportingInfo { get; set; }
		public Annotation note { get; set; }
	}
	[Serializable]
	public class CarePlan
	{
		public Identifier identifier { get; set; }
		public string instantiatesUri { get; set; }
		public Reference basedOn { get; set; }
		public Reference replaces { get; set; }
		public Reference partOf { get; set; }
		public string status { get; set; }
		public string intent { get; set; }
		public CodeableConcept category { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public Reference subject { get; set; }
		public Reference encounter { get; set; }
		public Period period { get; set; }
		public DateTime created { get; set; }
		public Reference author { get; set; }
		public Reference contributor { get; set; }
		public Reference careTeam { get; set; }
		public Reference addresses { get; set; }
		public Reference supportingInfo { get; set; }
		public Reference goal { get; set; }
		public BackboneElement activities { get; set; }
		public Annotation note { get; set; }
	}
	[Serializable]
	public class Consent
	{
		public Identifier identifier { get; set; }
		public string status { get; set; }
		public CodeableConcept scope { get; set; }
		public CodeableConcept category { get; set; }
		public Reference patient { get; set; }
		public DateTime dateTime { get; set; }
		public Reference performer { get; set; }
		public Reference organization { get; set; }
		public source source { get; set; }
		public BackboneElement policy { get; set; }
		public BackboneElement verification { get; set; }
		public BackboneElement provision { get; set; }
	}
	[Serializable]
	public class AllergyIntolerance
	{
		public DateTime abatement_datetime { get; set; }
		public CodeableConcept clinicalStatus { get; set; }
		public string type { get; set; }
		public string criticality { get; set; }
		public CodeableConcept code { get; set; }
		public Reference patient { get; set; }
		public string onsetString { get; set; }
		public Reference asserter { get; set; }
		public BackboneElement reaction { get; set; }
	}
	[Serializable]
	public class Condition
	{
		public CodeableConcept clinicalStatus { get; set; }
		public CodeableConcept category { get; set; }
		public CodeableConcept severity { get; set; }
		public CodeableConcept code { get; set; }
		public CodeableConcept bodySite { get; set; }
		public Reference subject { get; set; }
		public string onsetString { get; set; }
		public Reference asserter { get; set; }
	}
	[Serializable]
	public class Device_oberver_uv_IPS
	{
		public Identifier identifier { get; set; }
		public string manufacture { get; set; }
		public string modelNumber { get; set; }
	}
	[Serializable]
	public class DeviceIPS
	{
		public CodeableConcept type { get; set; }
		public CodeableConcept absentOrUnknownDevice { get; set; }
		public Reference patient { get; set; }
	}
	[Serializable]
	public class DeviceUseStatement
	{
		public Reference subject { get; set; }
		public Period timing { get; set; }
		public Reference source { get; set; }
		public Reference device { get; set; }
		public CodeableConcept bodySite { get; set; }
	}
	[Serializable]
	public class DiagnosticReport
	{
		public string status { get; set; }
		public CodeableConcept category { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Reference performer { get; set; }
		public Reference specimen { get; set; }
		public Reference result { get; set; }
	}
	[Serializable]
	public class source
	{
		public Attachment sourceAttachment { get; set; }
		public Reference sourceReference { get; set; }
	}
	[Serializable]
	public class Dosage
	{
		public string text { get; set; }
		public Timing timing { get; set; }
		public CodeableConcept route { get; set; }
	}
	[Serializable]
	public class Immunization
	{
		public string status { get; set; }
		public CodeableConcept vaccineCode { get; set; }
		public Reference patient { get; set; }
		public Period occurence { get; set; }
		public CodeableConcept site { get; set; }
		public CodeableConcept route { get; set; }
		public BackboneElement performer { get; set; }
		public BackboneElement protocolApplied { get; set; }
	}
	[Serializable]
	public class Media
	{
		public string status { get; set; }
		public CodeableConcept type { get; set; }
		public Reference subject { get; set; }
		public Reference Operator { get; set; }
		public Reference device { get; set; }
		public Attachment content { get; set; }
	}
	[Serializable]
	public class Medication
	{
		public CodeableConcept code { get; set; }
		public CodeableConcept form { get; set; }
		public BackboneElement ingredient { get; set; }
	}
	[Serializable]
	public class MedicationRequest
	{
		public string status { get; set; }
		public CodeableConcept medication { get; set; }
		public Reference subject { get; set; }
		public Reference requester { get; set; }
		public Dosage dosageInstruction { get; set; }
		public Period validityPeriod { get; set; }
	}
	[Serializable]
	public class MedicationStatement
	{
		public string status { get; set; }
		public CodeableConcept medication { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Reference informationSource { get; set; }
		public Dosage dosage { get; set; }
	}
	[Serializable]
	public class Organization
	{
		public string name { get; set; }
		public string resourceType { get; set; }
		public Identifier identifier { get; set; }
		public Boolean active { get; set; }
		public CodeableConcept type { get; set; }
		public List<string> alias { get; set; }
		public ContactPoint telecom { get; set; }
		public Address address { get; set; }
		public Organization partOf { get; set; }
		public BackboneElement contact { get; set; }
	}
	[Serializable]
	public class Procedure
	{
		public string status { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period performed { get; set; }
		public Reference asserter { get; set; }
		public BackboneElement performer { get; set; }
		public CodeableConcept bodySite { get; set; }
	}
	[Serializable]
	public class ObservationPregnancyEdd
	{
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public DateTime valueDateTime { get; set; }
	}
	[Serializable]
	public class ObservationPregnancyOutcome
	{
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Quantity valueQuantity { get; set; }
	}
	[Serializable]
	public class ObservationPregnancyStatus
	{
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public CodeableConcept valueCodeableConcept { get; set; }
		public Reference hasMember { get; set; }
	}
	[Serializable]
	public class ObservationAlcoholUse
	{
		public string status { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Quantity valueQuantity { get; set; }
	}
	[Serializable]
	public class ObservationTobaccoUse
	{
		public string status { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public CodeableConcept valueCodeableConcept { get; set; }

	}
	[Serializable]
	public class ObservationResults
	{
		public string status { get; set; }
		public CodeableConcept category { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Reference performer { get; set; }
		public Value value { get; set; }
		public Reference hasMember { get; set; }
		public List<BackboneElement> component { get; set; }
	}
	[Serializable]
	public class ObservationResults_Laboratory
	{
		public string status { get; set; }
		public CodeableConcept category { get; set; }
		public Coding coding { get; set; }
		public CodeableConcept code { get; set; }
		public Reference performer { get; set; }
		public Value value { get; set; }
		public CodeableConcept interpretation { get; set; }
		public Reference specimen { get; set; }
		public BackboneElement referenceRange { get; set; }
		public BackboneElement component { get; set; }
		public Reference hasMember { get; set; }
	}
	[Serializable]
	public class ObservationResults_Radiology
	{
		public Reference partOf { get; set; }
		public string status { get; set; }
		public CodeableConcept category { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Reference performer { get; set; }
		public string valueString { get; set; }
		public CodeableConcept bodySite { get; set; }
		public Reference device { get; set; }
		public Reference hasMember { get; set; }
		public BackboneElement component { get; set; }
	}
	[Serializable]
	public class ObservationResults_Pathology
	{
		public CodeableConcept category { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Reference performer { get; set; }
		public Value value { get; set; }
		public Reference specimen { get; set; }
		public Reference hasMember { get; set; }

	}
	//Vital Signs
	[Serializable]
	public class Observation
	{
		public string status { get; set; }
		public CodeableConcept category { get; set; }
		public CodeableConcept code { get; set; }
		public Reference subject { get; set; }
		public Period effective { get; set; }
		public Value value { get; set; }
		public CodeableConcept dataAbsentReason { get; set; }
		public Reference hasMember { get; set; }
		public Reference derivedFrom { get; set; }
		public BackboneElement component { get; set; }
	}
	[Serializable]
	public class Value
	{
		public Quantity valueQuantity { get; set; }
		public string valueString { get; set; }
		public Boolean valueBoolean { get; set; }
		public int valueInteger { get; set; }
		public Ratio valueRatio { get; set; }
		public Range valueRange { get; set; }
		public SampledData valueSampledData { get; set; }
		public string valueTime { get; set; }
		public DateTime valueDateTime { get; set; }
		public Period valuePeriod { get; set; }
		public CodeableConcept valueCodeableConcept { get; set; }
	}
	[Serializable]
	public class Specimen
	{
		public CodeableConcept type { get; set; }
		public Reference subject { get; set; }
		public BackboneElement collection { get; set; }

	}
	[Serializable]
	public class ImangingStudy
	{
		public Identifier identifier { get; set; }
		public Reference subject { get; set; }
		public DateTime started { get; set; }
		public CodeableConcept procedureCode { get; set; }
		public CodeableConcept reasonCode { get; set; }
		public BackboneElement series { get; set; }
	}
	[Serializable]
	public class Period
	{
		public string data_absent_reason { get; set; }
		public DateTime occurenceDateTime { get; set; }
		public string occurenceString { get; set; }
		public DateTime performedDateTime { get; set; }
		public string performedString { get; set; }
		public Age performedAge { get; set; }
		public Range performedRange { get; set; }
		public Timing timingTiming { get; set; }
		public Period timingPeriod { get; set; }
		public DateTime timingDateTime { get; set; }
		public DateTime effectiveDateTime { get; set; }
		public Period effectivePeriod { get; set; }
		public Timing effectiveTiming { get; set; }
		public DateTime effectiveInstant { get; set; }
	}
	[Serializable]
	public class CodeableConcept
	{
		public Coding coding { get; set; }
		public string text { get; set; }
	}
	[Serializable]
	public class fastingStatus
	{
		public CodeableConcept fastingStatusCodeableConcept { get; set; }
		public Duration fastingStatusDuration { get; set; }
	}
	[Serializable]
	public class BackboneElement
	{
		public string fullUrl { get; set; }
		public object resource { get; set; }
		public string mode { get; set; }
		public DateTime? time { get; set; }
		public Reference party { get; set; }
		public CodeableConcept code { get; set; }
		public Period period { get; set; }
		public string title { get; set; }
		public object entry { get; set; }
		public CodeableConcept itemCodeableConcept { get; set; }
		public Ratio strength { get; set; }
		public CodeableConcept manifestation { get; set; }
		public CodeableConcept relationship { get; set; }
		public DateTime? onset { get; set; }
		public string severity { get; set; }
		public Reference actor { get; set; }
		public Reference targetDisease { get; set; }
		public Reference onBehalfOf { get; set; }
		public Value value { get; set; }
		public CodeableConcept dataAbsentReason { get; set; }
		public CodeableConcept interpretation { get; set; }
		public SimpleQuantity low { get; set; }
		public SimpleQuantity high { get; set; }
		public CodeableConcept type { get; set; }
		public CodeableConcept appliesTo { get; set; }
		public Range age { get; set; }
		public string text { get; set; }
		public BackboneElement observationText { get; set; }
		public BackboneElement observationCode { get; set; }
		public BackboneElement numericQuantityMeasurement { get; set; }
		public BackboneElement numericRangeMeasurement { get; set; }
		public BackboneElement numericRatioMeasurement { get; set; }
		public BackboneElement numericSampledDataMeasurement { get; set; }
		public CodeableConcept method { get; set; }
		public CodeableConcept bodySite { get; set; }
		public fastingStatus fastingStatus { get; set; }
		public string uid { get; set; }
		public Coding modality { get; set; }
		public BackboneElement instance { get; set; }
		public Coding sopClass { get; set; }
		public Int32? number { get; set; }
		public Reference item { get; set; }
		public Reference itemReference { get; set; }
		public string basis { get; set; }
		public CodeableConcept outcomeCodeableConcept { get; set; }
		public Reference outcomeReference { get; set; }
		public Annotation progress { get; set; }
		public Reference reference { get; set; }
		public BackboneElement detail { get; set; }
		public string kind { get; set; }
		public string instantiatesCanonical { get; set; }
		public string instantiatesUri { get; set; }
		public CodeableConcept reasonCode { get; set; }
		public Reference reasonReference { get; set; }
		public Reference goal { get; set; }
		public string status { get; set; }
		public CodeableConcept statusReason { get; set; }
		//public Boolean? donotPerform { get; set; }
		public scheduled scheduled { get; set; }
		public Reference location { get; set; }
		public Reference performer { get; set; }
		public product product { get; set; }
		public SimpleQuantity dailyAmount { get; set; }
		public SimpleQuantity quantity { get; set; }
		public string description { get; set; }
		public string authority { get; set; }
		public string uri { get; set; }
		public CodeableConcept Rule { get; set; }
		//public Boolean verified { get; set; }
		public Reference verifiedWith { get; set; }
		public DateTime? verificationDate { get; set; }
		public BackboneElement provisionactor { get; set; }
		public CodeableConcept role { get; set; }
		public CodeableConcept action { get; set; }
		public Coding securityLabel { get; set; }
		public Coding purpose { get; set; }
		public Coding Class { get; set; }
		public Period dataPeriod { get; set; }
		public BackboneElement data { get; set; }
		public string meaning { get; set; }
		public BackboneElement provision { get; set; }
		public HumanName name { get; set; }
		public ContactPoint telecom { get; set; }
		public Address address { get; set; }
		public string gender { get; set; }
		public CodeableConcept language { get; set; }
		//public Boolean preferred { get; set; }
		public Patient other { get; set; }
	}
	[Serializable]
	public class product
	{
		public CodeableConcept productCodeableConcept { get; set; }
		public Reference productReference { get; set; }

	}
	[Serializable]
	public class Bundle
	{
		public string resourceType { get; set; }
		public Identifier identifier { get; set; }
		public string type { get; set; }
		public DateTime timestamp { get; set; }
		//public uint total { get; set; }
		public List<BackboneElement> link { get; set; }
		public List<BackboneElement> entry { get; set; }
		public Signature signature { get; set; }
	}
	[Serializable]
	public class Signature
	{
		public Coding type { get; set; }
		public DateTime when { get; set; }
		public Reference who { get; set; }
		public Reference onBehalfOf { get; set; }
		public string targetFormat { get; set; }
		public string sigFormat { get; set; }
		public string data { get; set; }
	}
	[Serializable]
	public class Resource
	{
		public string id { get; set; }
		public string implicitRules { get; set; }
		public string language { get; set; }
	}
	[Serializable]
	public class Patient
	{
		public string resourceType { get; set; }
		public Identifier identifier { get; set; }
		public Boolean active { get; set; }
		public HumanName name { get; set; }
		public ContactPoint telecom { get; set; }
		public string gender { get; set; }
		public string birthDate { get; set; }
		//public DateTime deceased { get; set; }
		public Boolean deceasedBoolean { get; set; }
		public Address address { get; set; }
		public CodeableConcept maritalStatus { get; set; }
		//public int multipleBirth { get; set; }
		public string multipleBirth { get; set; }
		public Attachment photo { get; set; }
		public BackboneElement contact { get; set; }
		public BackboneElement communication { get; set; }
		public Organization generalPractitioner { get; set; }
		public Organization managingOrganization { get; set; }
		public BackboneElement link { get; set; }

	}
	[Serializable]
	public class HumanName
	{
		public string use { get; set; }
		public string text { get; set; }
		public string family { get; set; }
		public string given { get; set; }
		public string prefix { get; set; }
		public string suffix { get; set; }
		public Period period { get; set; }
	}
	[Serializable]
	public class ContactPoint
	{
		public string system { get; set; }
		public string value { get; set; }
		public string use { get; set; }
		public uint rank { get; set; }
		public Period period { get; set; }
	}
	[Serializable]
	public class Address
	{
		public string use { get; set; }
		public string type { get; set; }
		public string text { get; set; }
		public string line { get; set; }
		public string city { get; set; }
		public string district { get; set; }
		public string state { get; set; }
		public string postalCode { get; set; }
		public string country { get; set; }
		public Period period { get; set; }
	}
	[Serializable]
	public class Endpoint
	{
		public Identifier identifier { get; set; }
		public string status { get; set; }
		public Coding connectionType { get; set; }
		public string name { get; set; }
		public Organization managingOrganization { get; set; }
		public ContactPoint contact { get; set; }
		public Period period { get; set; }
		public CodeableConcept payloadType { get; set; }
		public string payloadMimeType { get; set; }
		public string url { get; set; }
		public string header { get; set; }
	}
	[Serializable]
	public class Practitioner
	{
		public Identifier identifier { get; set; }
		public Boolean active { get; set; }
		public HumanName name { get; set; }
		public ContactPoint telecom { get; set; }
		public Address address { get; set; }
		public string gender { get; set; }
		public DateTime birthDate { get; set; }
		public Attachment photo { get; set; }
		public BackboneElement qualification { get; set; }
		public CodeableConcept communication { get; set; }
	}
	#endregion
}