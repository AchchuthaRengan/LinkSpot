using BO;
using DBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {

        private UserDb ObjDb;

        public UserBs()
        {
            ObjDb = new UserDb();
        }

        public IEnumerable<Person> GetAll()
        {
            return ObjDb.GetAll();
        }

        public Person GetById(int Id)
        {
            return ObjDb.GetById(Id);
        }

        public void Insert(Person user)
        {
            ObjDb.Insert(user);
        }

        public void Delete(int Id)
        {
            ObjDb.Delete(Id);
        }

        public void Update(Person user)
        {
            ObjDb.Update(user);
        }
    }
}
