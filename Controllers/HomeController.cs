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
        public ActionResult DeleteComputer(short? id)
        {
            int sonuc = entities.DeleteComputer(id);

            return RedirectToAction("ComputerList");
        }
        public ActionResult CreateComputer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateComputer(Computer computer)
        {

            string str = computer.computerBrand;
            string str1 = computer.computerModel;
            string str2 = computer.computerName;
            string str3 = computer.computerSerialNumber;
            string str4 = computer.computerLanMac;
            string str5 = computer.computerWifiMac;
            string str6 = computer.computerWin;
            string str7 = computer.computerOffice;

            short id3 = (short)computer.computerNumber;

            short id = (short)computer.licenceId;
            bool id2 = (bool)computer.computerUsbStatus;

            entities.CreateComputer(str, str1, str2, str3, str4, str5, str6, str7, id3, id2, id);
            entities.SaveChanges();
            return RedirectToAction("ComputerList");
        }
        public ActionResult EditComputer(short id)
        {
            var model = entities.GetComputerByID(id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditComputer(Computer computer)
        {

            short id4 = (short)computer.computerId;
            string str = computer.computerBrand;
            string str1 = computer.computerModel;
            string str2 = computer.computerName;
            string str3 = computer.computerSerialNumber;
            string str4 = computer.computerLanMac;
            string str5 = computer.computerWifiMac;
            string str6 = computer.computerWin;
            string str7 = computer.computerOffice;

            short id3 = (short)computer.computerNumber;

            short id = (short)computer.licenceId;
            bool id2 = (bool)computer.computerUsbStatus;


            entities.UpdateComputer(id4, str, str1, str2, str3, str4, str5, str6, str7, id3, id2, id);
            entities.SaveChanges();


            return RedirectToAction("ComputerList");
        }





        #endregion

        #region Cihaz İşlemleri
        public ActionResult DeviceList()
        {
            var model = entities.GetAllDeviceRecords();
            return View(model);
        }
        public ActionResult DeleteDevice(short? id)
        {
            int sonuc = entities.DeleteDevice(id);

            return RedirectToAction("DeviceList");
        }
        public ActionResult CreateDevice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDevice(Device device)
        {
            string str = device.deviceType;
            string str1 = device.deviceBrand;
            string str2 = device.deviceModel;
            string str3 = device.deviceSerialNumber;


            short id2 = (short)device.deviceNumber;
            bool id3 = true;

            entities.CreateDevice(str, str1, str2, str3, id2, id3);
            entities.SaveChanges();
            return RedirectToAction("DeviceList");
        }
        public ActionResult EditDevice(short id)
        {
            var model = entities.GetDeviceByID(id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditDevice(Device device)
        {

            short id = (short)device.deviceId;
            string str = device.deviceType;
            string str1 = device.deviceBrand;
            string str2 = device.deviceModel;
            string str3 = device.deviceSerialNumber;


            short id2 = (short)device.deviceNumber;
            bool id3 = true;

            entities.UpdateDevice(id, str, str1, str2, str3, id2, id3);
            entities.SaveChanges();
            return RedirectToAction("DeviceList");

        }

        #region Lisans İşlemleri

        public ActionResult LicenceList()
        {
            var model = entities.GetAllLicenceRecords();
            return View(model);
        }
        public ActionResult DeleteLicence(short? id)
        {
            int sonuc = entities.DeleteLicense(id);

            return RedirectToAction("LicenceList");

        }
        public ActionResult CreateLicence()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateLicence(License licence)
        {

            string str = licence.licenceName;
            string str1 = licence.licenceKey;
            string str2 = licence.licenceMail;
            string str3 = licence.licencePassword;

            entities.InsertLicense(str, str1, str2, str3);
            entities.SaveChanges();
            return RedirectToAction("LicenceList");
        }
        public ActionResult EditLicence(short id)
        {
            var model = entities.GetLicenseById(id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditLicence(License licence)
        {

            short id = licence.licenceId;
            string str = licence.licenceName;
            string str1 = licence.licenceKey;
            string str2 = licence.licenceMail;
            string str3 = licence.licencePassword;


            entities.UpdateLicense(id, str, str1, str2, str3);
            entities.SaveChanges();

            return RedirectToAction("LicenceList");
        }

        #endregion
        #region Süreli Lisans İşlemleri
        
        public ActionResult TerminatedLicenceList()
        {
            var model = entities.GetTerminatedLicences();
            return View(model);
        }
        public ActionResult TerminatedDeleteLicence(short? id)
        {
            int sonuc = entities.DeleteTerminatedLicence(id);

            return RedirectToAction("TerminatedLicenceList");
        }
        public ActionResult TerminatedCreateLicence()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TerminatedCreateLicence(terminatedLicence terminatedLicence)
        {

            string str = terminatedLicence.licenseName;
            string str1 = terminatedLicence.obtainedFrom;
            DateTime str2 = (DateTime)terminatedLicence.obtainedDate;
            string str3 = terminatedLicence.email;
            string str4 = terminatedLicence.licencepassword;
            string str5 = terminatedLicence.licenceCode;
            string str6 = terminatedLicence.issuedPerson;
            string str7 = terminatedLicence.issuedDepartment;
            short str8 = (short)terminatedLicence.licenceDuration;

            entities.InsertTerminatedLicence(str, str1, str2, str3, str4, str5, str6, str7, str8);
            entities.SaveChanges();
            return RedirectToAction("TerminatedLicenceList");
        }
        public ActionResult TerminatedEditLicence(short id)
        {
            var model = entities.GetTerminatedLicenceById(id).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult TerminatedEditLicence(terminatedLicence terminatedLicence)
        {
            int id = terminatedLicence.licenseId;
            string str = terminatedLicence.licenseName;
            string str1 = terminatedLicence.obtainedFrom;
            DateTime str2 = (DateTime)terminatedLicence.obtainedDate;
            string str3 = terminatedLicence.email;
            string str4 = terminatedLicence.licencepassword;
            string str5 = terminatedLicence.licenceCode;
            string str6 = terminatedLicence.issuedPerson;
            string str7 = terminatedLicence.issuedDepartment;
            short str8 = (short)terminatedLicence.licenceDuration;

            entities.UpdateTerminatedLicence(id, str, str1, str2, str3, str4, str5, str6, str7, str8);


            entities.SaveChanges();

            return RedirectToAction("TerminatedLicenceList");
        }


        #endregion


        #region Bilgisayar Lisans İşlemleri

        public ActionResult ActiveDebitLicenceList()
        {
            var model = entities.GetComputerWithLicence();
            return View(model);
        }

        public ActionResult CreateDebitLicence()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDebitLicence(Computer computer)
        {

            short id = (short)computer.licenceId;
            short id2 = (short)computer.computerId;

            entities.UpdateLicenceForComputer(id2, id);
            entities.SaveChanges();
            return RedirectToAction("ActiveDebitLicenceList");
        }


        #endregion

        #region Bilgisayar Zimmet İşlemleri
        public ActionResult DebitComputerList()
        {
            var model = entities.GetDebitComputer();
            return View(model);
        }

        public ActionResult ActiveDebitComputerList()
        {
            var model = entities.GetActiveDebitComputer();
            return View(model);
        }
        #endregion
        public ActionResult CreateDebitComputer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDebitComputer(DebitComputer debitComputer)
        {

            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            DateTime? finishDate = null;

            bool bo = true;

            short id = (short)debitComputer.employeeId;
            short id2 = (short)debitComputer.computerId;

            entities.CreateDebitComputer(id, id2, startDate, finishDate, bo);
            entities.SaveChanges();
            return RedirectToAction("ActiveDebitComputerList");
        }
        public ActionResult DeleteDebitComputer(short? id)
        {
            int sonuc = entities.DisableDebitComputer(id);

            return RedirectToAction("ActiveDebitComputerList");
        }


        #region Cihaz Zimmet İşlemleri
       
        public ActionResult DebitDeviceList()
        {
            var model = entities.GetDebitDevice();
            return View(model);
        }
        
        public ActionResult ActiveDebitDeviceList()
        {
            var model = entities.GetActiveDebitDevice();
            return View(model);
        }

    
        public ActionResult CreateDebitDevice()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateDebitDevice(DebitDevice debitDevice)
        {

            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            DateTime? finishDate = null;

            bool bo = true;

            short id = (short)debitDevice.employeeId;
            short id2 = (short)debitDevice.deviceId;

            entities.CreateDebitDevice(id, id2, startDate, finishDate, bo);
            entities.SaveChanges();
            return RedirectToAction("ActiveDebitDeviceList");
        }
        
        public ActionResult DeleteDebitDevice(short? id)
        {
            int sonuc = entities.DisableDebitDevice(id);

            return RedirectToAction("ActiveDebitDeviceList");
        }

        #endregion

        #endregion

    }
}