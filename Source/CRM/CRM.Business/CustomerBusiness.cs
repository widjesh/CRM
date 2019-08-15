using CRM.Entities;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business
{
    public interface ICustomerBusiness
    {
        Task<IList<Customer>> getCustomersByName(string name);
        Task<IList<Customer>> getCustomersByEmail(string email);
        Task<IList<Customer>> filterCustomer(string filter);
        Task<Customer> getCustomerById(int id);
        Task<IList<Customer>> getAllCustomer();
        Task saveCustomer(Customer customer);
        Task updateCustomer(Customer customer);
        Task DeleteByCustomer(Customer customer);
        Task<bool> CustomerExists(int id);
        Task<Customer> getCustomerByIdWithTickets(int id);

        Task<Customer> getNumberCustomer(Customer customer);
    }


    public class CustomerBusiness : ICustomerBusiness
    {
        private IRepository<Customer> customerRepository;

        public CustomerBusiness()
        {
            this.customerRepository = new CustomerRepository();
        }
        public async Task<bool> CustomerExists(int id)
        {
            Customer customer = await customerRepository.Get(c => c.idCustomer == id);
            return customer != null || customer.idCustomer > 0;
        }

        public async Task DeleteByCustomer(Customer customer)
        {
            await customerRepository.Delete(customer);
        }

        public async Task<IList<Customer>> filterCustomer(string filter)
        {
            if (isNumber(filter))
            {
                return await customerRepository.GetList(c =>
                                                            c.nuCustomer == int.Parse(filter) ||
                                                            c.nuPhone.Contains(filter), "Address.Country");
            }
            return await customerRepository.GetList(c =>
                                                        c.adEmail.Contains(filter) ||
                                                        c.nmCustomer.Contains(filter) ||
                                                        c.nuPhone.Contains(filter), "Address.Country");
        }

        private bool isNumber(string filter)
        {
            try
            {
                int.Parse(filter);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Customer>> getAllCustomer()
        {
            return await customerRepository.GetList(c => true, "Address.Country");
        }

        public async Task<Customer> getCustomerById(int id)
        {
            return await customerRepository.Get(c => c.idCustomer == id, "Address.Country");
        }

        public async Task<Customer> getCustomerByIdWithTickets(int id)
        {
            var cust = await customerRepository.Get(c => c.idCustomer == id, "Address.Country,tickets.ticketStatus,tickets.staffAssignedTo");

            return cust;
        }

        public async Task<IList<Customer>> getCustomersByEmail(string email)
        {
            return await customerRepository.GetList(cust => cust.adEmail.Contains(email), "Address.Country");
        }

        public async Task<IList<Customer>> getCustomersByName(string name)
        {
            return await customerRepository.GetList(c => c.nmCustomer == name, "Address.Country");
        }

        public async Task saveCustomer(Customer customer)
        {
            customer = await getNumberCustomer(customer);

            await customerRepository.Save(customer);
        }
        public static int generateNumber()
        {
            int number = new Random().Next(10000);
            return number;
        }


        public async Task updateCustomer(Customer customer)
        {
            var cust = await getCustomerById(customer.idCustomer);
            customer.nuCustomer = cust.nuCustomer;
            await customerRepository.Update(customer);
        }

        public async Task<Customer> getNumberCustomer(Customer customer)
        {
            int number = generateNumber();
            while (await customerRepository.Get(cus => cus.nuCustomer == number) != null)
            {
                number = generateNumber();
            }
            customer.nuCustomer = number;
            return customer;
        }
    }
}
