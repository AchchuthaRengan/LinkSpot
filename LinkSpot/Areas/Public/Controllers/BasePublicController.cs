using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Public.Controllers
{
    [AllowAnonymous]
    public class BasePublicController : Controller
    {
        protected PublicBusiness ObjBs;

        public BasePublicController()
        {
            ObjBs = new PublicBusiness();
        }
    }
}