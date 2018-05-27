using LogisticEngine.DBAccess;
using LogisticEngine.Model.DB;
using LogisticEngine.Model.UI;
using LogisticEngine.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository
{
    /// <summary>
    /// Write only search/query operation here
    /// </summary>
    public class InvoiceRepository: RepositoryBase, IInvoiceRepository
    {
        public bool AddEditInvoice(InvoiceAddEditModel newInvoice)
        {
            var invoice = new Invoice
            {
                FromTime = newInvoice.FromTime,
                InvoiceId = newInvoice.InvoiceId,
                CGSTAmount = newInvoice.CGSTAmount,
                CGSTRate = newInvoice.CGSTRate,
                GST = newInvoice.GST,
                InvoiceDate = newInvoice.InvoiceDate,
                PoNO = newInvoice.PoNO,
                SACNo = newInvoice.SACNo,
                SGSTAmount = newInvoice.SGSTAmount,
                SGSTRate = newInvoice.SGSTRate,
                ToTime = newInvoice.ToTime,
                TotalWithoutTax = newInvoice.TotalWithoutTax,
                TotalWithTax = newInvoice.TotalWithTax,
                InvoiceItems = newInvoice.InvoiceItems.Select(p => new InvoiceItem
                {
                    InvoiceItemId = p.InvoiceItemId,
                    ItemName = p.ItemName,
                    ItemQuantity = p.ItemQuantity,
                    SerialNo = p.SerialNo,
                    TotalPrice = p.TotalPrice,
                    PerItemPrice = 0,
                    InvoiceId = newInvoice.InvoiceId

                }).ToList(),
                InvoiceTo = new ClientBranch
                {
                    BranchName = newInvoice.InvoiceTo.BranchName,
                    Address1 = newInvoice.InvoiceTo.Address1,
                    Address2 = newInvoice.InvoiceTo.Address2,
                    Address3 = newInvoice.InvoiceTo.Address3,
                    ClientBranchId = newInvoice.InvoiceTo.ClientBranchId
                },
                InvoiceNumber = "Google" + DateTime.Now.Ticks.ToString(),
                CompanyAddressId= newInvoice.InvoiceTo.ClientBranchId,
                LogisticUserId=newInvoice.UserId

            };
            try
            {
                if (invoice.CompanyAddressId > 0)
                {
                    this.Update<ClientBranch>(invoice.InvoiceTo);
                }

                if (invoice.InvoiceId > 0)
                {
                    invoice.InvoiceItems.ForEach((item) =>
                    {
                        if (item.InvoiceItemId > 0)
                        {
                            this.Update<InvoiceItem>(item);
                        }
                        else
                        {
                            this.Add<InvoiceItem>(item);
                        }
                    });
                    this.Update<Invoice>(invoice);

                }
                else
                {
                    this.Add<Invoice>(invoice);
                }
            }
            catch (Exception x)
            {
                return false;
            }
            return true;
        }

        public List<InvoiceAddEditModel> GetAllInvoices(int userId,DateTime fromDate,int? companyAddressId)
        {
            List<Invoice> invoices = new List<Invoice>();
            List<InvoiceAddEditModel> prsentableInvoices = new List<InvoiceAddEditModel>();
            if (companyAddressId == null)
                invoices= this.Get<Invoice>(p => p.LogisticUserId == userId && p.FromTime.Month == fromDate.Month).ToList();
            else
                invoices= this.Get<Invoice>(p => p.LogisticUserId == userId && p.FromTime.Month == fromDate.Month && p.CompanyAddressId==(int)companyAddressId).ToList();


            invoices.ForEach((p) =>
            {
                prsentableInvoices.Add(new InvoiceAddEditModel
                {
                    PoNO = p.PoNO,
                    InvoiceTo = new ClientBranchAddEditModel
                    {
                        Address1 = p.InvoiceTo.Address1,
                        Address2 = p.InvoiceTo.Address2,
                        Address3 = p.InvoiceTo.Address3,
                        BranchName = p.InvoiceTo.BranchName,
                        ClientBranchId = p.InvoiceTo.ClientBranchId
                    },
                    CGSTRate = p.CGSTRate,
                    CGSTAmount = p.CGSTAmount,
                    FromTime = p.FromTime,
                    ToTime = p.ToTime,
                    InvoiceId = p.InvoiceId,
                    CompanyAddressId = p.CompanyAddressId,
                    InvoiceDate = p.InvoiceDate,
                    SACNo = p.SACNo,
                    SGSTAmount = p.SGSTAmount,
                    SGSTRate = p.SGSTRate,
                    InvoiceNumber = p.InvoiceNumber,
                    TotalWithoutTax = p.TotalWithoutTax,
                    TotalWithTax = p.TotalWithTax,
                    UserId = p.LogisticUserId,
                    InvoiceItems = p.InvoiceItems.Select(t => new InvoiceItemAddEditModel
                    {
                        InvoiceItemId=t.InvoiceItemId,
                        ItemQuantity=t.ItemQuantity,
                        ItemName=t.ItemName,
                        SerialNo=t.SerialNo,
                        TotalPrice=t.TotalPrice
                    }).ToList()
                });
            });
            return prsentableInvoices;
        }

        public InvoiceAddEditModel GetInvoice(int invoiceId)
        {
            var p= this.Get<Invoice>(t => t.InvoiceId == invoiceId).FirstOrDefault();
            return new InvoiceAddEditModel
            {
                PoNO = p.PoNO,
                InvoiceTo = new ClientBranchAddEditModel
                {
                    Address1 = p.InvoiceTo.Address1,
                    Address2 = p.InvoiceTo.Address2,
                    Address3 = p.InvoiceTo.Address3,
                    BranchName = p.InvoiceTo.BranchName,
                    ClientBranchId = p.InvoiceTo.ClientBranchId
                },
                CGSTRate = p.CGSTRate,
                CGSTAmount = p.CGSTAmount,
                FromTime = p.FromTime,
                ToTime = p.ToTime,
                InvoiceId = p.InvoiceId,
                CompanyAddressId = p.CompanyAddressId,
                InvoiceDate = p.InvoiceDate,
                SACNo = p.SACNo,
                SGSTAmount = p.SGSTAmount,
                SGSTRate = p.SGSTRate,
                InvoiceNumber = p.InvoiceNumber,
                TotalWithoutTax = p.TotalWithoutTax,
                TotalWithTax = p.TotalWithTax,
                UserId = p.LogisticUserId,
                InvoiceItems = p.InvoiceItems.Select(t => new InvoiceItemAddEditModel
                {
                    InvoiceItemId = t.InvoiceItemId,
                    ItemQuantity = t.ItemQuantity,
                    ItemName = t.ItemName,
                    SerialNo = t.SerialNo,
                    TotalPrice = t.TotalPrice
                }).ToList(),
                GST=p.GST
            };
        }
    }
}
