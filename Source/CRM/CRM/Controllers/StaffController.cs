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
using Microsoft.AspNetCore.Identity;
using CRM.Util;

namespace CRM.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StaffController : Controller
    {
        private readonly CRMContext _context;
        private readonly IStaffBusiness staffBusiness;
        private readonly IAddressBusiness addressBusiness;
        private readonly IStoreBusiness storeBusiness;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ICountryBusiness countryBusiness;

        public StaffController(CRMContext context, IStaffBusiness staffBusiness, IAddressBusiness addressBusiness, IStoreBusiness storeBusiness, UserManager<IdentityUser> userManager, ICountryBusiness countryBusiness)
        {
            this.staffBusiness = staffBusiness;
            this.addressBusiness = addressBusiness;
            this.storeBusiness = storeBusiness;
            this._userManager = userManager;
            this.countryBusiness = countryBusiness;
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            IList<Staff> staffs = await staffBusiness.getAllStaff();
            return View(staffs);
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await staffBusiness.getStaffById(id.Value);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staff/Create
        public async Task<IActionResult> Create()
        {
            await ViewDataAddressesAndStores();
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Staff staff)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = staff.adEmail, Email = staff.adEmail };
                var result = await _userManager.CreateAsync(user, staff.password);
                
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        await ViewDataAddressesAndStores();
                        return View(staff);
                    }
                }
                user = await _userManager.FindByNameAsync(staff.adEmail);
                
                await _userManager.AddToRoleAsync(user, staff.isAdmin ? "Admin" : "Employee" );
                staff.idUser = user.Id;
                await staffBusiness.saveStaff(staff);
                return RedirectToAction(nameof(Index));
            }
            await ViewDataAddressesAndStores();
            return View(staff);
        }

        private async Task ViewDataAddressesAndStores()
        {
            IList<Address> addresses = await addressBusiness.GetAddresses();
            IList<Store> stores = await storeBusiness.getAllStores();
            IList<Country> countries = await countryBusiness.GetCountries();
            ViewData["idAddress"] = SelectListHelper.SelectListAddresses(addresses);
            ViewData["idStore"] = SelectListHelper.SelectListStores(stores);
            ViewData["idCountry"] = SelectListHelper.SelectListCountries(countries);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff staff = await staffBusiness.getStaffById(id.Value);
            if (staff == null)
            {
                return NotFound();
            }
            await ViewDataAddressesAndStores();
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Staff staff)
        {
            if (id != staff.idStaff)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await staffBusiness.updateStaff(staff);
                    var user = await _userManager.FindByNameAsync(staff.adEmail);
                    if (staff.isAdmin)
                    {

                        if(!await _userManager.IsInRoleAsync(user,"Admin"))
                            await _userManager.AddToRoleAsync(user,"Admin");
                    }
                    else
                    {
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                            await _userManager.RemoveFromRoleAsync(user, "Admin");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StaffExists(staff.idStaff))
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
            await ViewDataAddressesAndStores();
            return View(staff);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff staff = await staffBusiness.getStaffById(id.Value);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Staff staff = await staffBusiness.getStaffById(id);
            await staffBusiness.DeleteByStaff(staff);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StaffExists(int id)
        {
            return await staffBusiness.StaffExists(id);
        }
    }
}
