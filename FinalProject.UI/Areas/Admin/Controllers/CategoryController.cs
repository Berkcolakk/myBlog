using FinalProject.Dto.DTO.CategoryDTO;
using FinalProject.Service.Service.Option;
using FinalProject.UI.Attributes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        CategoryService _category;
        public CategoryController()
        {
            _category = new CategoryService();
        }
        [Role("Admin")]
        public ViewResult List(int page = 1) =>View(_category.List().ToPagedList(page,10));
        

        [HttpGet]
        [Role("Admin")]
        public ViewResult Add() => View();
        

        [HttpPost]
        [Role("Admin")]
        public ActionResult Add(CategoryAdd data)
        {
            //CategoryService Kısmında DTO yu Parametre Vererek Burdan Gönderdim.
            if (ModelState.IsValid)
            {
                _category.Add(data);
                return RedirectToAction("List", "Category");
            }
            //Eğer Hata Olursa Yani ModelState IsValid Değil Ise ViewBag Message'ı Aç...
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();

        }
        //DEVAM EDİLECEK...!!!!!!
        [Role("Admin")]
        public ActionResult Detail(Guid id,CategoryDetail model)
        {
            //Bütün Model İşlemlerimi CategoryService Kısmında Gerçekleştirip Sadece Bu Kısımda İki Parametreyi Göndererek Bütün İşlemi Gerçekleştirmiş Oldum Bu Sayede Her Katmanım Farklı Görevler Gerçekleştirerek İşlemleri Yapıyor.
            _category.Detail(id,model);
 
            return View(model);
        }
        [Role("Admin")]
        public RedirectToRouteResult Delete(Guid id)
        {
            if (id != null)
            {
                _category.Delete(id);
                return RedirectToAction("List", "Category", new {area = "Admin"});
            }
            else
            {
               return RedirectToAction("NotFound", "Error", new { area = "" });
            }

        }
        [Role("Admin")]
        [HttpGet]
        public ActionResult Update(Guid id, CategoryUpdate model)
        {
            _category.UpdateGetAction(id, model);
            return View(model);
        }
        [Role("Admin")]
        [HttpPost]
        public RedirectToRouteResult Update(CategoryUpdate model,HttpPostedFileBase Image)
        {
            _category.UpdatePostAction(model, Image);
            return RedirectToAction("List", "Category");
        }
    }
}