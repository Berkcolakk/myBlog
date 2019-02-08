using FinalProject.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model.Entities
{
    public class Like:CoreEntity
    {
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUsers { get; set; }

        public Guid BlogID { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
