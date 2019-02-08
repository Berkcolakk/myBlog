using FinalProject.Dal.Context;
using FinalProject.Model.Entities;
using FinalProject.Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository.Repository.Entities
{
   public class AppUserRepository : BaseRepository<AppUser>
    {
        FinalProjectContext _context;
        public AppUserRepository()
        {
            _context = new FinalProjectContext();
        }
        public bool CheckCredentials(string userName, string password) => Any(user => user.UserName == userName && user.Password == password);

        public AppUser FindByUserName(string userName) => GetByDefault(user => user.UserName == userName);

        public bool MailCredentials(string eMail) => Any(user => user.Email == eMail);

        public AppUser FindByEmail(string eMail) => GetByDefault(x => x.Email == eMail);

    }
}
