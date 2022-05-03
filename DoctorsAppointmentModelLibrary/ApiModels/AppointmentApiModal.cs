using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DoctorsAppointmentModelLibrary.ApiModels
{
    public class AppointmentApiModal
    {
        public int id { get; set; }
        [DisplayName("Doctor Name")]
        public int doctor { get; set; }
        [DisplayName("Patient Name")]
        public int patient { get; set; }
        [DisplayName("Appointment Time")]
        public DateTime time { get; set; }

    }
}