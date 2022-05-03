using DoctorsAppointmentBookingMVC.Helpers;
using DoctorsAppointmentModelLibrary.ApiModels;
using DoctorsAppointmentModelLibrary.MVCModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DoctorsAppointmentBookingMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        WebApiHelper webApiHelper=new WebApiHelper();
        // GET: User

       

     
        public ActionResult Index(int id)
        {
            UserMVC userMVC=webApiHelper.GetUserMVC(id);
            List<AppointmentMVC> list = webApiHelper.GetAppointmentMVC();
            userMVC.appointments = list;
            return View("Index",userMVC);
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete()
        {


            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public void Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                webApiHelper.DeleteAppointment(id);

            }
            catch
            {
               
            }
        }

        public ActionResult Book(int id)
        {
           
            try
            {
                ViewData["id"]=id;
                // TODO: Add delete logic here       
                return View("BookAppointment"); 
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public int Book(int doctorId,int patientId,DateTime dateTime)
        {

            try
            {
                // TODO: Add delete logic here
                AppointmentApiModal appointmentApiModal = new AppointmentApiModal();

                appointmentApiModal.doctor = doctorId;
                appointmentApiModal.patient=patientId;
                appointmentApiModal.time=dateTime;

                                    
                
                                


                AppointmentApiModal modal=   webApiHelper.PostAppointment(appointmentApiModal);


                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public ActionResult GetDoctors()
        {
            List<UserMVC> doctors = webApiHelper.GetDoctors();
            JsonResult result = new JsonResult();

            result = this.Json(JsonConvert.SerializeObject(doctors), JsonRequestBehavior.AllowGet);

            return result;
        }
    }
}
