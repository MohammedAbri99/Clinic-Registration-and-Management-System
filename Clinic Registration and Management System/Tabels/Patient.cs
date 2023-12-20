using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Registration_and_Management_System.Tabels
{
    internal class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set;}
        public int ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        // Navigation property for the one-to-many relationship with Appointments
        // Each patient can have many appointment but the appointment is only for one patient.
        public List<Appointment> Appointments { get; set; }

    }
}
