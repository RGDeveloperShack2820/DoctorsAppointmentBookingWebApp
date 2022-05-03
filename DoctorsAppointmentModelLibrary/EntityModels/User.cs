using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsAppointmentModelLibrary.EntityModels
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string  password { get; set; }    
        public string department { get; set; }
        [InverseProperty("patient")]
        public List<Appointment> patientApp { get; set; }
        [InverseProperty("doctor")]
        public List<Appointment> doctorApp { get; set; }
    }
}
