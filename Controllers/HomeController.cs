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

        public ActionResult DeleteDepartment(short? id)
        {
            int sonuc = entities.DeleteDepartment(id);

            return RedirectToAction("DepartmentList");

        }
        public ActionResult EditDepartment(short id)
        {
            var model = entities.GetDepartmentById(id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditDepartment(Department department)
        {

            short id = department.departmentId;
            string str = department.departmentName;
            string str1 = department.locationName;
            bool bo = true;

            entities.UpdateDepartment(id, str, str1, bo);
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
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {

            string str = employee.employeeName;
            string str1 = employee.employeeSurname;
            string str2 = employee.employeeUsername;
            byte id = (byte)employee.departmentId;
            short id2 = (short)employee.mailId;

            entities.InsertEmployee(str, str1, str2, id, id2);
            entities.SaveChanges();
            return RedirectToAction("ActiveEmployeeList");
        }
        public ActionResult EditEmployee(short id)
        {
            var model = entities.GetEmployeeById(id).ToList();
            return View(model);
        }

        
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {

            short id = employee.employeeId;
            string str = employee.employeeName;
            string str1 = employee.employeeSurname;
            string str2 = employee.employeeUsername;
            bool bo = true;
            byte id2 = (byte)employee.departmentId;
            short id3 = (short)employee.mailId;

            entities.UpdateEmployeeById(id, str, str1, str2, bo, id2, id3);
            entities.SaveChanges();


            return RedirectToAction("ActiveEmployeeList");
        }

        public ActionResult DeleteEmployee(short? id)
        {
            int sonuc = entities.DisableEmployee(id);

            return RedirectToAction("ActiveEmployeeList");

        }
       
                #endregion

        



        #region Mail İşlemleri
        public ActionResult MailList()
        {
            var model = entities.GetAllMails();
            return View(model);
        }
        public ActionResult DeleteMail(short? id)
        {
            int sonuc = entities.DisableMail(id);

            return RedirectToAction("MailList");

        }

        public ActionResult CreateMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMail(Mail mail)
        {

            //formdan gelen veriyi string değişkene atıyorum
            string str = mail.mailName;
            string str1 = mail.mailPassword;
            bool str2 = true;

            entities.InsertMail(str, str1, str2);
            entities.SaveChanges();
            return RedirectToAction("MailList");
        }

        public ActionResult EditMail(short id)
        {
            var model = entities.GetMailById(id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditMail(Mail mail)
        {

            short id = mail.mailId;
            string str = mail.mailName;
            string str1 = mail.mailPassword;
            bool bo = true;

            entities.UpdateMail(id, str, str1, bo);
            entities.SaveChanges();

            return RedirectToAction("MailList");
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