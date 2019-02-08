using FinalProject.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model.Entities
{
   public class Comment:CoreEntity
    {
        public Comment()
        {
            BlogComments = new List<BlogComment>();
        }
        public string Body { get; set; }

        public Guid BlogID { get; set; }
        public Guid AppUsersID { get; set; }
        public virtual AppUser AppUsers { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
