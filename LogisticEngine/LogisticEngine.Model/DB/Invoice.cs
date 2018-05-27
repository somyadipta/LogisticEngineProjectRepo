using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.DB
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string InvoiceNumber { get; set; }

        public string PoNO { get; set; }
        public string GST { get; set; }
        public string SACNo { get; set; }
        public string InvoiceType { get; set; }


        public int CompanyAddressId { get; set; }
        public virtual ClientBranch InvoiceTo { get; set; }

        public double CGSTRate { get; set; }
        public double CGSTAmount { get; set; }

        public double SGSTRate { get; set; }
        public double SGSTAmount { get; set; }

        public double TotalWithoutTax { get; set; }
        public double TotalWithTax { get; set; }

        [ForeignKey("LogisticUser")]
        public int LogisticUserId { get; set; }
        public virtual LogisticUser LogisticUser { get; set; }

        public virtual List<InvoiceItem> InvoiceItems { get; set; }
    }
}
