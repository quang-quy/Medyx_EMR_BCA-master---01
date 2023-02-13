using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Medyx.ApiAssets.LogApi
{
	public class TraceLogApiMongo
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
	}
}