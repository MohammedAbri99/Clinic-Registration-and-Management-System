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

        //the relation between Specializaiton and appointment is one to many
        public ICollection<Appointment> Spacialization { get; set; } = new List<Appointment>();

        
    }
}
