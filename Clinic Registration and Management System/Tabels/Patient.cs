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
        public int PationtID { get; set; }
        public string PatientName { get; set;}
        public int ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        public ICollection<Appointment> Patients { get; set; } = new List<Appointment>();

    }
}
