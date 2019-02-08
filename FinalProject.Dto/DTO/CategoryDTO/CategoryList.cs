using FinalProject.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.CategoryDTO
{
   public class CategoryList
    {
        public Guid ID { get; set; }
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int BlogSayisi { get; set; }
    }
}
