using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Address
    {
        [Key]
        public int idAddress { get; set; }
        [Required]
        [MaxLength(100)]
        public string street { get; set; }
        [MaxLength(100)]
        public string disctrict { get; set; }
        [Required]
        [MaxLength(10)]
        public string nuAddress { get; set; }       
        [Required]
        public int idCountry { get; set; }
        [MaxLength(100)]
        public string cityAddress { get; set; }
        [MaxLength(15)]
        public string zipAddress { get; set; }
        [ForeignKey("idCountry")]
        public Country Country { get; set; }
    }
}
