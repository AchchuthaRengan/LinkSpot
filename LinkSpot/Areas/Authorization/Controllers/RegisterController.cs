using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkSpot.Areas.Authorization.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseAuthorizationController
    {
        // GET: Authorization/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person user)
        {                        
            try
            {
                byte[] EncDataByte = System.Text.Encoding.UTF8.GetBytes(user.Password);
                string encryptedPassword = Convert.ToBase64String(EncDataByte);
                if (ModelState.IsValid)
                {
                    user.Role = "U";
                    user.Password = encryptedPassword;
                    user.ConfirmPassword = encryptedPassword;
                    ObjBs.userBs.Insert(user);
                    TempData["Message"] = "Registered Successfully!! ";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "Registration Failed :(";
                return RedirectToAction("Index");
            }
        }
    }
}