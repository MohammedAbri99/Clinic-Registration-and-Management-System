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

        //the different way to specify primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Appoin_id { get; set; }

        [ForeignKey("Patient")]
        public int? Pati_Id { get; set; }

        public Patient? Patient { get; set; }

        [ForeignKey("Specialization")]
        public int? Speci_Id { get; set; }

        public Specialization? Specialization{get; set; }
        //public List<Patient> pati_ID { set; get; }
        public List<Specialization> Spec_ID { set; get; }

        public DateOnly Date { set; get; }
        public TimeOnly Time { set; get; }

        public string status { set; get; }
    }
}
