using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AttributeRouting.Web.Mvc;
using DoctorsAppointmentModelLibrary.ApiModels;
using DoctorsAppointmentModelLibrary.EntityModels;
using DoctorsAppointmentWebAPI.Context;

namespace DoctorsAppointmentWebAPI.Controllers
{
    public class UserApiModalsController : ApiController
    {
        private DoctorsAppointmentDBContext db = new DoctorsAppointmentDBContext();

        // GET: api/UserApiModals
        public int GetUserApiModals(string email, string password)
        {
           
            int id;
            try
            {
                id = db.Users.SingleOrDefault(tbl => (tbl.email == email) && (tbl.password == password)).user_id;
            }
            catch(Exception e)
            {
                return 0;
            }
            
            //List<User> list = db.Users.ToList();
            //List<UserApiModal> apiList =new List<UserApiModal>();

            //foreach(User user in list)
            //{

            //    UserApiModal userApiModal = new UserApiModal()
            //    {
            //        id = user.user_id,
            //        name = user.name,
            //        department = user.department,
            //        email = user.email,
            //        password = user.password
            //    };

               
            //    apiList.Add(userApiModal);
            //}

            return id;
        }

     
        [HttpGet]
        public List<UserApiModal> GetDoctors()
        {

           
            List<User> list = db.Users.Where(tbl => tbl.department != null).ToList();
            List<UserApiModal> apiList = new List<UserApiModal>();

            foreach (User user in list)
            {

                UserApiModal userApiModal = new UserApiModal()
                {
                    id = user.user_id,
                    name = user.name,
                    department = user.department,
                    email = user.email,
                    password = user.password
                };


                apiList.Add(userApiModal);
            }


            return apiList;
        }

        // GET: api/UserApiModals/{id}
        [ResponseType(typeof(UserApiModal))]
        public IHttpActionResult GetUserApiModal(int id) { 
            User user;

          
                 user = db.Users.Find(id);
            

            if (user == null)
            {
                return NotFound();
            }

            UserApiModal userApiModal2 = new UserApiModal()
                {
                    id =user.user_id,
                    name = user.name,
                    department = user.department,
                    email = user.email,
                    password = user.password,
                };


            return Ok(userApiModal2);
        }

        [ResponseType(typeof(UserApiModal))]
       

        // PUT: api/UserApiModals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserApiModal(int id, UserApiModal userApiModal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userApiModal.id)
            {
                return BadRequest();
            }

            User user = new User()
            {
                user_id = id,
                name = userApiModal.name,
                email = userApiModal.email,
                password = userApiModal.password,
                department = userApiModal.department
            };


            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserApiModalExists(id))
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

        // POST: api/UserApiModals
        [ResponseType(typeof(UserApiModal))]
        public IHttpActionResult PostUserApiModal(UserApiModal userApiModal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new User()
            {
                name = userApiModal.name,
                email = userApiModal.email,
                password=userApiModal.password,
                department=userApiModal.department  
            };


            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userApiModal.id }, userApiModal);
        }

        // DELETE: api/UserApiModals/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUserApiModal(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserApiModalExists(int id)
        {
            return db.Users.Count(e => e.user_id == id) > 0;
        }

       
    }
}