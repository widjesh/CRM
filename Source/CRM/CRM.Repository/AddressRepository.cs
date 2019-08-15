using CRM.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace CRM.Repository
{
    public class AddressRepository : IRepository<Address>
    {
        private CRMContext _context;
        public async Task Delete(Address t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Addresses.Remove(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Address> Get(Expression<Func<Address, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                    return await _context.Addresses.Include(includeProperties).FirstOrDefaultAsync(predicate);
                else
                    return await _context.Addresses.FirstOrDefaultAsync(predicate);
            }
        }

        public async Task<IList<Address>> GetList(Expression<Func<Address, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                    return await _context.Addresses.Include(includeProperties).Where(predicate).ToListAsync();
                else

                    return await _context.Addresses.Where(predicate).ToListAsync();
            }
        }

        public async Task<Address> Save(Address t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Addresses.Add(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }

        public async Task<Address> Update(Address t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                var address = _context.Addresses.Update(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }
    }
}
