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

        #region Departman İşlemleri
        public ActionResult DepartmentList()
        {
            var model = entities.GetAllDepartmentRecords();//veritab bağlantısı
            return View(model);
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {

            string str = department.departmentName;
            string str1 = department.locationName;
            bool str2 = true;

            entities.InsertDepartment(str, str1, str2); //departman ekleme prosedürü çağrıldı 
            entities.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        #endregion

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

        #region Bilgisayar İşlemleri
        public ActionResult ComputerList()
        {
            var model = entities.GetAllComputerRecords();
            return View(model);
        }

        #endregion

        #region Cihaz İşlemleri
        public ActionResult DeviceList()
        {
            var model = entities.GetAllDeviceRecords();
            return View(model);
        }

        #endregion

    }
}