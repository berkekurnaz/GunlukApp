using GunlukApp.Entities.Abstract;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukApp.Entities.Concrete
{
    public class MongoBaseModel : IEntity
    {
        public ObjectId Id { get; set; } 
    }
}
