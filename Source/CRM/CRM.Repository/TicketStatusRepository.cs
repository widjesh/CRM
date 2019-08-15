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
    public class TicketStatusRepository : IRepository<TicketStatus>
    {
        private CRMContext _context;
        public async Task Delete(TicketStatus t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.TicketStatuses.Remove(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TicketStatus> Get(Expression<Func<TicketStatus, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                    return await _context.TicketStatuses.Include(includeProperties).FirstOrDefaultAsync(predicate);
                else
                    return await _context.TicketStatuses.FirstOrDefaultAsync(predicate);
            }
        }

        public async Task<IList<TicketStatus>> GetList(Expression<Func<TicketStatus, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                    return await _context.TicketStatuses.Include(includeProperties).Where(predicate).ToListAsync();
                else
                    return await _context.TicketStatuses.Where(predicate).ToListAsync();
            }
        }

        public async Task<TicketStatus> Save(TicketStatus t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.TicketStatuses.Add(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }

        public async Task<TicketStatus> Update(TicketStatus t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                var TicketStatuses = _context.TicketStatuses.Update(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }
    }
}
