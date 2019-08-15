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
    public class TicketHistoryRepository : RepositoryBase ,IRepository<TicketHistory>
    {
        private CRMContext _context;
        public async Task Delete(TicketHistory t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.TicketHistories.Remove(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TicketHistory> Get(Expression<Func<TicketHistory, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                {
                    var histories = _context.TicketHistories.AsQueryable();
                    foreach (string inc in getProperties(includeProperties))
                        histories = histories.Include(inc);
                    return await histories.FirstOrDefaultAsync(predicate);
                }
                else
                    return await _context.TicketHistories.FirstOrDefaultAsync(predicate);
            }
        }

        public async Task<IList<TicketHistory>> GetList(Expression<Func<TicketHistory, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                {
                    var histories = _context.TicketHistories.AsQueryable();
                    foreach (string inc in getProperties(includeProperties))
                        histories = histories.Include(inc);
                    return await histories.Where(predicate).ToListAsync();
                }
                
                else
                    return await _context.TicketHistories.Where(predicate).ToListAsync();
            }
        }

        public async Task<TicketHistory> Save(TicketHistory t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.TicketHistories.Add(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }

        public async Task<TicketHistory> Update(TicketHistory t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                var TicketHistoryes = _context.TicketHistories.Update(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }
    }
}
