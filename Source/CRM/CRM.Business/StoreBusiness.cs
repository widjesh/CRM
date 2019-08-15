using CRM.Entities;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business
{
    public interface IStoreBusiness
    {
        Task<IList<Store>> getAllStores();
        Task<Store> getStoreById(int id);
        Task saveStore(Store store);
        Task updateStore(Store store);
        Task DeleteByStore(Store store);
        Task<bool> StoreExists(int id);
    }
    public class StoreBusiness : IStoreBusiness
    {
        IRepository<Store> storeRepository;

        public StoreBusiness()
        {
            this.storeRepository = new StoreRepository();
        }

        public async Task DeleteByStore(Store store)
        {
            await storeRepository.Delete(store);
        }

        public async Task<IList<Store>> getAllStores()
        {
            return await storeRepository.GetList(s => true, "Address.Country,Country");
        }

        public async Task<Store> getStoreById(int id)
        {
            return await storeRepository.Get(s=>s.idStore == id, "Address.Country,Country");
        }

        public async Task saveStore(Store store)
        {
            await storeRepository.Save(store);
        }

        public async Task<bool> StoreExists(int id)
        {
            Store store = await storeRepository.Get(s => s.idStore == id);
            return store != null || store.idStore > 0;
        }

        public async Task updateStore(Store store)
        {
           await storeRepository.Update(store);
        }
    }
}
