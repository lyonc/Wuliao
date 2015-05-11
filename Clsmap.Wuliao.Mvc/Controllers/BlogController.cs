using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Clsmap.Wuliao.Mvc.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Disrespect()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact me on GitHub.";
            return View();
        }
    }
}

