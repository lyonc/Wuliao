// Article.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;
using System.Collections.Generic;

namespace Clsmap.Wuliao.Mvc.Models
{
    public class Article
    {
        public Article()
        {
        }

        public Guid Id { get; set; }

        public String PostId { get; set; }

        public String Writer { get; set; }

        public DateTime PublishTime { get; set; }

        public DateTime LastEditTime{ get; set; }

        public Int32 Reads { get; set; }

        public Int32 Comments { get; set; }

        public Int32 Likes { get; set; }

        public String Title { get; set; }

        public String Content { get; set; }

        public IList<Category> Categories { get; set; }

        public IList<Tag> Tags{ get; set; }

        public Article PrevPost { get; set; }

        public Article NextPost { get; set; }
    }
}

