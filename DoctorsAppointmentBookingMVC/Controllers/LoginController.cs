using DoctorsAppointmentBookingMVC.Helpers;
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
   
    public class LoginController : Controller
    {
        WebApiHelper webApiHelper = new WebApiHelper();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int Index(string email,string password)
        {

            int id = webApiHelper.GetUserIdMVC( email, password);

            if (id != 0)
            FormsAuthentication.SetAuthCookie(email, false);

            return id;
     
        }

        
        public ActionResult Authenticate()
        {

            return RedirectToAction("Authenticate");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(UserMVC userMVC)
        {
            JsonResult result;

            try
            {
                // TODO: Add insert logic here
                int id=webApiHelper.GetUserIdMVC(userMVC.email, userMVC.password);

                if (id == 0)
                {
                    webApiHelper.PostRequest(userMVC);
                    result = Json(JsonConvert.SerializeObject("Success"), JsonRequestBehavior.AllowGet);          
                }
                else
                {
                    result = Json(JsonConvert.SerializeObject("User Already Registered Kindly Login"), JsonRequestBehavior.AllowGet);
                }
                
            }
            catch
            {
                result = Json(JsonConvert.SerializeObject("Error"), JsonRequestBehavior.AllowGet);
            }

            return result;
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
