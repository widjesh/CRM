using CRM.Entities;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business
{
    public interface IAddressBusiness
    {
        Task<IList<Address>> GetAddresses();
        Task<Address> getAddressById(int id);
        Task saveAddress(Address Address);
        Task updateAddress(Address Address);
        Task DeleteByAddress(Address Address);
        Task<bool> AddressExists(int id);
    }
    public class AddressBusiness : IAddressBusiness
    {
        private IRepository<Address> addressRepository;

        public AddressBusiness()
        {
            this.addressRepository = new AddressRepository();
        }

        public async Task<bool> AddressExists(int id)
        {
            Address address = await addressRepository.Get(a=>a.idAddress == id);
            return address != null || address.idAddress > 0;
        }

        public async Task DeleteByAddress(Address Address)
        {
            await addressRepository.Delete(Address);
        }

        public async Task<Address> getAddressById(int id)
        {
            return await addressRepository.Get(a=>a.idAddress == id);
        }

        public async Task<IList<Address>> GetAddresses()
        {
            return await addressRepository.GetList(a=>true);
        }

        public async Task saveAddress(Address Address)
        {
            await addressRepository.Save(Address);
        }

        public async Task updateAddress(Address Address)
        {
            await addressRepository.Update(Address);
        }
    }
}
