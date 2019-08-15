using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM.Entities
{
    public class TicketStatus
    {
        [Key]
        public int idTicketStatus { get; set; }
        [Required]
        [MaxLength (10,ErrorMessage ="The max char. has exceed")]
        public string deTicketStatus { get; set; }
    }
}
