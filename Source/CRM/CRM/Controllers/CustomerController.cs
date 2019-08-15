using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Entities;
using Microsoft.AspNetCore.Authorization;
using CRM.Business;
using CRM.Helper;
using CRM.Models;

namespace CRM.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly CRMContext _context;
        private readonly ICustomerBusiness customerBusiness;
        private readonly IAddressBusiness addressBusiness;
        private readonly ICountryBusiness countryBusiness;


        public CustomerController(CRMContext context, ICustomerBusiness customerBusiness, IAddressBusiness addressBusiness, ICountryBusiness countryBusiness)
        {
            this.customerBusiness = customerBusiness;
            this.addressBusiness = addressBusiness;
            this.countryBusiness = countryBusiness;
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var customers = await customerBusiness.getAllCustomer();
            return View(customers);
        }

        public async Task<IActionResult> Search(string queryString)
        {
            IList<Customer> customers = new List<Customer>();
            if (queryString == null)
                customers = await customerBusiness.getAllCustomer();
            else
                customers = await customerBusiness.filterCustomer(queryString);
            return View(customers);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await customerBusiness.getCustomerByIdWithTickets(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public async Task<IActionResult> Create()
        {
            ViewData["idAddress"] = SelectListHelper.SelectListAddresses(await addressBusiness.GetAddresses());
            ViewData["idCountry"] = SelectListHelper.SelectListCountries(await countryBusiness.GetCountries());
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                await customerBusiness.saveCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            ViewData["idAddress"] = SelectListHelper.SelectListAddresses(await addressBusiness.GetAddresses());
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await customerBusiness.getCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["idAddress"] = SelectListHelper.SelectListAddresses(await addressBusiness.GetAddresses());
            ViewData["idCountry"] = SelectListHelper.SelectListCountries(await countryBusiness.GetCountries());//Correction 1
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.idCustomer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await customerBusiness.updateCustomer(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CustomerExists(customer.idCustomer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idAddress"] = SelectListHelper.SelectListAddresses(await addressBusiness.GetAddresses());
            return View(customer);
        }

        // GET: Customer/Delete/5S
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await customerBusiness.getCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await customerBusiness.getCustomerById(id);
            await customerBusiness.DeleteByCustomer(customer);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CustomerExists(int id)
        {
            return await customerBusiness.CustomerExists(id);
        }
    }
}
