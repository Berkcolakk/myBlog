using FinalProject.Dto.DTO.BlogDTO;
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
    public class BlogController : Controller
    {
        CategoryService _categoryService;
        BlogService _blogService;

        public BlogController()
        {
            _categoryService = new CategoryService();
            _blogService = new BlogService();
        }
        [Role("Admin")]
        public ViewResult List(int page = 1)
        {
            return View(_blogService.List().ToPagedList(page, 10));
        }

        [HttpGet]
        [Role("Admin")]
        public ViewResult Add()
        {
            TempData["KategoriListesi"] = _categoryService.List();
            return View();
        }

        [HttpPost]
        [Role("Admin")]
        public ActionResult Add(BlogAdd dto, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                _blogService.Add(dto, Image);
                return RedirectToAction("List", "Blog");
            }
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();
        }

        public ActionResult Detail(Guid id, BlogDetail dto)
        {
            _blogService.Detail(id, dto);
            return View(dto);
        }

        [HttpGet]
        [Role("Admin")]
        public ActionResult Update(Guid id, BlogUpdate dto)
        {
            TempData["KategoriListesi"] = _categoryService.List();
            _blogService.UpdateGet(id, dto);
            RedirectToAction("List", "Blog");

            return View(dto);
        }
        [ValidateInput(false)]
        [HttpPost]
        [Role("Admin")]
        public ActionResult Update(BlogUpdate dto, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                _blogService.UpdatePost(dto, Image);
                return RedirectToAction("List", "Blog");
            }
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();
        }
        [Role("Admin")]
        public RedirectToRouteResult Delete (Guid id)
        {
            _blogService.Delete(id);
            return RedirectToAction("List", "Blog");
        }
    }
}