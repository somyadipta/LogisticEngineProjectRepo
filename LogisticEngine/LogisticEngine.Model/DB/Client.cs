using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.DB
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string PAN { get; set; }
        public string GST { get; set; }

        public string ConcernEmails { get; set; }

        public virtual List<ClientBranch> Branches { get; set; }

    }
}
