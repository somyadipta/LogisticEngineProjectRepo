using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Model.DB
{
   public class LogisticUsers
    {
        [Key]
        public int UserId { get; set; }

        public string AspUserId { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public virtual List<Client> Client { get; set; }
    }
}
