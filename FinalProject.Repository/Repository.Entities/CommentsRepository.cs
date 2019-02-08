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
    public class CommentsRepository:BaseRepository<Comment>
    {

        FinalProjectContext _context;
        public CommentsRepository()
        {
            _context = new FinalProjectContext();
        }
        public List<Comment> ListByArticleID(Guid blogID)
        {
            return _context.Comments.Where(x => x.BlogID == blogID).ToList();
        }
    }
}
