using FinalProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.BlogDTO
{
   public class BlogDetail
    {
        public BlogDetail()
        {
            Comments = new List<Comment>();
        }

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
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Güncellenme Tarihi")]
        public DateTime ModifiedDate { get; set; }
        public int ReadNumber { get; set; }

        public Guid CategoryID { get; set; }
       
        public Blog Blogs { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public int Likes { get; set; }
    }
}
