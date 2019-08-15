using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Store
    {
        [Key]
        public int idStore { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string nmStore { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int idCountry { get; set; }       
        [Required]
        [Display(Name = "Address")]
        public int idAddress { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        [ForeignKey("idAddress")]
        public Address Address { get; set; }
        [ForeignKey("idCountry")]
        public Country Country { get; set; }

    }
}
