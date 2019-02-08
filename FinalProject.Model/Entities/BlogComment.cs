using FinalProject.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model.Entities
{
   public class BlogComment:CoreEntity
    {
        public Guid BlogID { get; set; }
        public Guid CommentID { get; set; }

        public virtual Blog Blogs { get; set; }
        public virtual Comment Comments { get; set; }
    }
}
