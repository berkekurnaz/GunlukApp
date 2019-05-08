using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukApp.Entities.Concrete
{
    public class SuperUser : MongoBaseModel
    {

        [BsonElement("NameSurname")]
        public string NameSurname { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Photo")]
        public string Photo { get; set; }

        [BsonElement("CreatedDate")]
        public string CreatedDate { get; set; }

    }
}
