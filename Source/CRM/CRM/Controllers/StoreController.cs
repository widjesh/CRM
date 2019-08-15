using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Entities;
using CRM.Business;
using CRM.Helper;
using Microsoft.AspNetCore.Authorization;

namespace CRM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoreController : Controller
    {
        private readonly CRMContext _context;
        private readonly IStoreBusiness storeBusiness;
        private readonly IAddressBusiness addressBusiness;
        private readonly ICountryBusiness countryBusiness;

        public StoreController(CRMContext context, ICountryBusiness countryBusiness, IAddressBusiness addressBusiness, IStoreBusiness storeBusiness)
        {
            this.countryBusiness = countryBusiness;
            this.addressBusiness = addressBusiness;
            this.storeBusiness = storeBusiness;
            _context = context;
        }

        // GET: Store
        public async Task<IActionResult> Index()
        {
            IList<Store> stores = await storeBusiness.getAllStores();
            return View(stores);
        }

        // GET: Store/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var store = await storeBusiness.getStoreById(id.Value);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Store/Create
        public async Task<IActionResult> Create()
        {
            await ViewDataAddressesAndCountries();
            var store = new Store();
            store.Address = new Address();
            return View(store);
        }

        private async Task ViewDataAddressesAndCountries()
        {
            ViewData["idAddress"] = SelectListHelper.SelectListAddresses(await addressBusiness.GetAddresses());
            ViewData["idCountry"] = SelectListHelper.SelectListCountries(await countryBusiness.GetCountries());
        }



        // POST: Store/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Store store)
        {
            if (ModelState.IsValid)
            {
                await storeBusiness.saveStore(store);
                return RedirectToAction(nameof(Index));
            }
            await ViewDataAddressesAndCountries();
            return View(store);
        }

        // GET: Store/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var store = await storeBusiness.getStoreById(id.Value);
            if (store == null)
            {
                return NotFound();
            }
            await ViewDataAddressesAndCountries();
            return View(store);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Store store)
        {
            if (id != store.idStore)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await storeBusiness.updateStore(store);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StoreExists(store.idStore))
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
            await ViewDataAddressesAndCountries();
            return View(store);
        }

        // GET: Store/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await storeBusiness.getStoreById(id.Value);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var store = await storeBusiness.getStoreById(id);
            await storeBusiness.DeleteByStore(store);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StoreExists(int id)
        {
            return await storeBusiness.StoreExists(id);
        }
    }
}
