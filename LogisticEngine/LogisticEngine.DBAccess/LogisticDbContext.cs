using LogisticEngine.Model.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.DBAccess
{
   public class LogisticDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ClientBranch> CompanyAddresses { get; set; }

    }
}
