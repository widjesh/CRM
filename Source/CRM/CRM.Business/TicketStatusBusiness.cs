using CRM.Entities;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business
{
    public interface ITicketStatusBusiness
    {
        Task<IList<TicketStatus>> getAlTicketStatuses();
    }
    public class TicketStatusBusiness : ITicketStatusBusiness
    {
        private IRepository<TicketStatus> ticketStatusRepository;

        public TicketStatusBusiness()
        {
            this.ticketStatusRepository = new TicketStatusRepository();
        }

        public async Task<IList<TicketStatus>> getAlTicketStatuses()
        {
             return await ticketStatusRepository.GetList(s=>true);
        }
    }
}
