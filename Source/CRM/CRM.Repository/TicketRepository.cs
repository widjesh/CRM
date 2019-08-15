using CRM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository
{
    public class TicketRepository : RepositoryBase, IRepository<Ticket>
    {
        private CRMContext _context;
        public async Task Delete(Ticket t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Tickets.Remove(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Ticket> Get(Expression<Func<Ticket, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                {
                    var tickets = _context.Tickets.AsQueryable();
                    foreach (string inc in getProperties(includeProperties))
                        tickets = tickets.Include(inc);
                    return await tickets.FirstOrDefaultAsync(predicate);
                }
                
                else
                    return await _context.Tickets.FirstOrDefaultAsync(predicate);
            }
        }

        public async Task<IList<Ticket>> GetList(Expression<Func<Ticket, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                {
                    var tickets = _context.Tickets.AsQueryable();
                    foreach (string inc in getProperties(includeProperties))
                        tickets = tickets.Include(inc);
                    return await tickets.Where(predicate).ToListAsync();
                }
                else
                    return await _context.Tickets.Where(predicate).ToListAsync();
            }
        }

        public async Task<Ticket> Save(Ticket t,Staff staff)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Tickets.Add(t);
                var history = new TicketHistory();
                history.idStaffAssigned = t.idStaffAssignedTo;
                history.idTicket = t.idTicket;
                history.idTicketStatus = t.idTicketStatus;
                history.dtChanged = DateTime.Now;
                history.idStaffAssigns = staff.idStaff;

                _context.TicketHistories.Add(history);
                await _context.SaveChangesAsync();
                return t;
            }
        }

        public async Task<Ticket> Save(Ticket t)
        {
            return await Save(t, new Staff());
        }

        public async Task<Ticket> Update(Ticket t, Staff s)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Update(t);
                var history = new TicketHistory();
                history.idStaffAssigned = t.idStaffAssignedTo;
                history.idTicket = t.idTicket;
                history.idTicketStatus = t.idTicketStatus;
                history.dtChanged = DateTime.Now;
                history.idStaffAssigns = s.idStaff;
                _context.TicketHistories.Add(history);
                await _context.SaveChangesAsync();
                return t;
            }
            
        }

        public async Task<Ticket> Update(Ticket t)
        {
            return await Update(t, new Staff());
        }
    }
}
