using DoctorsAppointmentModelLibrary.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsAppointmentModelLibrary.MVCModels
{
    public class UserMVC
    {
       
        public int id { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        public string password { get; set; }
        [DisplayName("Department")]
        public string department { get; set; }
        public List<AppointmentMVC> appointments { get; set; }
    }
}
