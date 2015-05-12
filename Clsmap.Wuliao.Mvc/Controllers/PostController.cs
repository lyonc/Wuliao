using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using Clsmap.Wuliao.Mvc.Models;
using Clsmap.Wuliao.Mvc.Utilities;

namespace Clsmap.Wuliao.Mvc.Controllers
{
    public class PostController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail([Bind(Prefix = "id")]String postId = null)
        {
            if (String.IsNullOrWhiteSpace(postId))
            {
                postId = "disrespect";
            }

            var article = GetArticleByPostId(postId);

            return View(article);
        }

        private Article GetArticleByPostId(String postId)
        {
            if (postId == "test-link-for-next-post")
            {
                return GetTestNextPost();
            }

            var article = new Article
            {
                Id = Guid.Parse("d201139d-76f5-4a1f-b8db-3f8fe42c2720"),
                PostId = "Disrespect",
                Writer = "Lyon Chen",
                PublishTime = new DateTime(2015, 05, 02, 15, 08, 56),
                LastEditTime = new DateTime(2015, 05, 03, 19, 42, 00),
                Reads = 2,
                Comments = 1,
                Likes = 1,
                Title = "和安科技股份有限公司怎么样？",
                Content = @"
        <div class=""jumbotron"">
            <h1>为什么说和安是一家烂公司？</h1>
            <p class=""lead"">因为它真的很烂。</p>
        </div>

        <div class=""row"">
            <div class=""col-md-4"">
                <h2>代码猴子与人肉测试</h2>
                <p>
                    写代码从来都没有设计书，也从来都不写单元测试。问她为什么不写。她说你讲的都对，但是现在没有。
                </p>
            </div>
            <div class=""col-md-4"">
                <h2>视客户利益如儿戏</h2>
                <p>
                    做医疗软件，竟然完全不注重软件质量。程序频频假死崩溃，账目错乱。
                </p>
            </div>
            <div class=""col-md-4"">
                <h2>拖欠员工工资</h2>
                <p>
                    平时老板作威作福，颐指气使。薪水却发不出来，而且是连续三个月。玩不起就申请破产啊。
                </p>
            </div>
        </div>",
                Categories = new []{ new Category { Name = "Disrespect", LinkName = "Disrespect" } },
                Tags = new []
                { new Tag { Name = "C#", LinkName = "CSharp" }, 
                    new Tag { Name = "ASP.NET", LinkName = "ASPNET" }
                },
                PrevPost = null,
                NextPost = new Article
                {
                    PostId = "test-link-for-next-post",
                    Title = "This is a Test Link for Next post",
                }
            };

            return article;
        }

        private Article GetTestNextPost()
        {
            var article = new Article
            {
                Id = Guid.Parse("d201139d-76f5-4a1f-b8db-3f8fe42c2722"),
                PostId = "test-link-for-next-post",
                Writer = "Lyon Chen",
                PublishTime = new DateTime(2015, 05, 12, 23, 42, 56),
                LastEditTime = new DateTime(2015, 05, 13, 01, 11, 00),
                Reads = 1,
                Comments = 0,
                Likes = 1,
                Title = "冯唐易老，李广难封",
                Content = @"
        <p>
            春水初生，春林初盛，春风十里不如你。
        </p>
",
                Categories = new []{ new Category { Name = "Disrespect", LinkName = "Disrespect" } },
                Tags = new []
                { new Tag { Name = "C#", LinkName = "CSharp" }, 
                    new Tag { Name = "ASP.NET", LinkName = "ASPNET" }
                },
                PrevPost = null,
                NextPost = new Article
                {
                    PostId = "test-link-for-next-post",
                    Title = "This is a Test Link for Next post",
                }
            };

            return article;
        }
    }
}

