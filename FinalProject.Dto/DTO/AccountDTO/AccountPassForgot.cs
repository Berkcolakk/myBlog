using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.AccountDTO
{
   public class AccountPassForgot
    {
        [Required(ErrorMessage = "Şifre Zorunludur.")]
        [DisplayName("Eski Şifre")]
        [MinLength(4, ErrorMessage = "3 Karakterden Uzun Olmalı")]
        [MaxLength(20, ErrorMessage = "21 Karakterden Az Olmalı")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur.")]
        [DisplayName("Tekrar Giriniz")]
        [MinLength(4, ErrorMessage = "3 Karakterden Uzun Olmalı")]
        [MaxLength(20, ErrorMessage = "21 Karakterden Az Olmalı")]
        public string AgainPassword { get; set; }
    }
}
