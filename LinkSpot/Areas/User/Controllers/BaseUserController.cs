using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.User.Controllers
{
    public class BaseUserController : Controller
    {
        protected UserBusiness ObjBs;

        public BaseUserController()
        {
            ObjBs = new UserBusiness();
        }
    }
}