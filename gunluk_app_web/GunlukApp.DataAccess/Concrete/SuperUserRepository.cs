using GunlukApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukApp.DataAccess.Concrete
{
    public class SuperUserRepository : BaseMongoRepository<SuperUser>
    {

        public SuperUserRepository(string mongoDbConnectionString, string dbName, string collectionName) : base(mongoDbConnectionString, dbName, collectionName)
        {

        }

    }
}
