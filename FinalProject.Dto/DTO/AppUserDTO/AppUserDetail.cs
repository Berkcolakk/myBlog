using FinalProject.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.AppUserDTO
{
   public class AppUserDetail
    {
        [DisplayName("ID")]
        public Guid ID { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("Roller")]
        public Role Role { get; set; }
        [DisplayName("Adres")]
        public string Address { get; set; }
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [DisplayName("Fotoğraf")]
        public string ImagePath { get; set; }
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Soyad")]
        public string LastName { get; set; }
        [DisplayName("Mail Adresi")]
        public string Email { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime Birthdate { get; set; }
        [DisplayName("Son Giriş Tarihi")]
        public DateTime LastLogin { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Güncellenme Tarihi")]
        public DateTime ModifiedDate { get; set; }
    }
}
