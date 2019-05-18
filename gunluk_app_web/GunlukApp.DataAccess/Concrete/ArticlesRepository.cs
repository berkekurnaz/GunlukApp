using GunlukApp.Entities.Concrete;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukApp.DataAccess.Concrete
{
    public class ArticlesRepository : BaseMongoRepository<Articles>
    {

        public ArticlesRepository(string mongoDbConnectionString, string dbName, string collectionName) : base(mongoDbConnectionString, dbName, collectionName)
        {

        }

    }
}
