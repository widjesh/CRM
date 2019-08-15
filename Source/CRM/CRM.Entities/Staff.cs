using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    [Table ("Staff")]
    public class Staff  
    {
        [Key]
        public int idStaff { get; set; }
        [MaxLength (150)]
        [Required]
        [Display(Name = "Name")]
        public string nameStaff { get; set; }
        [Display(Name = "Phone No.")]
        public string nuPhone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Company Email")]
        public string adEmail { get; set; }
        [EmailAddress]
        [Display(Name = "Personal Email")]
        public string adEmailPersonal { get; set; }
        [Required]
        [Display(Name = "Registration Date")]
        public DateTime dtRegistration { get; set; }
        [Required]
        [Display(Name = "Administrator")]
        public bool isAdmin { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
        public string idUser { get; set; }
        [ForeignKey("idUser")]
        public IdentityUser User { get; set; }
        [Required]
        [Display(Name = "Store Name")]
        public int idStore { get; set; }
        [Display(Name = "Staff Address")]
        public int idAddress { get; set; }
        [ForeignKey("idAddress")]
        public Address Address { get; set; }
        [ForeignKey("idStore")]
        public Store Store { get; set; }
    }
}
