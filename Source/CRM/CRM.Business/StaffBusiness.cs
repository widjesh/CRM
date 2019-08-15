using CRM.Entities;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Business
{
    public interface IStaffBusiness
    {
        Task<IList<Staff>> getStaffsByName(string name);
        Task<Staff> getStaffById(int id);
        Task<IList<Staff>> getAllStaff();
        Task saveStaff(Staff staff);
        Task updateStaff(Staff staff);
        Task DeleteByStaff(Staff staff);
        Task<bool> StaffExists(int id);
        Task<Staff> getStaffByUser(string id);
    }

    public class StaffBusiness : IStaffBusiness
    {
        private IRepository<Staff> staffRepository;

        public StaffBusiness()
        {
            this.staffRepository = new StaffRepository();
        }

        public Task<IList<Staff>> getStaffsByName(string name)
        {
            return staffRepository.GetList(s => s.nameStaff.Contains(name));
        }

        public Task<Staff> getStaffById(int id)
        {
            return staffRepository.Get(s => s.idStaff == id, "Address.Country,Store");
        }

        public Task<IList<Staff>> getAllStaff()
        {
            return staffRepository.GetList(s => true, "Address.Country,Store");
        }

        public async Task saveStaff(Staff staff)
        {
            staff.dtRegistration = DateTime.Now;
            await staffRepository.Save(staff);
        }

        public async Task updateStaff(Staff staff)
        {
            Staff s = await getStaffById(staff.idStaff);
            staff.adEmail = s.adEmail;
            await staffRepository.Update(staff);
        }


        public async Task DeleteByStaff(Staff staff)
        {
            await staffRepository.Delete(staff);
        }

        public async Task<bool> StaffExists(int id)
        {
            Staff staffExists = await staffRepository.Get(s => s.idStaff == id);
            return staffExists != null || staffExists.idStaff > 0;
        }

        public async Task<Staff> getStaffByUser(string id)
        {
            return await staffRepository.Get(s => s.idUser == id);
        }
    }
}
