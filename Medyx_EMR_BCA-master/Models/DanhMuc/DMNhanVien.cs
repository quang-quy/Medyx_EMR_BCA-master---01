using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyx_EMR_BCA.Models
{
    public class DMNhanVien
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public int EmployeeID { get; set; }

        [BsonElement]
        public string FirstName { get; set; }

        [BsonElement]
        public string LastName { get; set; }
    }
}
