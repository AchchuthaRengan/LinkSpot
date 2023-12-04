using BO;
using DBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrlBs
    {
        private UrlDb ObjDb;

        public UrlBs()
        {
            ObjDb = new UrlDb();
        }

        public IEnumerable<Link> GetAll()
        {
            return ObjDb.GetAll();
        }

        public Link GetById(int Id)
        {
            return ObjDb.GetById(Id);
        }

        public void Insert(Link url)
        {
            ObjDb.Insert(url);
        }

        public void Delete(int Id)
        {
            ObjDb.Delete(Id);
        }

        public void Update(Link url)
        {
            ObjDb.Update(url);
        }
    }
}
