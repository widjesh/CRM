using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class TicketHistory
    {
        [Key]
        public int idTicketHistory { get; set; }
        [Required]
        
        public int idTicket { get; set; }
        [Display(Name ="Assigned To")]
        public int? idStaffAssigned { get; set; }
        [Required]
        [Display(Name = "Status")]
        public int idTicketStatus { get; set; }
        [Required]
        [Display(Name = "Who Assigned")]
        public int idStaffAssigns { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        [Required]
        public DateTime dtChanged { get; set; }
        [ForeignKey("idTicket")]
        public Ticket Ticket { get; set; }
        [ForeignKey("idTicketStatus")]
        public TicketStatus TicketStatus { get; set; }
        [ForeignKey("idStaffAssigns")]
        public Staff StaffAssigns { get; set; }       
        [ForeignKey("idStaffAssigned")]
        public Staff StaffAssigned { get; set; }
        
    }
}
