using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class StaffModel
    {

        public int idStaff { get; set; }

        public string nameStaff { get; set; }
        public string nuPhone { get; set; }
        [Display(Name ="Email address")]
        public string adEmail { get; set; }
        public string adEmailPersonal { get; set; }

        public DateTime dtRegistration { get; set; }
        public int idStore { get; set; }
        public int idAddress { get; set; }

    }
}
