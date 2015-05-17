using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Clsmap.Wuliao.Mvc.Utilities;

namespace Clsmap.Wuliao.Mvc.Controllers
{
    public class CaptchaController : Controller
    {
        public ActionResult Image()
        {
            var generator = new CaptchaGenerator();
            var code = generator.CreateCode(5);
            Session["Captcha"] = code;

            var imageBytes = generator.CreateImage(code);

            return File(imageBytes, @"image/jpeg");
        }
    }
}
