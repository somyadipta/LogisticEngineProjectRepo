using LogisticEngine.Model.DB;
using LogisticEngine.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEngine.Repository
{
   public class UserRepository: RepositoryBase, IUserRepository
    {
        public void AddDefaultUser()
        {
            if (this.Get<User>(p => p.Email == "s@s.com").Count() == 0)
            {
                this.Add<User>(new User
                {
                    Email="s@s.com",
                    FirstName="som",
                     LastName="Nayak",
                     Password="1234"
                });
            }
        }
        public User GetDefaultUser()
        {
            return this.Get<User>(p => p.Email == "s@s.com").FirstOrDefault();
        }
    }
}
