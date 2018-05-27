using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.DB
{
   public class LogisticUser
    {
        [Key]
        public int LogisticUserId { get; set; }

        public string SystemUserId { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public virtual List<Client> Clients { get; set; }
    }
}
