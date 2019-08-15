using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Entities
{
    public class CRMContextFactory
    {
        public static CRMContext getContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CRMContext>();
            optionsBuilder.UseMySql("Server=crm-presentation.mysql.database.azure.com;Database=crm;User=crmsys@crm-presentation;Password=Test1234$;");
            return new CRMContext(optionsBuilder.Options);                 
        }
    }
}
