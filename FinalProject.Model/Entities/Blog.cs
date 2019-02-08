using FinalProject.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model.Entities
{
   public class Blog:CoreEntity
    {
        public Blog()
        {
            Likes = new List<Like>();
            BlogComments = new List<BlogComment>();
        }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public bool Homepage { get; set; }
        public bool Confirmation { get; set; }
        public int ReadNumber { get; set; }

        public virtual AppUser AppUser { get; set; }
        public Guid UsersID { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
