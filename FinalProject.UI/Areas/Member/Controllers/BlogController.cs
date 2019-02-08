using FinalProject.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Member.Controllers
{
    
    public class BlogController : Controller
    {
        // GET: Member/Blog
        public ActionResult Index()
        {
            return View();
        }

    }
}