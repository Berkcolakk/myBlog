using FinalProject.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.AppUserDTO
{
   public class AppUserList
    {
        [DisplayName("ID")]
        public Guid ID { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("Roller")]
        public Role Role { get; set; }
        [DisplayName("Fotoğraf")]
        public string ImagePath { get; set; }
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Soyad")]
        public string LastName { get; set; }
        [DisplayName("Mail Adresi")]
        public string Email { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Güncellenme Tarihi")]
        public DateTime ModifiedDate { get; set; }
        [DisplayName("Son Giriş ")]
        public DateTime LastLogin { get; set; }

    }
}
