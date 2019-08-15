using CRM.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Helper
{
    public class SelectListHelper
    {
        public static SelectList SelectListAddresses(IList<Address> addresses)
        {
            return new SelectList(addresses, "idAddress", "street");
        }
        public static SelectList SelectListStores(IList<Store> stores)
        {
            return new SelectList(stores, "idStore", "nmStore");
        }
        public static SelectList SelectListCountries(IList<Country> countries)
        {
            return new SelectList(countries, "idCountry", "abbrevationCountry");
        }

        public static SelectList SelectListTicketStatuses(IList<TicketStatus> ticketStatuses)
        {
            return new SelectList(ticketStatuses, "idTicketStatus", "deTicketStatus");
        }
        public static SelectList SelectListStaffs(IList<Staff> staffs)
        {

            return new SelectList(staffs, "idStaff", "nameStaff", 0);
        }
        public static SelectList SelectListStaffs(IList<Staff> staffs, int idStaff)
        {

            return new SelectList(staffs, "idStaff", "nameStaff",idStaff);
        }

        internal static object SelectListCutomers(IList<Customer> list)
        {
            return new SelectList(list,"idCustomer","nmCustomer");
        }
    }
}
