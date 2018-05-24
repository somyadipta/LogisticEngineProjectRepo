using LogisticEngine.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository.Services
{
    public class InvoiceService
    {
        private readonly InvoiceRepository invoiceRepo;
        public void AddInvoice(Invoice invoice)
        {
            invoiceRepo.Add(invoice);
        }
    }
}
