using FinalProject.Core.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.UI.Models.VM.BlogVM
{
    public class BlogDetailVM
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur.")]
        [DisplayName("Kullanıcı Adı")]
        [MinLength(4, ErrorMessage = "3 Karakterden Uzun Olmalı")]
        [MaxLength(20, ErrorMessage = "21 Karakterden Az Olmalı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur.")]
        [DisplayName("Şifre")]
        [MinLength(4, ErrorMessage = "3 Karakterden Uzun Olmalı")]
        [MaxLength(20, ErrorMessage = "21 Karakterden Az Olmalı")]
        public string Password { get; set; }


        [DisplayName("Adres")]
        [MinLength(11, ErrorMessage = "10 Karakterden Uzun Olmalı")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon Numarası Zorunludur."), MinLength(10, ErrorMessage = "Telefon Numaranızı Başında '0' Olmadan Giriniz.")]
        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [DisplayName("Fotoğraf")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Ad Zorunludur.")]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Zorunludur.")]
        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [DisplayName("Mail Adresi")]
        [Required(ErrorMessage = "Mail Adresiniz Zorunludur.")]
        [EmailAddress(ErrorMessage = "Email Formatında Girmediniz.")]
        [MinLength(6, ErrorMessage = "5 Karakterden Uzun Olmalı")]
        public string Email { get; set; }

        [DisplayName("Doğum Tarihi")]
        public DateTime Birthdate { get; set; }

        [DisplayName("Roller")]
        public Role Role { get; set; }
    }
}