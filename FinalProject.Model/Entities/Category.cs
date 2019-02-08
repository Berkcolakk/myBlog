using FinalProject.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model.Entities
{
   public class Category:CoreEntity
    {
        public Category()
        {
            Bloglar = new List<Blog>();
        }
        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<Blog> Bloglar { get; set; }
    }
}
