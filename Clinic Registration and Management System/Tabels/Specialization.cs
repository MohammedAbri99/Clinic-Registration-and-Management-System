using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Registration_and_Management_System.Tabels;

namespace Clinic_Registration_and_Management_System.Tabels
{
    internal class Specialization
    {
        public int SpecializationID { get; set; }
        public string SpecializationName { get; set;}
        public string Description { get; set;}

        // Navigation property for the one-to-many relationship with Appointments
        // Each Appointment has one Specialization only but can Specialization have many Appointment.
        public List<Appointment> Appointments { get; set; }


    }
}
