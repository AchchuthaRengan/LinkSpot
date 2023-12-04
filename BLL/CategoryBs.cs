using BO;
using DBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBs
    {
        private CategoryDb ObjDb;

        public CategoryBs()
        {
            ObjDb = new CategoryDb();
        }

        public IEnumerable<Category> GetAll()
        {
            return ObjDb.GetAll();
        }

        public Category GetById(int Id)
        {
            return ObjDb.GetById(Id);
        }

        public void Insert(Category category)
        {
            ObjDb.Insert(category);
        }

        public void Delete(int Id)
        {
            ObjDb.Delete(Id);
        }

        public void Update(Category category)
        {
            ObjDb.Update(category);
        }        
    }
}
