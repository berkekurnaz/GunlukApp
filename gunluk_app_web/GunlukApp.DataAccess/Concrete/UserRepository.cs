using GunlukApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunlukApp.DataAccess.Concrete
{
    public class UserRepository : BaseMongoRepository<User>
    {

        public UserRepository(string mongoDbConnectionString, string dbName, string collectionName) : base(mongoDbConnectionString,dbName,collectionName)
        {

        }

        public User Login(User user)
        {
            var result = new User();
            result = this.GetAll().Find(x => x.Username == user.Username && x.Password == user.Password);
            return result;
        }

        public User CheckByUsername(User user)
        {
            var result = new User();
            result = this.GetAll().Find(x => x.Username == user.Username);
            return result;
        }

        public User CheckByMail(User user)
        {
            var result = new User();
            result = this.GetAll().Find(x => x.Email == user.Email);
            return result;
        }

    }
}
