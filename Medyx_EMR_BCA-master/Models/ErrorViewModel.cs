using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Medyx_EMR_BCA.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class TraceLogMongo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string TenBang { get; set; }
        [BsonElement]
        public string MaBN { get; set; }
        [BsonElement]
        public string KieuTacDong { get; set; }
        [BsonElement]
        public DateTime NgaySD { get; set; }
        [BsonElement]
        public string NguoiSD { get; set; }
        [BsonElement]
        public string NoiDungSD { get; set; }
        [BsonElement]
        public string MaMay { get; set; }
        public string MaVungLT { get; internal set; }
    }
    public class TraceLogSQL
    {
        public Decimal Id { get; set; }
        public string TenBang { get; set; }
        public string MaBN { get; set; }
        public string KieuTacDong { get; set; }
        public DateTime NgaySD { get; set; }
        public string NguoiSD { get; set; }
        public string NoiDungSD { get; set; }
        public string MaMay { get; set; }
    }
    public class TraceLogSQLVM
    {
        public Decimal Id { get; set; }
        public string TenBang { get; set; }
        public string MaBN { get; set; }
        public string KieuTacDong { get; set; }
        public DateTime NgaySD { get; set; }
        public string NguoiSD { get; set; }
        public string NoiDungSD { get; set; }
        public string MaMay { get; set; }
        public Int32 TotalRows { get; set; }
    }
    public class TraceLogTableName
    {
        public string TenBang { get; set; }
        public string MaBang { get; set; }
    }
    public class TraceLogKieuTacDong
    {
        public string TenKieu { get; set; }
        public string MaKieu { get; set; }
    }
}