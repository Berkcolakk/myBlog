using FinalProject.Dto.DTO.BlogDTO;
using FinalProject.Dto.DTO.CommentDTO;
using FinalProject.Dto.DTO.LikeDTO;
using FinalProject.Service.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Controllers
{
    public class HomeController : Controller
    {
        CommentService _commentService;
        AppUserService _userService;
        CategoryService _categoryService;
        BlogService blogService;
        LikeService _likeService;
        public HomeController()
        {
            _userService = new AppUserService();
            blogService = new BlogService();
            _categoryService = new CategoryService();
            _commentService = new CommentService();
            _likeService = new LikeService();
        }
        public ActionResult Index()
        {
            ViewBag.CurrentUser = User.Identity.Name;
            var bloglar = blogService.List().Where(x => x.Confirmation == true && x.Homepage == true);
           return View(bloglar.ToList());
        }
        public ActionResult Detail(Guid id, BlogDetail model)
        {

            blogService.Detail(id,model);
            return View(model);
        }
        //Kategorileri Listelemek İçin CategoryService'in Listeleme Methodunu Kullandım 'List' >>>>>>>
        public JsonResult Kategoriler()
        {
            return Json(_categoryService.List(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult BlogCatList(Guid id)
        {
            var ListCat = blogService.BlogCatList(id).Where(x => x.Confirmation == true);
            return View(ListCat);
        }

        //[HttpPost]
        //public RedirectToRouteResult AddComment(CommentAdd data)
        //{
        //    _commentService.CommentAdd(data, User.Identity.Name);
        //    return RedirectToAction("Detail", "Home", new { id = data.BlogID });
        //}

        // => LikeService =>
        public ActionResult AddLike(LikeAdd Dto,Guid id)
        {
            _likeService.AddLike(Dto,id, User.Identity.Name);
            return Json(Dto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CommentAdd(CommentAdd data,Guid id)
        {
            if (!string.IsNullOrWhiteSpace(data.Comments))
            {
                _commentService.CommentAdd(data,id,User.Identity.Name);
                return Json(data);
            }
            return Json("<h3>Yorum Boş Geçilemez.!</h3> <hr />");
         
        }

        public JsonResult CommentList(Guid id,BlogDetail data)
        {
           var List = _commentService.CommentList(id,data);
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadNumber(Guid id)
        {
            blogService.BlogReadNumber(id);
            return Json("");
        }

    }
}