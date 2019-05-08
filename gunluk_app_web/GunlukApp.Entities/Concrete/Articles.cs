using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukApp.Entities.Concrete
{
    public class Articles : MongoBaseModel
    {

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("CreatedDate")]
        public string CreatedDate { get; set; }

        [BsonElement("CreatedDay")]
        public int CreatedDay { get; set; }

        [BsonElement("CreatedMonth")]
        public int CreatedMonth { get; set; }

        [BsonElement("CreatedYear")]
        public int CreatedYear { get; set; }

        [BsonElement("DiaryId")]
        public ObjectId DiaryId { get; set; }

    }
}
