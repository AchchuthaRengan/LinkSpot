using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLL
{
    public class CategoryDb
    {
        private LinkSpotEntities1 Db;

        public CategoryDb()
        {
            Db = new LinkSpotEntities1();
        }

        public IEnumerable<Category> GetAll()
        {
            return Db.Categories.ToList();
        }

        public Category GetById(int Id)
        {
            return Db.Categories.Find(Id);
        }

        public void Insert(Category category)
        {
            Db.Categories.Add(category);
            Save();
        }

        public void Delete(int Id)
        {
            Category category = Db.Categories.Find(Id);
            Db.Categories.Remove(category);
            Save();
        }

        public void Update(Category category)
        {
            Db.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            Db.SaveChanges();
        }
    }
}
