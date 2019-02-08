using FinalProject.Dto.DTO.AppUserDTO;
using FinalProject.Service.Service.Option;
using FinalProject.UI.Attributes;
using FinalProject.Utility;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
    public class AppUserController : Controller
    {
        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }
        //List Action
        [Role("Admin")]
        public ActionResult List(int page = 1) => View(_appUserService.List().ToPagedList(page,10));

        //Ekleme
        [HttpGet]
        [Role("Admin")]
        public ActionResult Add() => View();
        
        [HttpPost]
        [Role("Admin")]
        public ActionResult Add(AppUserAdd dto, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid )
            {
                _appUserService.Add(dto,Image);
                return RedirectToAction("List", "AppUser",new {area = "Admin"});
            }
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();
        }
        //Detay Sayfası
        [Role("Admin")]
        public ActionResult Detail(Guid id, AppUserDetail model)
        {
            //Bütün Model İşlemlerimi CategoryService Kısmında Gerçekleştirip Sadece Bu Kısımda İki Parametreyi Göndererek Bütün İşlemi Gerçekleştirmiş Oldum Bu Sayede Her Katmanım Farklı Görevler Gerçekleştirerek İşlemleri Yapıyor.
                _appUserService.Detail(id, model);
            return View(model);
        }

        [Role("Admin")]
        public RedirectToRouteResult Delete(Guid id)
        {
            _appUserService.Delete(id);
            return RedirectToAction("List", "AppUser", new { area = "Admin" });
        }
        [HttpGet]
        [Role("Admin")]
        public ActionResult Update(Guid id,AppUserUpdate model)
        {
            //Detail Action'ununda Yapıcağım İşlemler İle Update/Get Action'unda Kullanıyorum Çünkü Yazılacak Kodlar Aynı...
            
                _appUserService.UpdateGetAction(id, model);
            return View(model);
        }
        [HttpPost]
        [Role("Admin")]
        public ActionResult Update(AppUserUpdate model,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                _appUserService.UpdatePostAction(model, Image);
                return RedirectToAction("List", "AppUser");
            }
            ViewBag.Message = "Bilgileri Eksik Doldurdunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();
        }

        [HttpGet]
        [Role("Admin")]
        public ActionResult Roles()
        {
            return View();
        }

        [HttpPost]
        [Role("Admin")]
        public ActionResult Roles(AppUserRoles model)
        {
            _appUserService.Roles(model);
            return RedirectToAction("List", "AppUser");
        }
      }
    }

