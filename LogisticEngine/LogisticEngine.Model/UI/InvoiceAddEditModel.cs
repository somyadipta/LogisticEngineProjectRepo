using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.UI
{
    public class InvoiceAddEditModel
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string InvoiceNumber { get; set; }
        public string PoNO { get; set; }
        public string GST { get; set; }
        public string SACNo { get; set; }
        public int CompanyAddressId { get; set; }
        public AddressAddEditModel InvoiceTo { get; set; }
        public double CGSTRate { get; set; }
        public double CGSTAmount { get; set; }
        public double SGSTRate { get; set; }
        public double SGSTAmount { get; set; }
        public double TotalWithoutTax { get; set; }
        public double TotalWithTax { get; set; }
        public int UserId { get; set; }
        public List<InvoiceItemAddEditModel> InvoiceItems { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
    }
    public class AddressAddEditModel
    {
        public int CompanyAddressId { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }

    public class InvoiceItemAddEditModel
    {
        public int InvoiceItemId { get; set; }
        public int SerialNo { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double TotalPrice { get; set; }
    }

}
