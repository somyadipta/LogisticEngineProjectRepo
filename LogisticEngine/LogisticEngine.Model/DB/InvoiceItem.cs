using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.DB
{
   public  class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }
        public int SerialNo { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double PerItemPrice { get; set; }
        public double TotalPrice { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
