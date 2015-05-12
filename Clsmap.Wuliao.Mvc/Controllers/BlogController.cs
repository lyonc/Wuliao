using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clsmap.Wuliao.Mvc.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Contact()
        {
            ViewBag.Message = "Your can contact me on GitHub.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
