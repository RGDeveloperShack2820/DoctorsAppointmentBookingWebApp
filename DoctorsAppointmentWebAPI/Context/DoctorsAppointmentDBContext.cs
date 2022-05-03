using DoctorsAppointmentModelLibrary.EntityModels;
using System.Data.Entity;


namespace DoctorsAppointmentWebAPI.Context
{
    public class DoctorsAppointmentDBContext : DbContext
    {
        public DoctorsAppointmentDBContext() : base("name=DoctorsAppointmentDBContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

      
    }
}
