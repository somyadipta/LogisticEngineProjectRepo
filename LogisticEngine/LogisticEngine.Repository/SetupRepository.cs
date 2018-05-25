using LogisticEngine.Model.DB;
using LogisticEngine.Model.UI;
using LogisticEngine.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository
{
    public class SetupRepository:RepositoryBase, ISetupRepository
    {
        public bool AddEditClient(ClientAddEditModel  clientModel)
        {
            var client = new Client
            {
                ClientId=clientModel.ClientId,
                Name=clientModel.Name,
                PAN=clientModel.PAN,
                GST=clientModel.GST,
                ConcernEmails=clientModel.ConcernEmails,
                Branches=clientModel.Branches.Select(p=> new ClientBranch
                {
                    ClientBranchId=p.ClientBranchId,
                    ConcernEmails=p.ConcernEmails,
                    BranchName=p.BranchName,
                    Address1=p.Address1,
                    Address2=p.Address2,
                    Address3=p.Address3,
                    City=p.City,
                    State=p.State,
                    Country=p.Country,
                    Zip=p.Zip,
                    GST=p.GST,
                    PAN=p.PAN,
                    ClientId=clientModel.ClientId
                }).ToList()

            };
            try
            {
                if (client.ClientId > 0)
                {
                    client.Branches.ForEach((b) =>
                    {
                        if (b.ClientBranchId > 0)
                        {
                            this.Update<ClientBranch>(b);
                        }
                        else
                        {
                            this.Add<ClientBranch>(b);
                        }
                    });
                    this.Update<Client>(client);
                }
                else
                {
                    this.Add<Client>(client);
                }
            }
            catch (Exception x)
            {
                return false;
            }
            return true;
        }
        public List<ClientAddEditModel> GetClients(int userId)
        {
            return new List<ClientAddEditModel>();
        }
    }
}
