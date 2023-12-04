using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Authorization.Controllers
{
    public class BaseAuthorizationController : Controller
    {
        protected AuthorizationBusiness ObjBs;
        public BaseAuthorizationController()
        {
            ObjBs = new AuthorizationBusiness();
        }
    }
}