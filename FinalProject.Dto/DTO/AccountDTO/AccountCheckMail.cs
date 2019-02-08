using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Dto.DTO.AccountDTO
{
    public class AccountCheckMail
    {
        [DisplayName("Mail Adresi")]
        [Required(ErrorMessage = "Mail Adresiniz Zorunludur.")]
        [EmailAddress(ErrorMessage = "Email Formatında Girmediniz.")]
        [MinLength(6, ErrorMessage = "5 Karakterden Uzun Olmalı")]
        public string Mail { get; set; }
    }
}
