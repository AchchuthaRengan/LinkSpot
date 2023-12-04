using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Public.Controllers
{
    [AllowAnonymous]
    public class BrowseController : BasePublicController
    {
        public ActionResult Index(int CategoryId = 1000)
        {
            ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            var urls = ObjBs.urlBs.GetAll().Where(x => x.Approved == "A" && x.CategoryId == CategoryId);
            return View(urls);
        }
    }
}