using FinalProject.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
    public class LikeController : Controller
    {
        // GET: Admin/Like
        public ActionResult Index()
        {
            return View();
        }
    }
}