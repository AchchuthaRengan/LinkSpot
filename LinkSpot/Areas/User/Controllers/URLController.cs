using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.User.Controllers
{
    [Authorize(Roles = "A,U")]
    public class URLController : BaseUserController
    {
        // GET: User/URL
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(ObjBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Link myUrl)
        {
            try
            {
                myUrl.Approved = "P";
                myUrl.UserId = ObjBs.userBs.GetAll().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                if (ModelState.IsValid)
                {
                    ObjBs.urlBs.Insert(myUrl);
                    TempData["Error"] = "Link Added Successfully!! 🎉🎉";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "UserId", "UserEmail");
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = "Link Addition Failed :( " + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}