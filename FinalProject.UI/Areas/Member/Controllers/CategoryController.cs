using FinalProject.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.UI.Areas.Member.Controllers
{
    
    public class CategoryController : Controller
    {
        // GET: Member/Category
        public ActionResult Index()
        {
            return View();
        }
    }
}