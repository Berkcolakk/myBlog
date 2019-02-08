using FinalProject.Dto.DTO.CategoryDTO;
using FinalProject.Service.Service.Option;
using FinalProject.UI.Attributes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Article.Controllers
{
    [Role("Admin", "Article")]
    public class CategoryController : Controller
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        [HttpGet]
        public ViewResult CategoryAdd() => View();

        [Role("Admin", "Article")]
        [HttpPost]
        public ActionResult CategoryAdd(CategoryAdd data)
        {
            //CategoryService Kısmında DTO yu Parametre Vererek Burdan Gönderdim.
            if (ModelState.IsValid)
            {
                _categoryService.Add(data);
                return RedirectToAction("CategoryList", "Category");
            }
            //Eğer Hata Olursa Yani ModelState IsValid Değil Ise ViewBag Message'ı Aç...
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();

        }
        [Role("Admin", "Article")]
        public ViewResult CategoryList(int page = 1) => View(_categoryService.List().ToPagedList(page, 10));
        [Role("Admin", "Article")]
        public ActionResult Detail(Guid id, CategoryDetail model)
        {
            //Bütün Model İşlemlerimi CategoryService Kısmında Gerçekleştirip Sadece Bu Kısımda İki Parametreyi Göndererek Bütün İşlemi Gerçekleştirmiş Oldum Bu Sayede Her Katmanım Farklı Görevler Gerçekleştirerek İşlemleri Yapıyor.
            _categoryService.Detail(id, model);

            return View(model);
        }
        [Role("Admin", "Article")]
        public RedirectToRouteResult Delete(Guid id)
        {
            if (id != null)
            {
                _categoryService.Delete(id);
                return RedirectToAction("List", "Category", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }

        }
        [Role("Admin", "Article")]
        [HttpGet]
        public ActionResult Update(Guid id, CategoryUpdate model)
        {
            _categoryService.UpdateGetAction(id, model);
            return View(model);
        }
        [Role("Admin", "Article")]
        [HttpPost]
        public RedirectToRouteResult Update(CategoryUpdate model, HttpPostedFileBase Image)
        {
            _categoryService.UpdatePostAction(model, Image);
            return RedirectToAction("List", "Category");
        }
    }
}