using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsAppointmentModelLibrary.EntityModels
{
    [Table("tblAppointments")]
    public class Appointment
    {
        [Key]
        public int appointment_id { get; set; }


        [InverseProperty("doctorApp")]
        public User doctor { get; set; }


        [InverseProperty("patientApp")]
        public User patient { get; set; }

        public DateTime time { get; set; }
    }
}