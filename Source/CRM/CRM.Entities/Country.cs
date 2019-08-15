using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM.Entities
{
    public class Country
    {
        [Key]
        public int idCountry { get; set; }
        [Required]
        [MaxLength (length:70,ErrorMessage ="The max char. has exceeded")]
        public string nmCountry { get; set; }
        [Required]
        [MaxLength(length:3,ErrorMessage ="The max char. has exceeded")]
        public string abbrevationCountry { get; set; }
    }
}
