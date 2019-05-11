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
    public class SuperUserRepository : BaseMongoRepository<SuperUser>
    {

        public SuperUserRepository(string mongoDbConnectionString, string dbName, string collectionName) : base(mongoDbConnectionString, dbName, collectionName)
        {

        }

        public SuperUser Login(SuperUser superUser)
        {
            var result = new SuperUser();
            result = this.GetAll().Find(x => x.Username == superUser.Username && x.Password == superUser.Password);
            return result;
        }

    }
}
