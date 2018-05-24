using LogisticEngine.Model.DB;
using LogisticEngine.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository.Interface
{
    public interface IInvoiceRepository
    {
        bool AddEditInvoice(InvoiceAddEditModel invoice);
        List<InvoiceAddEditModel> GetAllInvoices(int userId, DateTime fromDate, int? companyAddressId);
        InvoiceAddEditModel GetInvoice(int invoiceId);
    }
}
