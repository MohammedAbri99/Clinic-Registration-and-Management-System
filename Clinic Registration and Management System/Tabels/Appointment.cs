using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic_Registration_and_Management_System.Tabels;

namespace Clinic_Registration_and_Management_System.Tabels
{
    internal class Appointment
    {

        //The different way to specify primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Appoin_id { get; set; }

        public DateTime Date { set; get; }
        public TimeSpan Time { set; get; }

        public string status { set; get; }

        // Foreign keys
        public int PatientId { get; set; }
        public int SpecializationId { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public Specialization Specialization { get; set; }
    }
}
