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
    public class StaffRepository : RepositoryBase, IRepository<Staff>
    {
        private CRMContext _context;
        public async Task Delete(Staff t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Staffs.Remove(t);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Staff> Get(Expression<Func<Staff, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                {
                    var staffs = _context.Staffs.AsQueryable();
                    foreach (string inc in getProperties(includeProperties))
                        staffs = staffs.Include(inc);
                    return await staffs.FirstOrDefaultAsync(predicate);
                }
                else
                    return await _context.Staffs.Include(s => s.Address).FirstOrDefaultAsync(predicate);
            }
        }

        public async Task<IList<Staff>> GetList(Expression<Func<Staff, bool>> predicate, string includeProperties = null)
        {
            using (_context = CRMContextFactory.getContext())
            {
                if (includeProperties != null)
                {
                    var staffs = _context.Staffs.AsQueryable();
                    foreach (string inc in getProperties(includeProperties))
                        staffs = staffs.Include(inc);

                    return await staffs.Where(predicate).ToListAsync();
                }
                else
                    return await _context.Staffs.Include(s => s.Address).Where(predicate).ToListAsync();
            }
        }

        public async Task<Staff> Save(Staff t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                _context.Staffs.Add(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }

        public async Task<Staff> Update(Staff t)
        {
            using (_context = CRMContextFactory.getContext())
            {
                var Staffs = _context.Staffs.Update(t);
                await _context.SaveChangesAsync();
                return t;
            }
        }
    }
}
