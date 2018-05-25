using LogisticEngine.Model.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository.Interface
{
    public interface ISetupRepository
    {
        bool AddEditClient(ClientAddEditModel clientModel);
    }
}
