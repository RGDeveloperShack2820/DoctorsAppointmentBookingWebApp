using DoctorsAppointmentModelLibrary.MVCModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsAppointmentModelLibrary.MVCModels
{ 
    public class AppointmentMVC
    {
        public int id { get; set; }


        public UserMVC doctor { get; set; }

        public UserMVC patient { get; set; }

        public DateTime time { get; set; }
    }
}