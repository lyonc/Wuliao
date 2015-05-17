using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Clsmap.Wuliao.Mvc.App_Data;
using Clsmap.Wuliao.Mvc.Models;

namespace Clsmap.Wuliao.Mvc.Controllers
{
    public class CommentController : Controller
    {
        private DbAccess db;

        public CommentController()
        {
            db = new DbAccess();
        }

        [HttpPost]
        public ActionResult Post(FormCollection collection)
        {
            if (Session["Captcha"].ToString() != collection.Get("commentCaptcha"))
            {
                ModelState.AddModelError("captcha", "Captcha not match");
                return View();
            }

            String arctileId = collection.Get("articleId");

            var comment = new Comment
            {
                ArticleId = arctileId,
                ReaderName = collection.Get("commentReaderName"),
                Content = collection.Get("commentContent"),
                ReaderEmail = collection.Get("commentReaderEmail"),
                PostTime = DateTime.Now,
                IsDisplay = true,
            };

            var result = db.PostComment(comment);

            return RedirectToAction("Detail", "Post", arctileId);
        }
    }
}
