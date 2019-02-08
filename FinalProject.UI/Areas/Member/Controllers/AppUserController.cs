using FinalProject.Dto.DTO.AccountDTO;
using FinalProject.Dto.DTO.AppUserDTO;
using FinalProject.Service.Service.Option;
using FinalProject.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Member.Controllers
{
    [Role("Member","Article","Editor","Admin")]
    public class AppUserController : Controller
    {
        AppUserService _appuserService;
        AccountService _AccountService;
        public AppUserController()
        {
            _appuserService = new AppUserService();
            _AccountService = new AccountService();
        }
        [Role("Member", "Article", "Editor", "Admin")]
        public ActionResult AccountSetting()
        {
            return View();
        }
        [Role("Member", "Article", "Editor", "Admin")]
        [HttpGet]
        public ActionResult AppUserUpdate(AppUserDetail model)
        {
            _AccountService.UserUpdateGet(User.Identity.Name,model);
            return View(model);
        }

       [Role("Member", "Article", "Editor", "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AppUserUpdate(AppUserDetail model,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                _AccountService.UserUpdatePost(User.Identity.Name, model, Image);
            }
            ModelState.AddModelError("UserName", "Kullanıcı Adı Kullanılıyor.!");
            ModelState.AddModelError("Email", "Email Adresi Kullanılıyor");
            return View();
        }
        [HttpGet]
        public ActionResult PasswordChange()
        {
            return View();
        }

        public ActionResult PasswordChange(AccountPassChange Password)
        {
            if (ModelState.IsValid)
            {
                _AccountService.PasswordChange(Password, User.Identity.Name);
                return RedirectToAction("AccountSetting", "AppUser");
            }
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();
        }

    }
}
