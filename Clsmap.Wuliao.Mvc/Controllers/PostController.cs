using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using Clsmap.Wuliao.Mvc.App_Data;
using Clsmap.Wuliao.Mvc.Models;
using Clsmap.Wuliao.Mvc.Utilities;

namespace Clsmap.Wuliao.Mvc.Controllers
{
    public class PostController : Controller
    {
        private DbAccess db;

        public PostController()
        {
            db = new DbAccess();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail([Bind(Prefix = "id")]String postId = null)
        {
            if (String.IsNullOrWhiteSpace(postId))
            {
                postId = "0";
            }

            var post = GetArticleByPostId(postId);

            return View(post);
        }

        private PostViewModel GetArticleByPostId(String postId)
        {
            if (postId == "test-link-for-next-post")
            {
                return GetTestNextPost();
            }

            var post = db.GetArticleById(postId);

            return post;
        }

        private PostViewModel GetTestNextPost()
        {
            var article = new Article
            {
                Id = 1,
                PostId = "test-link-for-next-post",
                WriterName = "Lyon Chen",
                PublishTime = new DateTime(2015, 05, 12, 23, 42, 56),
                LastEditTime = new DateTime(2015, 05, 13, 01, 11, 00),
                Reads = 1,
                Likes = 1,
                Title = "冯唐易老，李广难封",
                Content = @"
        <p>
            春水初生，春林初盛，春风十里不如你。
        </p>
",
            };

            var post = new PostViewModel
            {
                Article = article,
                Topics = new []{ new Topic { Name = "Disrespect", LinkName = "Disrespect" } },
                Tags = new []
                { new Tag { Name = "C#", LinkName = "CSharp" }, 
                    new Tag { Name = "ASP.NET", LinkName = "ASPNET" }
                },
                Comments = null,
                PrevPost = null,
                NextPost = new Article
                {
                    PostId = "test-link-for-next-post",
                    Title = "This is a Test Link for Next post",
                }
            };

            return post;
        }
    }
}

