using FinalProject.Dto.DTO.BlogDTO;
using FinalProject.Service.Service.Option;
using FinalProject.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
    public class CommentController : Controller
    {
        CommentService _commentService;
        public CommentController()
        {
            _commentService = new CommentService();
        }
        public ActionResult List()
        {
            return View(_commentService.AdminCommentList());
        }
    }
}