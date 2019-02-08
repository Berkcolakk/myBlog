using FinalProject.Dto.DTO.CommentDTO;
using FinalProject.Service.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        CommentService _commentService;
        public CommentController()
        {
            _commentService = new CommentService();
        }
        // GET: Member/Comment

    }
}