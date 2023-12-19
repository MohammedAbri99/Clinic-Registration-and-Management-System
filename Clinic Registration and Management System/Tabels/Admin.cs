using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Registration_and_Management_System.Tabels
{
    internal class Admin
    {
        public int  AdminID { get; set; }
        public string AdminName { get; set; }
        
        public string AdminPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
