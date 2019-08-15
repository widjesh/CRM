using CRM.Entities;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business
{
    public interface ICountryBusiness
    {
        Task<IList<Country>> GetCountries();
        Task<Country> getCountryById(int id);
        Task saveCountry(Country country);
        Task updateCountry(Country country);
        Task DeleteByCountry(Country country);
        Task<bool> CountryExists(int id);

    }
    public class CountryBusiness : ICountryBusiness
    {
        private IRepository<Country> countryRepository;

        public CountryBusiness()
        {
            this.countryRepository = new CountryRepository();
        }

        public async Task<bool> CountryExists(int id)
        {
            Country country =await countryRepository.Get(c => c.idCountry == id);
            return country != null || country.idCountry > 0;
        }

        public async Task DeleteByCountry(Country country)
        {
            await countryRepository.Delete(country);
            
        }

        public async Task<IList<Country>> GetCountries()
        {
            return await countryRepository.GetList(c=>true);
        }

        public async Task<Country> getCountryById(int id)
        {
            return await countryRepository.Get(c => c.idCountry == id);
        }

        public async Task saveCountry(Country country)
        {
            await countryRepository.Save(country);
        }

        public async Task updateCountry(Country country)
        {
            await countryRepository.Update(country);
        }
    }
}
