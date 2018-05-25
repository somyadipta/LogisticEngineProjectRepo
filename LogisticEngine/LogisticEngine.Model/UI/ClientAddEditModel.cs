using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.UI
{
    public class ClientAddEditModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public string PAN { get; set; }
        public string GST { get; set; }

        public string ConcernEmails { get; set; }

        public List<ClientBranchAddEditModel> Branches { get; set; }
    }
}
