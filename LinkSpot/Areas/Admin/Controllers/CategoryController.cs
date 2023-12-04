using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class CategoryController : BaseAdminController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ObjBs.categoryBs.Insert(category);
                    TempData["Message"] = "Category Created Sucessfully :)";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }

            }
            catch (Exception e)
            {
                TempData["Message"] = "Creation Failed :( " + e.Message;
                return RedirectToAction("Index");
            }

        }
    }
}