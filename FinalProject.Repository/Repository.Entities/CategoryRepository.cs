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
   public class CategoryRepository:BaseRepository<Category>
    {
        private FinalProjectContext  _context;
        public CategoryRepository()
        {
            _context = new FinalProjectContext();
        }

    }
}
