using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Ticket
    {
        [Key]
        public int idTicket { get; set; }
        [Required]
        [Display(Name = "Ticket Description")]
        public string deTicket { get; set; }
        [Required]
        [Display(Name = "Opened")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime dtOpening { get; set; }
        [Display(Name ="Closed")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? dtClosing { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Due Date")]
        public DateTime dtDue { get; set; }
        [Display(Name = "Assigned To")]
        public int? idStaffAssignedTo { get; set; }
        [ForeignKey("idStaffAssignedTo")]
        [Display(Name = "Assigned To")]
        public Staff staffAssignedTo { get; set; }
        [Display(Name = "Status")]
        public int idTicketStatus { get; set; }
        [ForeignKey("idTicketStatus")]
        [Display(Name = "Status")]
        public TicketStatus ticketStatus { get; set; }
        [Display(Name ="Customer")]
        public int idCustomer { get; set; }
        [Display(Name ="Customer")]
        [ForeignKey("idCustomer")]
        public Customer Customer { get; set; }
        public List<TicketHistory> TicketHistory { get; set; }
    }
}
