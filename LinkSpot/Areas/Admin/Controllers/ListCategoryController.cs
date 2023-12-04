using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListCategoryController : BaseAdminController
    {
        //[Authorize(Roles = "A")]
        public ActionResult Index(string SortBy, string SortOrder, string Page)
        {
            ViewBag.SortBy = SortBy;
            ViewBag.SortOrder = SortOrder;
            var users = ObjBs.categoryBs.GetAll();
            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    users = users.OrderBy(x => x.CategoryName).ToList();
                    break;
            }
            ViewBag.TotalPages = Math.Ceiling(ObjBs.categoryBs.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            //If page = 2 Skip(10) and Take (Next Ten)
            users = users.Skip((page - 1) * 10).Take(10);
            return View(users);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                ObjBs.categoryBs.Delete(id);
                TempData["Message"] = "Deleted Sucessfully :(";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Message"] = "Deletion Failed :( " + e.Message;
                return RedirectToAction("Index");
            }

        }
    }
}