using LogisticEngine.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository.Interface
{
    public interface IUserRepository
    {
        void AddDefaultUser();
        User GetDefaultUser();
    }
}
