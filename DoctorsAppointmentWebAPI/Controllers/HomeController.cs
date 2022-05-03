using DoctorsAppointmentModelLibrary.ApiModels;
using DoctorsAppointmentModelLibrary.EntityModels;
using DoctorsAppointmentWebAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorsAppointmentWebAPI.Controllers
{
    public class HomeController : Controller
    {
        DoctorsAppointmentDBContext doctorsAppointmentDBContext =new DoctorsAppointmentDBContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";



            return View();
        }

        public ActionResult GetUser()
        {
            ViewBag.Title = "Home Page";
            User user=new User();
            user = doctorsAppointmentDBContext.Users.FirstOrDefault(u=>(u.email=="rohitgupta@gmail.com")&&(u.password== "rohit1234"));
                
            

            return View(user);
        }
    }
}
