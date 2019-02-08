using FinalProject.Dal.Context;
using FinalProject.Model.Entities;
using FinalProject.Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository.Repository.Entities
{
    public class BlogRepository : BaseRepository<Blog>
    {
        FinalProjectContext _context;
        public BlogRepository()
        {
            _context = new FinalProjectContext();
        }

        public List<Blog> ListByArticleID(string username)
        {
            return _context.Blogs.Where(x => x.AppUser.UserName == username).ToList();
        }


    }
}
