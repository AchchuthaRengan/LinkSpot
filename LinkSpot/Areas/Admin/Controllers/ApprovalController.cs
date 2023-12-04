using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApprovalController : BaseAdminController
    {        
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var urls = ObjBs.urlBs.GetAll().Where(x => x.Approved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = ObjBs.urlBs.GetAll().Where(x => x.Approved == Status).ToList();
                return View(urls);
            }
        }

        public ActionResult Approve(int Id)
        {
            try
            {
                var myUrl = ObjBs.urlBs.GetById(Id);
                myUrl.Approved = "A";
                ObjBs.urlBs.Update(myUrl);
                TempData["Message"] = "Url Approved!";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["Message"] = "Url Approval Failed :( "+e.Message;
                return RedirectToAction("Index");
            }            
        }

        public ActionResult Reject(int Id)
        {
            try
            {
                var myUrl = ObjBs.urlBs.GetById(Id);
                myUrl.Approved = "R";
                ObjBs.urlBs.Update(myUrl);
                TempData["Message"] = "Url Rejected!";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["Message"] = "Url Rejection Failed :( "+e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ApproveOrRejectAll(List<int> Ids, string Status,string CurrentStatus)
        {
            try
            {
                ObjBs.ApproveOrReject(Ids, Status);
                TempData["Message"] = "Operation Successfull!";
                var urls = ObjBs.urlBs.GetAll().Where(x => x.Approved == CurrentStatus).ToList();
                return PartialView("PV_ApproveURL", urls);
            }
            catch (Exception e)
            {
                TempData["Message"] = "Operation Failed" + e.Message;
                var urls = ObjBs.urlBs.GetAll().Where(x => x.Approved == CurrentStatus).ToList();
                return PartialView("PV_ApproveURL", urls);
            }
        }
    }
}