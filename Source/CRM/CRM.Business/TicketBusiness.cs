using CRM.Entities;
using CRM.Repository;
using CRM.Util.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business
{
    public interface ITicketBusiness
    {
        Task<IList<Ticket>> GetTickets();
        Task<Ticket> getTicketById(int id);
        Task saveTicket(Ticket ticket, Staff staff);
        Task updateTicket(Ticket ticket, Staff staff);
        Task DeleteByTicket(Ticket ticket);
        Task<bool> TicketExists(int id);
        Task<Ticket> GetTicketByIdWithHistory(int id);
        Task<IList<Ticket>> GetCurrentTickets();
        Task<IList<int>> GetStatisticsForToday();
        Task<IList<int>> GetStatisticForThisYear();
    }
    public class TicketBusiness : ITicketBusiness
    {

        private TicketRepository ticketRepository;
        private IRepository<TicketHistory> historyRepository;
        private ICustomerBusiness customerBusiness;

        public TicketBusiness()
        {
            this.ticketRepository = new TicketRepository();
            this.historyRepository = new TicketHistoryRepository();
            this.customerBusiness = new CustomerBusiness();
        }
        public async Task DeleteByTicket(Ticket ticket)
        {
            await ticketRepository.Delete(ticket);
        }

        public async Task<IList<Ticket>> GetTickets()
        {
            return await ticketRepository.GetList(t => true, "staffAssignedTo,Customer,ticketStatus");
        }

        public async Task<Ticket> getTicketById(int id)
        {
            return await ticketRepository.Get(t => t.idTicket == id, "staffAssignedTo,Customer,ticketStatus");
        }

        public async Task<Ticket> GetTicketByIdWithHistory(int id)
        {
            var ticket = await ticketRepository.Get(t => t.idTicket == id, "staffAssignedTo,Customer,ticketStatus");
            ticket.TicketHistory = (await historyRepository.GetList(hi => hi.idTicket == ticket.idTicket, "TicketStatus,StaffAssigns,StaffAssigned")).ToList();
            return ticket;
        }

        public async Task saveTicket(Ticket ticket, Staff staff)
        {
            ticket.dtOpening = DateTime.Now;
            ticket.dtClosing = null;
            ticket.dtDue = DateTime.Now.AddDays(3);
            ticket.idTicketStatus = (int)TicketStatusEnum.OPEN;
            if(ticket.idCustomer == 0)
            {
                ticket.Customer = await customerBusiness.getNumberCustomer(ticket.Customer);
            }
            ticket = await ticketRepository.Save(ticket,staff);
            
        }

        public async Task<bool> TicketExists(int id)
        {
            Ticket ticket = await ticketRepository.Get(t => t.idTicket == id);
            return ticket != null || ticket.idTicket > 0;
        }

        public async Task updateTicket(Ticket ticket,Staff staff)
        {
            Ticket t = await getTicketById(ticket.idTicket);
            ticket.dtOpening = t.dtOpening;
            ticket.dtDue = t.dtDue;
            ticket.dtClosing = t.dtClosing;
            if (ticket.idStaffAssignedTo == 0)
                ticket.idStaffAssignedTo = null;
            await ticketRepository.Update(ticket,staff);
        }

        public async Task<IList<Ticket>> GetCurrentTickets()
        {
            IList<Ticket> tickets = await ticketRepository.GetList(t => t.idTicketStatus == (int)TicketStatusEnum.OPEN, "staffAssignedTo,Customer,ticketStatus");
            tickets = tickets.OrderBy(t=>t.dtDue).Take(10).ToList();
            return tickets;
        }

        public async Task<IList<int>> GetStatisticsForToday()
        {
            //IList<Ticket> tickets = await ticketRepository.GetList(t => t.dtDue.ToShortDateString() == DateTime.Now.ToShortDateString(), "staffAssignedTo,Customer,ticketStatus");
            IList<Ticket> tickets = await ticketRepository.GetList(t => true, "staffAssignedTo,Customer,ticketStatus");
            IList<int> statistics = new List<int>();
            statistics.Add(tickets.Where(t => t.idTicketStatus == (int)TicketStatusEnum.OPEN).Count());
            statistics.Add(tickets.Where(t=>t.idTicketStatus == (int)TicketStatusEnum.COMPLETED).Count());
            statistics.Add(tickets.Where(t => t.idTicketStatus == (int)TicketStatusEnum.CLOSED).Count());
            return statistics;

        }

        public async Task<IList<int>> GetStatisticForThisYear()
        {
            IList<int> statisticsYear = new List<int>();
            IList<Ticket> tickets = await ticketRepository.GetList(t => t.dtDue.Year == DateTime.Now.Year);
            statisticsYear.Add(tickets.Where(t => t.idTicketStatus == (int)TicketStatusEnum.OPEN).Count());
            statisticsYear.Add(tickets.Where(t => t.idTicketStatus == (int)TicketStatusEnum.COMPLETED).Count());
            statisticsYear.Add(tickets.Where(t => t.idTicketStatus == (int)TicketStatusEnum.CLOSED).Count());
            return statisticsYear;
        }
    }
}
