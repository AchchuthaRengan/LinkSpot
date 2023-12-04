using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLL
{
    public class UrlDb
    {
        private LinkSpotEntities1 Db;

        public UrlDb()
        {
            Db = new LinkSpotEntities1();
        }

        public IEnumerable<Link> GetAll()
        {
            return Db.Links.ToList();
        }

        public Link GetById(int Id)
        {
            return Db.Links.Find(Id);
        }

        public void Insert(Link url)
        {
            Db.Links.Add(url);
            Save();
        }

        public void Delete(int Id)
        {
            Link url = Db.Links.Find(Id);
            Db.Links.Remove(url);
            Save();
        }

        public void Update(Link url)
        {
            Db.Entry(url).State = EntityState.Modified;
            Db.Entry(url).State = EntityState.Modified;
            Db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            Db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
