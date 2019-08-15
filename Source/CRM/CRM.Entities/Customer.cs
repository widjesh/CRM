using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Customer 
    {
        [Key]
        public int idCustomer { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Name")]
        public string nmCustomer { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Phone No.")]
        [DataType(DataType.PhoneNumber)]
        public string nuPhone { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        [Display(Name = "Email Address")]
        public string adEmail { get; set; }
        [Required]
        [Display(Name = "Client Id")]
        public int nuCustomer { get; set; }
        [Required]
        [Display(Name = "Address")]
        public int idAddress { get; set; }
        [ForeignKey("idAddress")]
        public Address Address { get; set; }
        public List<Ticket> tickets { get; set; }

        public Customer()
        {
            this.tickets = new List<Ticket>();
        }
    }
}
