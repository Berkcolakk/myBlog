using FinalProject.Dto.DTO.BlogDTO;
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
    [Role("Article", "Admin")]
    public class ArticleController : Controller
    {
        CategoryService _categoryService;
        BlogService _blogService;
        public ArticleController()
        {
            _categoryService = new CategoryService();
            _blogService = new BlogService();
        }
        [Role("Article", "Admin")]
        public ViewResult Index()
        {
            return View();
        }
        [Role("Article", "Admin")]
        [HttpGet]
        public ViewResult BlogAdd()
        {
            TempData["KategoriListesi"] = _categoryService.List();
            return View();
        }
        [Role("Article", "Admin")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult BlogAdd(BlogAdd dto, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                _blogService.ArticleAddBlog(dto, Image,User.Identity.Name);
                return RedirectToAction("Index", "Article");
            }
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();
        }
        [Role("Article", "Admin")]
        [HttpGet]
        public ActionResult List(BlogList data,int page = 1)
        {
            var List = _blogService.ArticleBlogList(data,User.Identity.Name).ToPagedList(page, 10);
            return View(List);
        }
        [Role("Article", "Admin")]
        public ActionResult Detail(Guid id, BlogDetail dto)
        {
            _blogService.Detail(id, dto);
            return View(dto);
        }
        [Role("Article", "Admin")]
        [HttpGet]
        public ActionResult Update(Guid id, BlogUpdate dto)
        {
            TempData["KategoriListesi"] = _categoryService.List();
            _blogService.UpdateGet(id, dto);

            return View(dto);
        }
        [Role("Article", "Admin")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(BlogUpdate dto, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                _blogService.UpdatePost(dto, Image);
                return RedirectToAction("List", "Article");
            }
            ViewBag.Message = "Bilgileri Eksik Doldurunuz Zorunlu Alanları Lütfen Doldurunuz.!";
            return View();
        }
    }
}