using FinalProject.Dto.DTO.AccountDTO;
using FinalProject.Dto.DTO.AppUserDTO;
using FinalProject.Service.Service.Option;
using FinalProject.UI.Attributes;
using FinalProject.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalProject.UI.Controllers
{
    public class AccountController : Controller
    {
        AccountService _accountservice;
        public AccountController()
        {
            _accountservice = new AccountService();
        }
        //AccountService'de Gerekli Methodlar Yazıldı.
        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                _accountservice.GetByUsername(HttpContext.User.Identity.Name);
            }
            return View();
        }
        //AccountService'de Gerekli Methodlar Yazıldı.
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginVM VM)
        {
            if (ModelState.IsValid)
            {
                _accountservice.Check(VM.UserName, VM.Password);
            }
            ViewBag.Message = "Kullanıcı Adı veya Şifre Hatalıdır.";
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Register(AccountAdd DTO, HttpPostedFileBase Image )
        {
            if (ModelState.IsValid)
            {   
                _accountservice.MemberRegister(DTO, Image);
            }
            ModelState.AddModelError("userName", "Kullanıcı Adı Kullanılıyor.!");
            ModelState.AddModelError("Email", "Email Adresi Kullanılıyor");
            ViewBag.Message = "Bilgileri Eksik veya Yanlış Doldurdunuz.!";
            return View();
        }
        [HttpGet]
        public ActionResult PasswordForgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordForgot(AccountCheckMail DTO)
        {
            _accountservice.PasswordForgot(DTO);
            ViewBag.Message = "Kayıtlarımızla Eşleşen Bir Mail Adresi Girmediniz.!";
            return View();
        }
        //[HttpGet]
        //public ActionResult PasswordReset()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult PasswordReset(AccountPassForgot DTO)
        //{
        //    _accountservice.PasswordReset(DTO);
        //    return View();
        //}
    }
}
