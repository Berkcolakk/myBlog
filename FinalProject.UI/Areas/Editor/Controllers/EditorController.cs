using FinalProject.Dto.DTO.BlogDTO;
using FinalProject.Service.Service.Option;
using FinalProject.UI.Attributes;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Editor.Controllers
{
    [Role("Admin", "Editor")]
    public class EditorController : Controller
    {
        CategoryService _categoryService;
        BlogService _blogService;
        public EditorController()
        {
            _categoryService = new CategoryService();
            _blogService = new BlogService();
        }
        [Role("Admin", "Editor")]
        public ActionResult Index(int page = 1)
        {
            var List = _blogService.List().Where(x => x.Homepage == false || x.Confirmation == false).ToPagedList(page, 10);
            return View(List);
        }
        public ActionResult Approved(int page = 1)
        {
            var List = _blogService.List().Where(x => x.Homepage == true || x.Confirmation == true).ToPagedList(page, 10);
            return View(List);
        }
        [Role("Admin", "Editor")]
        public ActionResult Update(Guid id, BlogUpdate dto)
        {
            TempData["KategoriListesi"] = _categoryService.List();
            _blogService.UpdateGet(id, dto);
            return View(dto);
        }
        [Role("Admin", "Editor")]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(BlogUpdate data,HttpPostedFileBase Image)
        {
            _blogService.UpdatePost(data,Image);
            return RedirectToAction("Index", "Editor");
        }
    }
}