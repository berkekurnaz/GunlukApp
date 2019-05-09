using GunlukApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GunlukApp.DataAccess.Concrete
{
    public class UserRepository : BaseMongoRepository<User>
    {

        public UserRepository(string mongoDbConnectionString, string dbName, string collectionName) : base(mongoDbConnectionString,dbName,collectionName)
        {

        }

    }
}
