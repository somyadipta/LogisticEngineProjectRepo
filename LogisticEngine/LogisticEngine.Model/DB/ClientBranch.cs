using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.DB
{
   public class ClientBranch
    {
        [Key]
        public int ClientBranchId { get; set; }
        public string BranchName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

        public string PAN { get; set; }
        public string GST { get; set; }
        public string ConcernEmails { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
