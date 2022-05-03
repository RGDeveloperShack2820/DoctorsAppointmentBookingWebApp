using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DoctorsAppointmentModelLibrary.ApiModels
{
    public class UserApiModal
    {

        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string department { get; set; }

    }
}