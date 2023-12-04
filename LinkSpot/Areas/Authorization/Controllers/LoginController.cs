using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkSpot.Areas.Authorization.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseAuthorizationController
    {        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Person user)
        {
            LinkSpotEntities1 db = new LinkSpotEntities1();

            Person user1;

            bool isValid = false;

            user1 = db.People.Where(x => x.UserEmail == user.UserEmail).FirstOrDefault();
           
            try
            {
                byte[] decrpassword = Convert.FromBase64String(user1.Password);
                string decryptedValue = System.Text.Encoding.UTF8.GetString(decrpassword);


                if (db.People.Any(i => i.UserEmail.Equals(user.UserEmail) && (decryptedValue.Equals(user.Password))))
                {
                    isValid = true;
                }
                if (isValid == true)
                {
                    if (db.People.Any(i => i.UserEmail.Equals(user.UserEmail) && (decryptedValue.Equals(user.Password))))
                    {
                        FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                        return RedirectToAction("Index", "Home", new { area = "Public" });
                    }
                    else
                    {
                        TempData["Message"] = "Invalid Credentials :(";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["Message"] = "Invalid Credentials :(";
                    return RedirectToAction("Index");
                }
                             
            }
            catch (Exception)
            {
                TempData["Message"] = "Invalid Credentials :(";
                return RedirectToAction("Index");
            }
        }
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Public" });
        }
    }
}
