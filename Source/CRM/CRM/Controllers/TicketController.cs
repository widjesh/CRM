using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM.Entities;
using CRM.Helper;
using CRM.Business;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CRM.Util.Enum;

namespace CRM.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly CRMContext _context;
        private readonly ITicketBusiness ticketBusiness;
        private readonly IStaffBusiness staffBusiness;
        private readonly ITicketStatusBusiness ticketStatusBusiness;
        private readonly ICustomerBusiness customerBusiness;
        private readonly ICountryBusiness countryBusiness;

        public TicketController(CRMContext context, IStaffBusiness staffBusiness,
            ITicketBusiness ticketBusiness, ITicketStatusBusiness ticketStatusBusiness, ICustomerBusiness customerBusiness,
            ICountryBusiness countryBusiness)
        {
            this.ticketStatusBusiness = ticketStatusBusiness;
            this.ticketBusiness = ticketBusiness;
            this.staffBusiness = staffBusiness;
            this.staffBusiness = staffBusiness;
            this.customerBusiness = customerBusiness;
            this.countryBusiness = countryBusiness;
            _context = context;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            IList<Ticket> tickets = await ticketBusiness.GetTickets();
            return View(tickets);
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Ticket ticket = await ticketBusiness.GetTicketByIdWithHistory(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        public async Task<IActionResult> Create(int? id)
        {
            await DisplayStaffAndTicketStatus();
            if (id != null)
            {
                Ticket ticket = new Ticket();
                ticket.idCustomer = id.Value;
                return View(ticket);
            }

            return View(new Ticket());
        }

        private async Task DisplayStaffAndTicketStatus()
        {
            IList<Staff> staffs = await staffBusiness.getAllStaff();
            IList<TicketStatus> ticketStatuses = await ticketStatusBusiness.getAlTicketStatuses();
            ViewData["idStaffAssignedTo"] = SelectListHelper.SelectListStaffs(staffs);
            ViewData["idCustomers"] = SelectListHelper.SelectListCutomers(await customerBusiness.getAllCustomer());
            ViewData["idTicketStatus"] = SelectListHelper.SelectListTicketStatuses(ticketStatuses);
            ViewData["idCountry"] = SelectListHelper.SelectListCountries(await countryBusiness.GetCountries());
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                Staff staff = await getCurrentStaff();
                await ticketBusiness.saveTicket(ticket, staff);
                ViewData["error"] = new Error() { description = "Ticket created" };
                IList<Ticket> tickets = await ticketBusiness.GetTickets();
                return View(nameof(Index), tickets);
            }
            await DisplayStaffAndTicketStatus();
            return View(ticket);
        }

        private async Task<Staff> getCurrentStaff()
        {
            return await staffBusiness.getStaffByUser(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await ticketBusiness.getTicketById(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }
            if (ticket.idTicketStatus == (int)TicketStatusEnum.COMPLETED)
            {
                ViewData["error"] = new Error { description = "Ticket already completed" };
                return View(nameof(Details), ticket);
            }
            await DisplayStaffAndTicketStatus();
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {
            if (id != ticket.idTicket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var staff = await getCurrentStaff();
                    await ticketBusiness.updateTicket(ticket, staff);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TicketExists(ticket.idTicket))
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
            await DisplayStaffAndTicketStatus();
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await ticketBusiness.getTicketById(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await ticketBusiness.getTicketById(id);
            await ticketBusiness.DeleteByTicket(ticket);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TicketExists(int id)
        {
            return await ticketBusiness.TicketExists(id);
        }
    }
}
