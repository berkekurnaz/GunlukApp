﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukApp.Entities.Concrete
{
    public class MongoBaseModel
    {
        public ObjectId Id { get; set; } 
    }
}
