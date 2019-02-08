using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.AccountDTO
{
   public class AccountLogin
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
