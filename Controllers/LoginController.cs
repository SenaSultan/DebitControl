using DebitControl;
using DebitControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebitControl.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            Session["Username"] = null;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginControl(Administrator administrator)
        {

            DebitControlEntities ent = new DebitControlEntities();

            string username = administrator.administratorUsername;
            string password = administrator.administratorPassword;

            var model = ent.usp_Login(username, password).ToList();

            var sonuc = 0;
            string userRole = "";

            foreach (var item in model)
            {
                if (item.Value == null)
                {
                    sonuc = 0;
                }
                else
                {
                    sonuc = (int)item.Value;
                }

                if (item.UserRole != null)
                {
                    userRole = item.UserRole;
                }
            }

            if (sonuc == 1)
            {
                Session["Username"] = username;
                Session["UserRole"] = userRole;

                return RedirectToAction("SecurePage", "Home");
            }
            else if (sonuc == 0)
            {
                TempData["id"] = "0";
                return RedirectToAction("Login");
            }

            return View();
        }

    }
}


