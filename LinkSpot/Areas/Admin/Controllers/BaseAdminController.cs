using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected AdminBusiness ObjBs;
        public BaseAdminController()
        {
            ObjBs = new AdminBusiness();
        }
    }
}