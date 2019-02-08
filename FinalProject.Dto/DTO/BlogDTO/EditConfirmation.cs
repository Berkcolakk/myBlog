using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.BlogDTO
{
    public class EditConfirmation
    {
        public Guid ID { get; set; }
        [DisplayName("Anasayfa")]
        public bool Homepage { get; set; }
        [DisplayName("Onay")]
        public bool Confirmation { get; set; }
    }
}
