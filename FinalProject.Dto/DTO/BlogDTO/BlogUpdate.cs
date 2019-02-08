using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.BlogDTO
{
   public class BlogUpdate
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Başlık Boş Bırakılamaz.")]
        [DisplayName("Başlık")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Açıklama Boş Bırakılamaz.")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Içerik")]
        [Required(ErrorMessage = "Içerik Boş Bırakılamaz.")]
        public string Content { get; set; }
        [DisplayName("Fotoğraf")]
        public string Image { get; set; }
        [DisplayName("Anasayfa")]
        public bool Homepage { get; set; }
        [DisplayName("Onay")]
        public bool Confirmation { get; set; }

        //Category'de Tuple Olarak Çekiceğim Propertyler
        public Guid CategoryID { get; set; }
    }
}
