using FinalProject.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.CategoryDTO
{
   public class CategoryAdd
    {
        public Guid ID { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage ="Kategori Ismi Zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kategori Açıklaması Zorunludur.")]
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
