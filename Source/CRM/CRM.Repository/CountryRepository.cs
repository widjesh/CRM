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
    public class CountryRepository : IRepository<Country>
    {
        private CRMContext _context;
        public async Task Delete(Country t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Countries.Remove(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Country> Get(Expression<Func<Country, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                    return await _context.Countries.Include(includeProperties).FirstOrDefaultAsync(predicate);
                else
                    return await _context.Countries.FirstOrDefaultAsync(predicate);
            }
        }

        public async Task<IList<Country>> GetList(Expression<Func<Country, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                    return await _context.Countries.Include(includeProperties).Where(predicate).ToListAsync();
                else
                    return await _context.Countries.Where(predicate).ToListAsync();
            }
        }

        public async Task<Country> Save(Country t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Countries.Add(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }

        public async Task<Country> Update(Country t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                var countries = _context.Countries.Update(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }
    }
}
