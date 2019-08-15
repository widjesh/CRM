using CRM.Business;
using CRM.Entities;
using CRM.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ITicketBusiness ticketBusiness;

        public HomeController(ITicketBusiness ticketBusiness)
        {
            this.ticketBusiness = ticketBusiness;
        }

        [Route("/")]
        public async Task<ActionResult> Index()
        {
            ViewData["error"] = new Error() { description = "Welcome " + User.Identity.Name };
            if (User.IsInRole("Admin"))
            {
                IList<int> statistics = await ticketBusiness.GetStatisticsForToday();
                ViewData["statisticsTickets"] = statistics;
                IList<int> statisticsYear = await ticketBusiness.GetStatisticForThisYear();
                ViewData["statisticsYear"] = statisticsYear;
            }
            IList<Ticket> tickets = await ticketBusiness.GetCurrentTickets();
            ViewData["CurrentTickets"] = tickets;
            return View();
        }
    }
}
