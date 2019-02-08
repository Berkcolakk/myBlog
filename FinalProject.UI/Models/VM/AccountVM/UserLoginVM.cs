using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.UI.Models.VM
{
    public class UserLoginVM
    {
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
    }
}