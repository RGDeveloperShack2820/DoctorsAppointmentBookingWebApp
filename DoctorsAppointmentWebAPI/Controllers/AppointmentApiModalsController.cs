using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DoctorsAppointmentModelLibrary.ApiModels;
using DoctorsAppointmentModelLibrary.EntityModels;
using DoctorsAppointmentWebAPI.Context;

namespace DoctorsAppointmentWebAPI.Controllers
{
    public class AppointmentApiModalsController : ApiController
    {
        private DoctorsAppointmentDBContext db = new DoctorsAppointmentDBContext();

        // GET: api/AppointmentApiModals
        public List<AppointmentApiModal> GetAppointmentApiModals()
        {
            
              List<Appointment>  list = db.Appointments.Include("doctor").Include("patient").ToList();

            List<AppointmentApiModal> apiList = new List<AppointmentApiModal>();

            foreach (Appointment app in list)
            {
                AppointmentApiModal appointmentApiModal = new AppointmentApiModal()
                {
                    id = app.appointment_id,
                    doctor = app.doctor.user_id,
                    patient = app.patient.user_id,
                    time = app.time,
                };

                apiList.Add(appointmentApiModal);
            }


            return apiList;
        }

        // GET: api/AppointmentApiModals/5
        [ResponseType(typeof(AppointmentApiModal))]
        public IHttpActionResult GetAppointmentApiModal(int id)
        {
            Appointment appointment = db.Appointments.Include("doctor").Include("patient").FirstOrDefault(ap=>ap.appointment_id==id);
           
            if (appointment == null)
            {
                return NotFound();
            }

            AppointmentApiModal apiModal = new AppointmentApiModal()
            {
                id = appointment.appointment_id,
                doctor = appointment.doctor.user_id,
                patient = appointment.patient.user_id,
                time = appointment.time,
            };

            return Ok(apiModal);
        }

        //PUT: api/AppointmentApiModals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointmentApiModal(int id, AppointmentApiModal appointmentApiModal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointmentApiModal.id)
            {
                return BadRequest();
            }

            Appointment appointment = new Appointment()
            {
                appointment_id = id,
                time = appointmentApiModal.time,
                doctor = db.Users.FirstOrDefault(u => u.user_id == appointmentApiModal.doctor),
                patient = db.Users.FirstOrDefault(u => u.user_id == appointmentApiModal.patient)
            };

            db.Entry(appointment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentApiModalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AppointmentApiModals
        [ResponseType(typeof(Appointment))]
        public Appointment PostAppointmentApiModal(AppointmentApiModal appointmentApiModal)
        {
           
            Appointment appointment = new Appointment()
            {
                time = appointmentApiModal.time.ToLocalTime(),
                doctor= db.Users.FirstOrDefault(u => u.user_id == appointmentApiModal.doctor),
                patient = db.Users.FirstOrDefault(u => u.user_id == appointmentApiModal.patient)
            };


            db.Appointments.Add(appointment);
            db.SaveChanges();

            return appointment;
        }

        //DELETE: api/AppointmentApiModals/5
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult DeleteAppointmentApiModal(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(appointment);
            db.SaveChanges();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentApiModalExists(int id)
        {
            return db.Appointments.Count(e => e.appointment_id == id) > 0;
        }
    }
}