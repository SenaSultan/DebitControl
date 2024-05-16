using DebitControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebitControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        DebitControlEntities entities = new DebitControlEntities();

        #region Personel İşlemleri
        public ActionResult EmployeeList()
        {
            var model = entities.GetEmployeeData();
            return View(model);
        }
        #endregion

        #region Mail İşlemleri
        public ActionResult MailList()
        {
            var model = entities.GetAllMails();
            return View(model);
        }
        #endregion

    }
}