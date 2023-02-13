using System;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data;
using Microsoft.Extensions.Caching.Memory;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Medyx_EMR_BCA.Controllers.HSBA
{
    public class TimKiemHSBAController : BCAController
    {
        #region Khởi tạo
        private IMemoryCache cache;
        private readonly IConfiguration _config;
        //public readonly ISession session;
        public TimKiemHSBAController(IMemoryCache cache, IConfiguration config)
        {
            this.cache = cache;
            _config = config;
            //this.session = HttpContext.Session;
        }
        public ActionResult Index()
        {
            return Khoitao(cache);
        }
        #endregion Khởi tạo
        #region Load danh sách benh nhan

        [HttpGet]
        public JsonResult LoadData(string hotenbn, string tungay, string denngay, string khoa, string dk)
        {
            //var response = _chucDanhService.DMChucDanhGetListPaging(maCD, tenCD, maMay, ngaySD, nguoiSD, pageIndex, pageSize, add);
            //return CreateJsonJsonResult(() =>
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //});
            Pagination db = new Pagination();
            if (string.IsNullOrEmpty(hotenbn))
                hotenbn = "";
            if (string.IsNullOrEmpty(tungay))
                tungay = "";
            if (string.IsNullOrEmpty(denngay))
                denngay = "";
            if (string.IsNullOrEmpty(khoa))
                khoa = "";
            if (string.IsNullOrEmpty(dk))
                dk = "";
            var response = db.FindHSBAByDK(hotenbn, tungay, denngay, khoa, dk);
            return CreateJsonJsonResult(() =>
            {
                return Json(response);
            });
        }

        #endregion
        #region Export dữ liệu theo các cột được chọn
        [HttpGet]
        [Obsolete]
        public ActionResult ExportXML(string dk)
        {
            string[] Dk = dk.Trim().Split(',');
            List<int> DK = Dk.Select(int.Parse).ToList();
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            string constr = u.MongoDBConnectionString;
            var client = new MongoClient(constr);
            IMongoDatabase db = client.GetDatabase(u.MongoDBDataBaseName);
            var HoSoBenhAn = db.GetCollection<BsonDocument>("HoSoBenhAn");
            var HoSoBenhAn_C = db.GetCollection<BsonDocument>("HoSoBenhAn_C");
            //var filter = Builders<BsonDocument>.Filter.Where(x => dk.IndexOf(x.GetElement("Benhan.IDBA").ToString()) >= 0);
            //var filter = Builders<BsonDocument>.Filter.AnyIn("idba", DK);
            //var filter = Builders<BsonDocument>.Filter.In("idba", DK);
            var filter = Builders<BsonDocument>.Filter.AnyIn("idba", DK);
            //var filter = Builders<BsonDocument>.Filter.Eq("idba", 614);
            //var fHSBA = HoSoBenhAn.Find("{ idba: { $regex: " + dk + " } }").ToList();
            var fHSBA = HoSoBenhAn.Find(filter).ToList();
            //var fHSBA = HoSoBenhAn.Find($"{{ idba: {dk} }}").ToList();
            if (fHSBA != null && fHSBA.Count() > 0)
            {
                string fileName = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xml";
                //string url = HttpContext.Request.Host.Value;
                string url = _config.GetValue<string>("HL7Url");
                BsonValue assignedtoValue;
                List<Bundle> b = new List<Bundle>();
                try
                {
                    foreach (var item in fHSBA)
                    {
                        var Benhan = item.TryGetValue("Benhan", out assignedtoValue);
                        if (assignedtoValue != null)
                        {
                            var benhan = item.GetElement("Benhan");
                            var Thongtinbn = item.TryGetValue("ThongTinBN", out assignedtoValue);
                            if (assignedtoValue != null)
                            {
                                var thongtinbn = item.GetElement("ThongTinBN");
                                //var maba = benhan.ElementAt(0).ToString();
                                var maba = item.GetElement("idba").Value.ToString();
                                BsonArray rows = benhan.Value.AsBsonArray;
                                BsonArray rowsbn = thongtinbn.Value.AsBsonArray;
                                //var mabn = item.GetElement("BenhAn[0].MaBN").ToString();
                                var benhan0 = rows.ElementAt(0).AsBsonDocument;
                                var bn0 = rowsbn.ElementAt(0).AsBsonDocument;
                                var mabn = benhan0.TryGetValue("MaBN", out assignedtoValue) ?  assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString(): "" ;
                                var ngaysd = benhan0.TryGetValue("NgaySD", out assignedtoValue) ?  assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "" ;
                                var ngaylap = benhan0.TryGetValue("NgayLap", out assignedtoValue) ?  assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "" ;
                                var bsdt = benhan0.TryGetValue("TenBSDIEUTRI", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "" ;
                                if (bsdt == "")
                                    bsdt = benhan0.TryGetValue("TenNguoiLap", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                var ngayky = benhan0.TryGetValue("NgayKy", out assignedtoValue) ?  assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "" ;
                                var TenBV = benhan0.TryGetValue("TenBV", out assignedtoValue) ?  assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString(): "" ;
                                DateTime d;
                                Bundle bu = new Bundle();
                                bu.resourceType = "Bundle";
                                Identifier i = new Identifier();
                                i.system = url + "Bundle?dk=" + maba;
                                i.value = maba;
                                bu.identifier = i;
                                bu.type = "document";
                                bu.timestamp = DateTime.Now;
                                //bu.total = 1;
                                List<BackboneElement> entry = new List<BackboneElement>();
                                //Composition
                                BackboneElement compos = new BackboneElement();
                                compos.fullUrl = url + "Composition?dk=" + maba; ;
                                Composition co = new Composition();
                                co.resourceType = "Composition";
                                co.identifier = i;
                                co.status = "final";
                                CodeableConceptIPS c = new CodeableConceptIPS();
                                Coding cc = new Coding();
                                cc.system = "http://loinc.org";
                                cc.code = "60591-5";
                                c.coding = cc;
                                co.type = c;
                                Reference r = new Reference();
                                r.reference = url + "Patient?dk=" + maba;
                                co.subject = r;
                                if (ngaysd != null && ngaysd.Length > 0 && DateTime.TryParse(ngaysd, out d) == true)
                                {
                                    co.date = d;
                                }
                                //co.date = ngaysd.Length > 0 ? DateTime.Parse(ngaysd) : DateTime.Parse(ngaylap);
                                Reference ra = new Reference();
                                ra.reference = bsdt;
                                //co.subject = ra;
                                co.title = "International Patient Summary";
                                BackboneElement at = new BackboneElement();
                                at.mode = "personal";
                                if (ngayky != null && ngayky.Length > 0 && DateTime.TryParse(ngayky, out d) == true)
                                {
                                    at.time = d;
                                }
                                Reference rp = new Reference();
                                rp.reference = bsdt;
                                at.party = rp;
                                co.attester = at;
                                Reference rc = new Reference();
                                //rc.reference = TenBV;
                                rc.reference = url + "Organization?dk=" + TenBV;
                                co.custodian = rc;
                                List<BackboneElement> coe = new List<BackboneElement>();
                                List<BackboneElement> cos = new List<BackboneElement>();
                                //lay thong tin kham benh
                                var fCLS = HoSoBenhAn_C.Find(filter).ToList();
                                if (fCLS != null && fCLS.Count() > 0)
                                {
                                    foreach (var cls1 in fCLS)
                                    {
                                        var Cls2 = cls1.TryGetValue("Benhan_CLS", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var cls2 = cls1.GetElement("Benhan_CLS");
                                            BsonArray rowscls = cls2.Value.AsBsonArray;
                                            if (rowscls.Count > 0)
                                            {
                                                for (int j = 0; j < rowscls.Count; j++)
                                                {
                                                    var cls0 = rowscls.ElementAt(j).AsBsonDocument;
                                                    //var cls = cls1.GetElement("Benhan_CLS");
                                                    var ngaykham = cls0.TryGetValue("NgayYLenh", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "" ;
                                                    var machungloai = cls0.TryGetValue("MaChungLoai", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString(): "" ;
                                                    if (machungloai == "1")
                                                    {
                                                        //kham benh
                                                        BackboneElement kb = new BackboneElement();
                                                        CodeableConcept kbc = new CodeableConcept();
                                                        Coding kbcc = new Coding();
                                                        kbcc.code = "PCPR";
                                                        kbcc.system = "http://terminology.hl7.org/CodeSystem/v3-ActClass";
                                                        kbc.coding = kbcc;
                                                        Period p = new Period();
                                                        if (ngaykham != null && ngaykham.Length > 0 && DateTime.TryParse(ngaykham, out d))
                                                            p.occurenceDateTime = d;
                                                        kb.period = p;
                                                        kb.code = kbc;
                                                        coe.Add(kb);
                                                    }
                                                    else if (machungloai == "5")
                                                    {
                                                        //thu thuat
                                                        BackboneElement tty = new BackboneElement();
                                                        tty.title = "History of Procedures Section";
                                                        CodeableConcept ttyc = new CodeableConcept();
                                                        Coding ttycc = new Coding();
                                                        ttycc.system = "http://loinc.org";
                                                        ttycc.code = "47519-4";
                                                        ttyc.coding = ttycc;
                                                        tty.code = ttyc;
                                                        Reference ttye = new Reference();
                                                        ttye.reference = url + "Procedure?dk=" + maba + "-5";
                                                        tty.entry = ttye;
                                                        cos.Add(tty);
                                                    }
                                                }
                                            }
                                        }
                                        //lay thong tin thuoc tay y
                                        var Cls3 = cls1.TryGetValue("BenhAn_ThuocTayY", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var cls3 = cls1.GetElement("BenhAn_ThuocTayY");
                                            BsonArray rowsty = cls3.Value.AsBsonArray;
                                            if (rowsty.Count > 0)
                                            {
                                                //for (int j = 0; j < rowsty.Count; j++)
                                                //{
                                                    //var ty0 = rowsty.ElementAt(j).AsBsonDocument;
                                                    //var ty = cls1.GetElement("Benhan_CLS");
                                                    //var tenthuoc = ty0.TryGetValue("TenBYT", out assignedtoValue) ? "" : assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString();
                                                    //var mathuoc = ty0.TryGetValue("MaBYT", out assignedtoValue) ? "" : assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString();
                                                    BackboneElement tty = new BackboneElement();
                                                    tty.title = "Medication Summary Section";
                                                    CodeableConcept ttyc = new CodeableConcept();
                                                    Coding ttycc = new Coding();
                                                    ttycc.system = "http://loinc.org";
                                                    ttycc.code = "10160-0";
                                                    ttyc.coding = ttycc;
                                                    tty.code = ttyc;
                                                    Reference ttye = new Reference();
                                                    ttye.reference = url + "MedicationStatement?dk=" + maba;
                                                    tty.entry = ttye;
                                                    cos.Add(tty);
                                                //}
                                            }
                                        }
                                        //Thông tin Dị ứng và khả năng không dung nạp (Allergies & Itolerances)
                                        BackboneElement du = new BackboneElement();
                                        du.title = "Allergies Summary Section";
                                        CodeableConcept duc = new CodeableConcept();
                                        Coding ducc = new Coding();
                                        ducc.system = "http://loinc.org";
                                        ducc.code = "48765-2";
                                        duc.coding = ducc;
                                        du.code = duc;
                                        Reference due = new Reference();
                                        due.reference = url + "AllergyItolerance?dk=" + maba;
                                        du.entry = due;
                                        cos.Add(du);
                                        //Thông tin về các vấn đề (Problems)
                                        BackboneElement vande = new BackboneElement();
                                        vande.title = "Problems Summary Section";
                                        CodeableConcept vandec = new CodeableConcept();
                                        Coding vandecc = new Coding();
                                        vandecc.system = "http://loinc.org";
                                        vandecc.code = "11450-4";
                                        vandec.coding = vandecc;
                                        vande.code = duc;
                                        Reference vandee = new Reference();
                                        vandee.reference = url + "Condition?dk=" + maba;
                                        vande.entry = vandee;
                                        cos.Add(vande);
                                        //Lay thong tin phau thuat
                                        var phauthuat = cls1.TryGetValue("BenhAn_PhauThuat", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var pt = cls1.GetElement("BenhAn_PhauThuat");
                                            BsonArray rowspt = pt.Value.AsBsonArray;
                                            if (rowspt.Count > 0)
                                            {
                                                for (int j = 0; j < rowspt.Count; j++)
                                                {
                                                    var pt0 = rowspt.ElementAt(j).AsBsonDocument;
                                                    BackboneElement tty = new BackboneElement();
                                                    tty.title = "History of Procedures Section";
                                                    CodeableConcept ttyc = new CodeableConcept();
                                                    Coding ttycc = new Coding();
                                                    ttycc.system = "http://loinc.org";
                                                    ttycc.code = "47519-4";
                                                    ttyc.coding = ttycc;
                                                    tty.code = ttyc;
                                                    Reference ttye = new Reference();
                                                    ttye.reference = url + "Procedure?dk=" + maba;
                                                    tty.entry = ttye;
                                                    cos.Add(tty);
                                                }
                                            }
                                        }
                                        //Lay thong tin ket qua xet nghiem
                                        var clskq = cls1.TryGetValue("BenhAn_CLS_KQ", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var kqcls = cls1.GetElement("BenhAn_CLS_KQ");
                                            BsonArray rowskq = kqcls.Value.AsBsonArray;
                                            if (rowskq.Count > 0)
                                            {
                                                for (int j = 0; j < rowskq.Count; j++)
                                                {
                                                    var pt0 = rowskq.ElementAt(j).AsBsonDocument;
                                                    BackboneElement tty = new BackboneElement();
                                                    tty.title = "rowskq";
                                                    CodeableConcept ttyc = new CodeableConcept();
                                                    Coding ttycc = new Coding();
                                                    ttycc.system = "http://loinc.org";
                                                    ttycc.code = "30954-2";
                                                    ttyc.coding = ttycc;
                                                    tty.code = ttyc;
                                                    Reference ttye = new Reference();
                                                    ttye.reference = url + "ObservationResults?dk=" + maba;
                                                    tty.entry = ttye;
                                                    cos.Add(tty);
                                                }
                                            }
                                        }
                                    }
                                }
                                co.Event = coe;
                                co.section = cos;
                                co.author = ra;
                                compos.resource = co;
                                entry.Add(compos);
                                //Patient
                                BackboneElement patient = new BackboneElement();
                                patient.fullUrl = url + "Patient?dk=" + maba;
                                Patient ttyes = new Patient();
                                ttyes.resourceType = "Patient";
                                Identifier ttyesi = new Identifier();
                                ttyesi.value = mabn;
                                ttyes.identifier = ttyesi;
                                ttyes.active = true;
                                HumanName ttyesn = new HumanName();
                                var tenbn = benhan0.TryGetValue("HoTen", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString(): "" ;
                                ttyesn.text = tenbn;
                                ttyesn.use = "usual";
                                ttyes.name = ttyesn;
                                var dt = bn0.TryGetValue("SoDienThoai", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                if (dt.Length > 0)
                                {
                                    ContactPoint ttyest = new ContactPoint();
                                    ttyest.value = dt;
                                    ttyest.use = "home";
                                    ttyes.telecom = ttyest;
                                }
                                var ngaysinh = bn0.TryGetValue("NgaySinh", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "";
                                if (ngaysinh != null && ngaysinh.Length > 0 && DateTime.TryParse(ngaysinh, out d) == true)
                                {
                                    ttyes.birthDate = d.ToString("yyyy-MM-dd");
                                }
                                patient.resource = ttyes;

                                entry.Add(patient);
                                bu.entry = entry;
                                b.Add(bu);
                            }
                        }
                    }
                    return PrintXML(fileName, b, _config);
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error: " + ex.ToString() + "!", status = 500 });
                }
            }
            else
                return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
        }
        [HttpGet]
        [Obsolete]
        public ActionResult ExportJSON(string dk)
        {
            string[] Dk = dk.Trim().Split(',');
            List<int> DK = Dk.Select(int.Parse).ToList();
            var u = SessionHelper.GetObjectFromJson<UserProfileSessionData>(HttpContext.Session, "UserProfileSessionData");
            string constr = u.MongoDBConnectionString;
            var client = new MongoClient(constr);
            IMongoDatabase db = client.GetDatabase(u.MongoDBDataBaseName);
            var HoSoBenhAn = db.GetCollection<BsonDocument>("HoSoBenhAn");
            var HoSoBenhAn_C = db.GetCollection<BsonDocument>("HoSoBenhAn_C");
            //var filter = Builders<BsonDocument>.Filter.Where(x => dk.IndexOf(x.GetElement("Benhan.IDBA").ToString()) >= 0);
            //var filter = Builders<BsonDocument>.Filter.AnyIn("idba", DK);
            //var filter = Builders<BsonDocument>.Filter.In("idba", DK);
            var filter = Builders<BsonDocument>.Filter.AnyIn("idba", DK);
            //var filter = Builders<BsonDocument>.Filter.Eq("idba", 614);
            //var fHSBA = HoSoBenhAn.Find("{ idba: { $regex: " + dk + " } }").ToList();
            var fHSBA = HoSoBenhAn.Find(filter).ToList();
            //var fHSBA = HoSoBenhAn.Find($"{{ idba: {dk} }}").ToList();
            if (fHSBA != null && fHSBA.Count() > 0)
            {
                string fileName = "\\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xml";
                //string url = HttpContext.Request.Host.Value;
                string url = _config.GetValue<string>("HL7Url");
                BsonValue assignedtoValue;
                List<Bundle> b = new List<Bundle>();
                try
                {
                    foreach (var item in fHSBA)
                    {
                        var Benhan = item.TryGetValue("Benhan", out assignedtoValue);
                        if (assignedtoValue != null)
                        {
                            var benhan = item.GetElement("Benhan");
                            var Thongtinbn = item.TryGetValue("ThongTinBN", out assignedtoValue);
                            if (assignedtoValue != null)
                            {
                                var thongtinbn = item.GetElement("ThongTinBN");
                                //var maba = benhan.ElementAt(0).ToString();
                                var maba = item.GetElement("idba").Value.ToString();
                                BsonArray rows = benhan.Value.AsBsonArray;
                                BsonArray rowsbn = thongtinbn.Value.AsBsonArray;
                                //var mabn = item.GetElement("BenhAn[0].MaBN").ToString();
                                var benhan0 = rows.ElementAt(0).AsBsonDocument;
                                var bn0 = rowsbn.ElementAt(0).AsBsonDocument;
                                var mabn = benhan0.TryGetValue("MaBN", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                var ngaysd = benhan0.TryGetValue("NgaySD", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "";
                                var ngaylap = benhan0.TryGetValue("NgayLap", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "";
                                var bsdt = benhan0.TryGetValue("TenBSDIEUTRI", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                if (bsdt == "")
                                    bsdt = benhan0.TryGetValue("TenNguoiLap", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                var ngayky = benhan0.TryGetValue("NgayKy", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "";
                                var TenBV = benhan0.TryGetValue("TenBV", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                DateTime d;
                                Bundle bu = new Bundle();
                                bu.resourceType = "Bundle";
                                Identifier i = new Identifier();
                                i.system = url + "Bundle?dk=" + maba;
                                i.value = maba;
                                bu.identifier = i;
                                bu.type = "document";
                                bu.timestamp = DateTime.Now;
                                //bu.total = 1;
                                List<BackboneElement> entry = new List<BackboneElement>();
                                //Composition
                                BackboneElement compos = new BackboneElement();
                                compos.fullUrl = url + "Composition?dk=" + maba; ;
                                Composition co = new Composition();
                                co.resourceType = "Composition";
                                co.identifier = i;
                                co.status = "final";
                                CodeableConceptIPS c = new CodeableConceptIPS();
                                Coding cc = new Coding();
                                cc.system = "http://loinc.org";
                                cc.code = "60591-5";
                                c.coding = cc;
                                co.type = c;
                                Reference r = new Reference();
                                r.reference = url + "Patient?dk=" + maba;
                                co.subject = r;
                                if (ngaysd != null && ngaysd.Length > 0 && DateTime.TryParse(ngaysd, out d) == true)
                                {
                                    co.date = d;
                                }
                                //co.date = ngaysd.Length > 0 ? DateTime.Parse(ngaysd) : DateTime.Parse(ngaylap);
                                Reference ra = new Reference();
                                ra.reference = bsdt;
                                //co.subject = ra;
                                co.title = "International Patient Summary";
                                BackboneElement at = new BackboneElement();
                                at.mode = "personal";
                                if (ngayky != null && ngayky.Length > 0 && DateTime.TryParse(ngayky, out d) == true)
                                {
                                    at.time = d;
                                }
                                Reference rp = new Reference();
                                rp.reference = bsdt;
                                at.party = rp;
                                co.attester = at;
                                Reference rc = new Reference();
                                //rc.reference = TenBV;
                                rc.reference = url + "Organization?dk=" + TenBV;
                                co.custodian = rc;
                                List<BackboneElement> coe = new List<BackboneElement>();
                                List<BackboneElement> cos = new List<BackboneElement>();
                                //lay thong tin kham benh
                                var fCLS = HoSoBenhAn_C.Find(filter).ToList();
                                if (fCLS != null && fCLS.Count() > 0)
                                {
                                    foreach (var cls1 in fCLS)
                                    {
                                        var Cls2 = cls1.TryGetValue("Benhan_CLS", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var cls2 = cls1.GetElement("Benhan_CLS");
                                            BsonArray rowscls = cls2.Value.AsBsonArray;
                                            if (rowscls.Count > 0)
                                            {
                                                for (int j = 0; j < rowscls.Count; j++)
                                                {
                                                    var cls0 = rowscls.ElementAt(j).AsBsonDocument;
                                                    //var cls = cls1.GetElement("Benhan_CLS");
                                                    var ngaykham = cls0.TryGetValue("NgayYLenh", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "";
                                                    var machungloai = cls0.TryGetValue("MaChungLoai", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                                    if (machungloai == "1")
                                                    {
                                                        //kham benh
                                                        BackboneElement kb = new BackboneElement();
                                                        CodeableConcept kbc = new CodeableConcept();
                                                        Coding kbcc = new Coding();
                                                        kbcc.code = "PCPR";
                                                        kbcc.system = "http://terminology.hl7.org/CodeSystem/v3-ActClass";
                                                        kbc.coding = kbcc;
                                                        Period p = new Period();
                                                        if (ngaykham != null && ngaykham.Length > 0 && DateTime.TryParse(ngaykham, out d))
                                                            p.occurenceDateTime = d;
                                                        kb.period = p;
                                                        kb.code = kbc;
                                                        coe.Add(kb);
                                                    }
                                                    else if (machungloai == "5")
                                                    {
                                                        //thu thuat
                                                        BackboneElement tty = new BackboneElement();
                                                        tty.title = "History of Procedures Section";
                                                        CodeableConcept ttyc = new CodeableConcept();
                                                        Coding ttycc = new Coding();
                                                        ttycc.system = "http://loinc.org";
                                                        ttycc.code = "47519-4";
                                                        ttyc.coding = ttycc;
                                                        tty.code = ttyc;
                                                        Reference ttye = new Reference();
                                                        ttye.reference = url + "Procedure?dk=" + maba + "-5";
                                                        tty.entry = ttye;
                                                        cos.Add(tty);
                                                    }
                                                }
                                            }
                                        }
                                        //lay thong tin thuoc tay y
                                        var Cls3 = cls1.TryGetValue("BenhAn_ThuocTayY", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var cls3 = cls1.GetElement("BenhAn_ThuocTayY");
                                            BsonArray rowsty = cls3.Value.AsBsonArray;
                                            if (rowsty.Count > 0)
                                            {
                                                //for (int j = 0; j < rowsty.Count; j++)
                                                //{
                                                //var ty0 = rowsty.ElementAt(j).AsBsonDocument;
                                                //var ty = cls1.GetElement("Benhan_CLS");
                                                //var tenthuoc = ty0.TryGetValue("TenBYT", out assignedtoValue) ? "" : assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString();
                                                //var mathuoc = ty0.TryGetValue("MaBYT", out assignedtoValue) ? "" : assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString();
                                                BackboneElement tty = new BackboneElement();
                                                tty.title = "Medication Summary Section";
                                                CodeableConcept ttyc = new CodeableConcept();
                                                Coding ttycc = new Coding();
                                                ttycc.system = "http://loinc.org";
                                                ttycc.code = "10160-0";
                                                ttyc.coding = ttycc;
                                                tty.code = ttyc;
                                                Reference ttye = new Reference();
                                                ttye.reference = url + "MedicationStatement?dk=" + maba;
                                                tty.entry = ttye;
                                                cos.Add(tty);
                                                //}
                                            }
                                        }
                                        //Thông tin Dị ứng và khả năng không dung nạp (Allergies & Itolerances)
                                        BackboneElement du = new BackboneElement();
                                        du.title = "Allergies Summary Section";
                                        CodeableConcept duc = new CodeableConcept();
                                        Coding ducc = new Coding();
                                        ducc.system = "http://loinc.org";
                                        ducc.code = "48765-2";
                                        duc.coding = ducc;
                                        du.code = duc;
                                        Reference due = new Reference();
                                        due.reference = url + "AllergyItolerance?dk=" + maba;
                                        du.entry = due;
                                        cos.Add(du);
                                        //Thông tin về các vấn đề (Problems)
                                        BackboneElement vande = new BackboneElement();
                                        vande.title = "Problems Summary Section";
                                        CodeableConcept vandec = new CodeableConcept();
                                        Coding vandecc = new Coding();
                                        vandecc.system = "http://loinc.org";
                                        vandecc.code = "11450-4";
                                        vandec.coding = vandecc;
                                        vande.code = duc;
                                        Reference vandee = new Reference();
                                        vandee.reference = url + "Condition?dk=" + maba;
                                        vande.entry = vandee;
                                        cos.Add(vande);
                                        //Lay thong tin phau thuat
                                        var phauthuat = cls1.TryGetValue("BenhAn_PhauThuat", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var pt = cls1.GetElement("BenhAn_PhauThuat");
                                            BsonArray rowspt = pt.Value.AsBsonArray;
                                            if (rowspt.Count > 0)
                                            {
                                                for (int j = 0; j < rowspt.Count; j++)
                                                {
                                                    var pt0 = rowspt.ElementAt(j).AsBsonDocument;
                                                    BackboneElement tty = new BackboneElement();
                                                    tty.title = "History of Procedures Section";
                                                    CodeableConcept ttyc = new CodeableConcept();
                                                    Coding ttycc = new Coding();
                                                    ttycc.system = "http://loinc.org";
                                                    ttycc.code = "47519-4";
                                                    ttyc.coding = ttycc;
                                                    tty.code = ttyc;
                                                    Reference ttye = new Reference();
                                                    ttye.reference = url + "Procedure?dk=" + maba;
                                                    tty.entry = ttye;
                                                    cos.Add(tty);
                                                }
                                            }
                                        }
                                        //Lay thong tin ket qua xet nghiem
                                        var clskq = cls1.TryGetValue("BenhAn_CLS_KQ", out assignedtoValue);
                                        if (assignedtoValue != null)
                                        {
                                            var kqcls = cls1.GetElement("BenhAn_CLS_KQ");
                                            BsonArray rowskq = kqcls.Value.AsBsonArray;
                                            if (rowskq.Count > 0)
                                            {
                                                for (int j = 0; j < rowskq.Count; j++)
                                                {
                                                    var pt0 = rowskq.ElementAt(j).AsBsonDocument;
                                                    BackboneElement tty = new BackboneElement();
                                                    tty.title = "rowskq";
                                                    CodeableConcept ttyc = new CodeableConcept();
                                                    Coding ttycc = new Coding();
                                                    ttycc.system = "http://loinc.org";
                                                    ttycc.code = "30954-2";
                                                    ttyc.coding = ttycc;
                                                    tty.code = ttyc;
                                                    Reference ttye = new Reference();
                                                    ttye.reference = url + "ObservationResults?dk=" + maba;
                                                    tty.entry = ttye;
                                                    cos.Add(tty);
                                                }
                                            }
                                        }
                                    }
                                }
                                co.Event = coe;
                                co.section = cos;
                                co.author = ra;
                                compos.resource = co;
                                entry.Add(compos);
                                //Patient
                                BackboneElement patient = new BackboneElement();
                                patient.fullUrl = url + "Patient?dk=" + maba;
                                Patient ttyes = new Patient();
                                ttyes.resourceType = "Patient";
                                Identifier ttyesi = new Identifier();
                                ttyesi.value = mabn;
                                ttyes.identifier = ttyesi;
                                ttyes.active = true;
                                HumanName ttyesn = new HumanName();
                                var tenbn = benhan0.TryGetValue("HoTen", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                ttyesn.text = tenbn;
                                ttyesn.use = "usual";
                                ttyes.name = ttyesn;
                                var dt = bn0.TryGetValue("SoDienThoai", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : assignedtoValue.ToString() : "";
                                if (dt.Length > 0)
                                {
                                    ContactPoint ttyest = new ContactPoint();
                                    ttyest.value = dt;
                                    ttyest.use = "home";
                                    ttyes.telecom = ttyest;
                                }
                                var ngaysinh = bn0.TryGetValue("NgaySinh", out assignedtoValue) ? assignedtoValue.IsBsonNull ? "" : (assignedtoValue.AsDateTime).ToString() : "";
                                if (ngaysinh != null && ngaysinh.Length > 0 && DateTime.TryParse(ngaysinh, out d) == true)
                                {
                                    ttyes.birthDate = d.ToString("yyyy-MM-dd");
                                }
                                patient.resource = ttyes;
                                
                                entry.Add(patient);
                                bu.entry = entry;
                                b.Add(bu);
                            }
                        }
                    }
                    return PrintJSON(fileName, b, _config);
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error: " + ex.ToString() + "!", status = 500 });
                }
            }
            else
                return Json(new { success = false, message = "Không có dữ liệu hiển thị!", status = 500 });
        }
        #endregion

    }
}
