using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLL
{
    public class UserDb
    {
        private LinkSpotEntities1 Db;

        public UserDb()
        {
            Db = new LinkSpotEntities1();
        }

        public IEnumerable<Person> GetAll()
        {
            return Db.People.ToList();
        }

        public Person GetById(int Id)
        {
            return Db.People.Find(Id);
        }

        public void Insert(Person user)
        {
            Db.People.Add(user);
            Save();
        }

        public void Delete(int Id)
        {
            Person user = Db.People.Find(Id);
            Db.People.Remove(user);
            Save();
        }

        public void Update(Person user)
        {
            Db.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
