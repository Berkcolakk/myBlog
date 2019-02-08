
using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.BlogDTO
{
    public class BlogList
    {
        public Guid ID { get; set; }
        [DisplayName("Başlık")]
        public string Header { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Içerik")]
        public string Content { get; set; }
        [DisplayName("Fotoğraf")]
        public string Image { get; set; }
        [DisplayName("Anasayfa")]
        public bool Homepage { get; set; }
        [DisplayName("Onay")]
        public bool Confirmation { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Güncellenme Tarihi")]
        public DateTime ModifiedDate { get; set; }
        public int ReadNumber { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryID { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public string UserName { get; set; }
        public Guid UserID { get; set; }
    }
}
