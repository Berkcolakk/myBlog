using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.CategoryDTO
{
    public class CategoryUpdate
    {
        public Guid ID { get; set; }
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
